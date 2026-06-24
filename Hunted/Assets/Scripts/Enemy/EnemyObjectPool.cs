using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyObjectPool : MonoBehaviour
{
    public static EnemyObjectPool Instance { get; private set; }

    [Header("Container")]
    [Tooltip("Zet hier zelf al pre-built enemies in (inactief), deze worden automatisch in de pool gezet")]
    [SerializeField] private Transform container;

    private readonly Dictionary<string, Queue<IPoolableEnemy>> pools = new();
    private readonly Dictionary<string, EnemyStats> prefabLookup = new();

    private void Awake()
    {
        Instance = this;
        RegisterExistingChildren();
    }

    public void RegisterPrefabs(IEnumerable<EnemyStats> prefabs)
    {
        foreach (var prefab in prefabs)
        {
            if (prefab == null) continue;

            string key = prefab.GetEnemyName(); // <-- hier

            if (!prefabLookup.ContainsKey(key))
                prefabLookup[key] = prefab;

            if (!pools.ContainsKey(key))
                pools[key] = new Queue<IPoolableEnemy>();
        }
    }

    private void RegisterExistingChildren()
    {
        if (container == null) return;

        foreach (Transform child in container)
        {
            if (!child.TryGetComponent<IPoolableEnemy>(out var poolable)) continue;

            string key = poolable.PoolKey;

            if (!pools.ContainsKey(key))
                pools[key] = new Queue<IPoolableEnemy>();

            child.gameObject.SetActive(false);
            pools[key].Enqueue(poolable);

            if (child.TryGetComponent<EnemyStats>(out var stats) && !prefabLookup.ContainsKey(key))
                prefabLookup[key] = stats;
        }
    }

    public IPoolableEnemy GetEnemy(EnemyStats prefab, Vector3 position, Quaternion rotation)
    {
        if (prefab == null)
        {
            Debug.LogError("Prefab is null!");
            return null;
        }

        Debug.Log($"GetEnemy called for {prefab.enemyName} at {position}");

        string key = prefab.GetEnemyName();

        if (!pools.ContainsKey(key))
            pools[key] = new Queue<IPoolableEnemy>();

        if (!prefabLookup.ContainsKey(key))
            prefabLookup[key] = prefab;

        var queue = pools[key];

        IPoolableEnemy instance;
        if (queue.Count > 0)
        {
            instance = queue.Dequeue();
        }
        else
        {
            GameObject go = Instantiate(prefab.gameObject, container);
            instance = go.GetComponent<IPoolableEnemy>();

            if (instance == null)
            {
                Debug.LogError($"Prefab {key} mist een component dat IPoolable implementeert!");
                return null;
            }
        }

        instance.OnSpawn(position, rotation);
        return instance;
    }

    public void ReturnToPool(IPoolableEnemy instance)
    {
        if (instance == null) return;

        instance.OnReturnToPool();

        string key = instance.PoolKey;
        if (!pools.ContainsKey(key))
            pools[key] = new Queue<IPoolableEnemy>();

        pools[key].Enqueue(instance);
    }
}
