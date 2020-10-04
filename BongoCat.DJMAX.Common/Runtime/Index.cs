using System.Runtime.CompilerServices;

namespace System
{
    public readonly struct Index
    {
        public static Index Start => new Index(0);

        public static Index End => new Index(~0);

        public int Value
        {
            get
            {
                if (_value < 0)
                    return ~_value;

                return _value;
            }
        }

        public bool IsFromEnd => _value < 0;

        private readonly int _value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Index(int value, bool fromEnd = false)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            if (fromEnd)
                _value = ~value;
            else
                _value = value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int GetOffset(int length)
        {
            int offset = _value;

            if (IsFromEnd)
                offset += length + 1;

            return offset;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Index FromStart(int value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            return new Index(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Index FromEnd(int value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            return new Index(~value);
        }

        public override bool Equals(object value) => value is Index index && _value == index._value;

        public bool Equals(Index other) => _value == other._value;

        public override int GetHashCode() => _value;

        public static implicit operator Index(int value) => FromStart(value);
    }
}
