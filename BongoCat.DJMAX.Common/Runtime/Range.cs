using System.Runtime.CompilerServices;

namespace System
{
    public readonly struct Range
    {
        public static Range StartAt(Index start) => new Range(start, Index.End);

        public static Range EndAt(Index end) => new Range(Index.Start, end);

        public static Range All => new Range(Index.Start, Index.End);

        public Index Start { get; }

        public Index End { get; }

        public Range(Index start, Index end)
        {
            Start = start;
            End = end;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public OffsetAndLengthRecord GetOffsetAndLength(int length)
        {
            int start;
            var startIndex = Start;

            if (startIndex.IsFromEnd)
                start = length - startIndex.Value;
            else
                start = startIndex.Value;

            int end;
            var endIndex = End;

            if (endIndex.IsFromEnd)
                end = length - endIndex.Value;
            else
                end = endIndex.Value;

            if ((uint)end > (uint)length || (uint)start > (uint)end)
                throw new ArgumentOutOfRangeException(nameof(length));

            return new OffsetAndLengthRecord(start, end - start);
        }

        public readonly struct OffsetAndLengthRecord
        {
            public readonly int Offset;
            public readonly int Length;

            public OffsetAndLengthRecord(int offset, int length)
            {
                Offset = offset;
                Length = length;
            }
        }
    }
}
