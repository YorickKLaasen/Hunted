using System.Collections.Generic;
using UnityEngine;

internal class EnemySpawner
{
    private readonly Transform[] spawnPoints;
    private readonly Transform player;

    public EnemySpawner(Transform[] spawnPoints, Transform player)
    {
        this.spawnPoints = spawnPoints;
        this.player = player;
    }

    public void SpawnAll(List<EnemyStats> prefabs, IFlowFieldReader flowfield)
    {
        if (spawnPoints == null || spawnPoints.Length == 0)
        {
            Debug.LogError("Geen spawnpoints toegewezen!");
            return;
        }

        foreach (var prefab in prefabs)
        {
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            var instance = EnemyObjectPool.Instance.GetEnemy(prefab, spawnPoint.position, Quaternion.identity);

            if (instance is EnemyController controller)
            {
                controller.Initialize(flowfield, player);
            }
        }
    }
}