using UnityEngine;
[DefaultExecutionOrder(-100)]
public abstract class EntityComponentBase<T> : MonoBehaviour, IEntityComponent<T> where T : Entity<T>
{

}