namespace Blog.Core.Interface
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}