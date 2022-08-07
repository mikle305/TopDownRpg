public interface IStorage<T> where T: new()
{
    public void Save(T data);

    public T Load();
}