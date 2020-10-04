using System.Windows.Input;
using BongoCat.DJMAX.Common;

namespace BongoCat.DJMAX.Setting.Models
{
    internal class SettingWindowModel : NotifyModel
    {
        public Buttons SelectedButtons
        {
            get => _selectedButtons;
            set
            {
                _selectedButtons = value;
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
        
        private Buttons _selectedButtons;
        private InputKeysModel[] _keys;
        private object _overlay;
        private ICommand _cancelCommand;
        private ICommand _saveCommand;
    }
}
