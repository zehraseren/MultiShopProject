namespace MS.Cargo.DataAccessLayer.Abstract;

public interface IGenericDal<T> where T : class
{
    void Insert(T entity);
    void Update(T entity);
    void Remove(int id);
    T GetById(int id);
    List<T> GetAll();
}
