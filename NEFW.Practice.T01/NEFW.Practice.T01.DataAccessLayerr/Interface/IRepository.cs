namespace NEFW.Practice.T01.DataAccessLayerr.Interface
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        T Add(T entity);
        bool Edit(T entity);
        bool DeleteById(int id);
        IEnumerable<T> GetWithPaging(int pageSize, int pageIndex, string searchString, string orderBy);
    }
}
