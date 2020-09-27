using BongoCat.DJMAX.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Threading;
using System.Windows.Forms;
using KeySetBase = BongoCat.DJMAX.Models.KeySetBase;

namespace BongoCat.DJMAX
{
    public sealed partial class MainWindow : Form
    {
        #region Constants

        private const int LeftLeftUp = 0;
        private const int LeftLeft0 = 1;
        private const int LeftLeft1 = 2;
        private const int LeftLeft2 = 3;

        private const int LeftRightUp = 4;
        private const int LeftRight0 = 5;
        private const int LeftRight1 = 6;
        private const int LeftRight2 = 7;

        private const int RightLeftUp = 8;
        private const int RightLeft0 = 9;
        private const int RightLeft1 = 10;
        private const int RightLeft2 = 11;

        private const int RightRightUp = 12;
        private const int RightRight0 = 13;
        private const int RightRight1 = 14;
        private const int RightRight2 = 15;

        #endregion

        private Skin _skin;
        private SpriteGroup[] _sprites;

        private KeyState[] _keyBindings;
        private KeyMotion[] _keyMotions;
        private Thread _keyThread;
        private int _keyDelay;

        private Buttons _buttons;

        // render
        private int[] _defaultHandState;

        private int[] _handState;
        private int[] _handStateBuffer;

        private bool[] _effectState;
        private bool[] _effectStateBuffer;

        private readonly CrossContextDelegate _invalidateDelegate;

        public MainWindow(Configuration configuration)
        {
            InitializeComponent();

            SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer,
                true);

            ApplyConfiguration(configuration);

            _invalidateDelegate = Invalidate;

            Run();
        }

        private void ApplyConfiguration(Configuration config)
        {
            _buttons = config.Buttons;
            _skin = config.Skin;
            
            BackColor = config.Background!.Value;

            SetupKeyBindings(config);
            SetupResources();
            SetupMotions();
            AdjustClientSize();

            _defaultHandState = new[] {0, 4, 8, 12};
            _handState = (int[]) _defaultHandState.Clone();
            _handStateBuffer = (int[]) _defaultHandState.Clone();

            _effectState = new bool[_skin.Effects.Length];
            _effectStateBuffer = new bool[_skin.Effects.Length];

            _keyDelay = 1000 / config.RefreshRate!.Value;
        }

        private void AdjustClientSize()
        {
            var size = ClientSize;
            using var g = CreateGraphics();

            ClientSize = new Size(
                (int) (_skin.Background.Width * g.DpiX / _skin.Background.HorizontalResolution),
                (int) (_skin.Background.Height * g.DpiY / _skin.Background.VerticalResolution)
            );

            Left += (size.Width - ClientSize.Width) / 2;
            Top += (size.Height - ClientSize.Height) / 2;
        }

        private void SetupKeyBindings(Configuration config)
        {
            KeySetBase keySet = _buttons switch
            {
                Buttons._4 => config.KeySet4,
                Buttons._5 => config.KeySet5,
                Buttons._6 => config.KeySet6,
                Buttons._8 => config.KeySet8,
                _ => throw new ArgumentOutOfRangeException()
            };

            _keyBindings = keySet.GetKeys()
                .Reverse()
                .Select(k => new KeyState(k))
                .ToArray();
        }

        private void SetupResources()
        {
            _sprites = new SpriteGroup[16];

            _sprites[LeftLeftUp] = new SpriteGroup(0, Properties.Resources.l_l_up);
            _sprites[LeftLeft0] = new SpriteGroup(0, Properties.Resources.l_l_0);
            _sprites[LeftLeft1] = new SpriteGroup(0, Properties.Resources.l_l_1);
            _sprites[LeftLeft2] = new SpriteGroup(0, Properties.Resources.l_l_2);

            _sprites[LeftRightUp] = new SpriteGroup(1, Properties.Resources.l_r_up);
            _sprites[LeftRight0] = new SpriteGroup(1, Properties.Resources.l_r_0);
            _sprites[LeftRight1] = new SpriteGroup(1, Properties.Resources.l_r_1);
            _sprites[LeftRight2] = new SpriteGroup(1, Properties.Resources.l_r_2);

            _sprites[RightLeftUp] = new SpriteGroup(2, Properties.Resources.r_l_up);
            _sprites[RightLeft0] = new SpriteGroup(2, Properties.Resources.r_l_0);
            _sprites[RightLeft1] = new SpriteGroup(2, Properties.Resources.r_l_1);
            _sprites[RightLeft2] = new SpriteGroup(2, Properties.Resources.r_l_2);

            _sprites[RightRightUp] = new SpriteGroup(3, Properties.Resources.r_r_up);
            _sprites[RightRight0] = new SpriteGroup(3, Properties.Resources.r_r_0);
            _sprites[RightRight1] = new SpriteGroup(3, Properties.Resources.r_r_1);
            _sprites[RightRight2] = new SpriteGroup(3, Properties.Resources.r_r_2);
        }

