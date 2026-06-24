using System.Collections.Generic;
using UnityEngine;

public class WaveComposer
{
    private readonly EnemyStats[] enemyPrefabs;

    public WaveComposer(EnemyStats[] enemyPrefabs)
    {
        this.enemyPrefabs = enemyPrefabs;
    }

    public List<EnemyStats> ComposeWave(int budget)
    {
        List<EnemyStats> result = new List<EnemyStats>();
        int remaining = budget;
        int safetyCounter = 0;
        const int maxIterations = 1000;

        while (remaining > 0 && safetyCounter < maxIterations)
        {
            safetyCounter++;

            List<EnemyStats> affordable = new List<EnemyStats>();
            foreach (var prefab in enemyPrefabs)
            {
                if (prefab != null && prefab.GetPointValue() > 0 && prefab.GetPointValue() <= remaining)
                    affordable.Add(prefab);
            }

            if (affordable.Count == 0) break;

            EnemyStats chosen = affordable[Random.Range(0, affordable.Count)];
            result.Add(chosen);
            remaining -= chosen.GetPointValue();
        }

        if (safetyCounter >= maxIterations)
            Debug.LogWarning("WaveComposer: max iterations bereikt, mogelijk pointValue 0 op een prefab!");

        return result;
    }
}