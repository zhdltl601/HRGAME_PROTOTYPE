
public interface IEntityComponentRequireInit<in T> : IEntityComponent<T> where T : Entity<T>
{
    public void EntityComponentAwake(T entity);

}
