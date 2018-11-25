using Blog.Core.Interface;

namespace Blog.Core.Entities
{
    public abstract class Entity:IEntity<int>
    {
        public int Id { get; set; }
    }
}