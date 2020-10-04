namespace BongoCat.DJMAX.Setting.Data
{
    public interface ITransaction
    {
        bool IsChanged { get; }

        void Rollback();

        void Commit();
    }
}
