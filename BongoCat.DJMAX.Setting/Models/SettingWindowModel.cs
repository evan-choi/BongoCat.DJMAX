using System.Collections.Generic;
using System.Windows.Input;
using BongoCat.DJMAX.Common;
using BongoCat.DJMAX.Setting.Data;

namespace BongoCat.DJMAX.Setting.Models
{
    internal class SettingWindowModel : NotifyModel
    {
        public PropertyTransaction<Buttons> Buttons
        {
            get => _buttons;
            set
            {
                _buttons = value;
                OnPropertyChanged();
            }
        }

        public PropertyTransaction<Color?> Background
        {
            get => _background;
            set
            {
                _background = value;
                OnPropertyChanged();
            }
        }

        public PropertyTransaction<string> Skin
        {
            get => _skin;
            set
            {
                _skin = value;
                OnPropertyChanged();
            }
        }

        public PropertyTransaction<int?> RefreshRate
        {
            get => _refreshRate;
            set
            {
                _refreshRate = value;
                OnPropertyChanged();
            }
        }

        public IList<Buttons> ButtonItems
        {
            get => _buttonItems;
            set
            {
                _buttonItems = value;
                OnPropertyChanged();
            }
        }

        public IList<Color> BackgroundItems
        {
            get => _backgroundItems;
            set
            {
                _backgroundItems = value;
                OnPropertyChanged();
            }
        }

        public IList<string> SkinItems
        {
            get => _skinItems;
            set
            {
                _skinItems = value;
                OnPropertyChanged();
            }
        }

        public IList<int> RefreshRateItems
        {
            get => _refreshRateItems;
            set
            {
                _refreshRateItems = value;
                OnPropertyChanged();
            }
        }

        public InputKeysModel[] Keys
        {
            get => _keys;
            set
            {
                _keys = value;
                OnPropertyChanged();
            }
        }

        public object Overlay
        {
            get => _overlay;
            set
            {
                _overlay = value;
                OnPropertyChanged();
            }
        }

        public ICommand CancelCommand
        {
            get => _cancelCommand;
            set
            {
                _cancelCommand = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand
        {
            get => _saveCommand;
            set
            {
                _saveCommand = value;
                OnPropertyChanged();
            }
        }

        private IList<Buttons> _buttonItems;
        private IList<Color> _backgroundItems;
        private IList<string> _skinItems;
        private IList<int> _refreshRateItems;

        private PropertyTransaction<Buttons> _buttons;
        private PropertyTransaction<Color?> _background;
        private PropertyTransaction<string> _skin;
        private PropertyTransaction<int?> _refreshRate;

        private InputKeysModel[] _keys;
        private object _overlay;
        private ICommand _cancelCommand;
        private ICommand _saveCommand;
    }
}
