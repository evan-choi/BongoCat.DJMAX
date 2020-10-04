using BongoCat.DJMAX.Common;
using BongoCat.DJMAX.Setting.Data;
using BongoCat.DJMAX.Setting.Input;

namespace BongoCat.DJMAX.Setting.Models
{
    internal sealed class InputKeysModel : NotifyModel
    {
        public string Action { get; }

        public PropertyTransaction<InputKeys> Keyboard { get; }

        public PropertyTransaction<InputKeys> Controller { get; }

        public ActionCommand<InputKeysModel> KeyboardCommand
        {
            get => _keyboardCommand;
            set
            {
                _keyboardCommand = value;
                OnPropertyChanged();
            }
        }

        public ActionCommand<InputKeysModel> ControllerCommand
        {
            get => _controllerCommand;
            set
            {
                _controllerCommand = value;
                OnPropertyChanged();
            }
        }

        private ActionCommand<InputKeysModel> _keyboardCommand;
        private ActionCommand<InputKeysModel> _controllerCommand;

        public InputKeysModel(string action, PropertyTransaction<InputKeys> keyboard, PropertyTransaction<InputKeys> controller)
        {
            Action = action;
            Keyboard = keyboard;
            Controller = controller;
        }
    }
}
