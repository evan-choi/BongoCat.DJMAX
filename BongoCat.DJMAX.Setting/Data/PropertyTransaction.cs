using System;
using System.Collections.Generic;
using BongoCat.DJMAX.Setting.Models;

namespace BongoCat.DJMAX.Setting.Data
{
    internal sealed class PropertyTransaction<T> : NotifyModel, ITransaction
    {
        public T Value
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged();

                IsChanged = !EqualityComparer<T>.Default.Equals(_getter(), value);
            }
        }

        public bool IsChanged
        {
            get => _changed;
            private set
            {
                if (_changed != value)
                {
                    _changed = value;
                    OnPropertyChanged();
                }
            }
        }

        private T _value;
        private bool _changed;

        private readonly Func<T> _getter;
        private readonly Action<T> _setter;

        public PropertyTransaction(object obj, string propertyName)
        {
            var propertyInfo = obj.GetType().GetProperty(propertyName);
            _getter = (Func<T>)propertyInfo!.GetMethod.CreateDelegate(typeof(Func<T>), obj);
            _setter = (Action<T>)propertyInfo!.SetMethod.CreateDelegate(typeof(Action<T>), obj);

            _value = _getter();
        }

        public void Rollback()
        {
            if (!_changed)
                return;

            _value = _getter();
            IsChanged = false;
        }

        public void Commit()
        {
            if (!_changed)
                return;

            _setter(_value);
            IsChanged = false;
        }
    }
}
