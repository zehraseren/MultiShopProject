namespace MS.Cargo.BusinessLayer.Abstract;

public interface IGenericService<T> where T : class
{
    void TInsert(T entity);
    void TUpdate(T entity);
    void TRemove(int id);
    T TGetById(int id);
    List<T> TGetAll();
}
