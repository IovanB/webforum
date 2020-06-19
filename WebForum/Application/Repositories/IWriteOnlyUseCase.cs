namespace WebForum.Application.Repositories
{
    public interface IWriteOnlyUseCase <TEntity>
    {
        int Add(TEntity entity);
        int Remove(TEntity entity);
        int Update(TEntity entity);
    }
}
