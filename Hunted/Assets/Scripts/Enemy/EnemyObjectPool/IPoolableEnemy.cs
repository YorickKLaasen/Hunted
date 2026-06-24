using UnityEngine;

public interface IPoolableEnemy
{
    GameObject GameObject { get; }
    string PoolKey { get; }
    void OnSpawn(Vector3 position, Quaternion rotation);
    void OnReturnToPool();
}
