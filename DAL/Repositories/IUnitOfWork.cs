namespace DAL.Repositories
{
    public interface IUnitOfWork
    {
        IFilesRepository FilesRepository { get; }
        IUserLimitRepository UserLimitRepository { get; }
        void SaveChanges();
    }
}