        private void SetupMotions()
        {
            switch (_buttons)
            {
                case Buttons._4:
                    _keyMotions = new[]
                    {
                        new KeyMotion(new[] {1, 2}, LeftLeft2),
                        new KeyMotion(new[] {3, 4}, RightLeft2),

                        new KeyMotion(new[] {0}, LeftLeft0),
                        new KeyMotion(new[] {1}, LeftLeft2),
                        new KeyMotion(new[] {2}, LeftRight2),
                        new KeyMotion(new[] {3}, RightLeft0),
                        new KeyMotion(new[] {4}, RightLeft2),
                        new KeyMotion(new[] {5}, RightRight2),
                    };
                    break;

                case Buttons._5:
                case Buttons._6:
                    _keyMotions = new[]
                    {
                        new KeyMotion(new[] {0, 1}, LeftLeft1),
                        new KeyMotion(new[] {2, 3}, LeftRight1),
                        new KeyMotion(new[] {4, 5}, RightLeft1),
                        new KeyMotion(new[] {6, 7}, RightRight1),

                        new KeyMotion(new[] {0}, LeftLeft0),
                        new KeyMotion(new[] {1}, LeftLeft2),
                        new KeyMotion(new[] {2}, LeftRight0),
                        new KeyMotion(new[] {3}, LeftRight2),
                        new KeyMotion(new[] {4}, RightLeft0),
                        new KeyMotion(new[] {5}, RightLeft2),
                        new KeyMotion(new[] {6}, RightRight0),
                        new KeyMotion(new[] {7}, RightRight2)
                    };
                    break;

                case Buttons._8:
                    _keyMotions = new[]
                    {
                        new KeyMotion(new[] {0, 1}, LeftLeft1),
                        new KeyMotion(new[] {3, 4}, LeftRight1),
                        new KeyMotion(new[] {5, 6}, RightLeft1),
                        new KeyMotion(new[] {7, 8}, RightRight1),

                        new KeyMotion(new[] {0}, LeftLeft0),
                        new KeyMotion(new[] {1}, LeftLeft1),
                        new KeyMotion(new[] {2}, LeftLeft2),
                        new KeyMotion(new[] {3}, LeftRight0),
                        new KeyMotion(new[] {4}, LeftRight2),
                        new KeyMotion(new[] {5}, RightLeft0),
                        new KeyMotion(new[] {6}, RightLeft2),
                        new KeyMotion(new[] {7}, RightRight0),
                        new KeyMotion(new[] {8}, RightRight1),
                        new KeyMotion(new[] {9}, RightRight2)
                    };
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void Run()
        {
            _keyThread = new Thread(KeyWorker)
            {
                IsBackground = true
            };

            _keyThread.Start();
        }

        private void KeyWorker()
        {
            var keyCount = _keyBindings.Length;

            while (true)
            {
                Thread.Sleep(_keyDelay);

                var dirty = false;
                var pressedAnyKey = false;

                for (var i = 0; i < keyCount; i++)
                {
                    var pressed = _keyBindings[i].Update();
                    ref var effectState = ref _effectStateBuffer[i];

                    pressedAnyKey |= pressed;
                    dirty |= effectState != pressed;

                    effectState = pressed;
                }

                if (!dirty)
                    continue;

                if (!pressedAnyKey)
                    goto swap;

                var hitMap = new bool[4];

                foreach (var motion in _keyMotions)
                {
                    var sprite = _sprites[motion.Sprite];
                    ref var hit = ref hitMap[sprite.GroupId];

                    if (hit || motion.Keys.Any(i => !_keyBindings[i].IsPressed))
                    {
                        continue;
                    }

                    hit = true;

                    ref var state = ref _handStateBuffer[sprite.GroupId];

                    if (state == motion.Sprite)
                    {
                        continue;
                    }

                    state = motion.Sprite;
                }

                // Swap buffer
                swap:
                Array.Copy(_handStateBuffer, _handState, 4);
                Array.Copy(_effectStateBuffer, _effectState, _effectState.Length);

                try
                {
                    Invoke(_invalidateDelegate);
                }
                catch (ObjectDisposedException)
                {
                    break;
                }

                // Clear buffer
                Array.Copy(_defaultHandState, _handStateBuffer, 4);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;

            g.DrawImage(_skin.Background, Point.Empty);

            for (var i = 0; i < _effectState.Length; i++)
            {
                if (!_effectState[i])
                    continue;

                g.DrawImage(_skin.Effects[i], Point.Empty);
            }

            g.DrawImage(_sprites[_handState[0]].Bitmap, Point.Empty);
            g.DrawImage(_sprites[_handState[1]].Bitmap, Point.Empty);
            g.DrawImage(_sprites[_handState[2]].Bitmap, Point.Empty);
            g.DrawImage(_sprites[_handState[3]].Bitmap, Point.Empty);
        }
    }
}