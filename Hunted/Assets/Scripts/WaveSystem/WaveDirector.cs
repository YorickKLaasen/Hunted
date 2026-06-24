using System.Collections.Generic;
using UnityEngine;

public class WaveDirector : MonoBehaviour
{
    [Header("Wave Budget Settings")]
    [SerializeField] private int startBudget = 5;
    [SerializeField] private float difficultyMultiplier = 1.2f;

    [Header("Wave Timer")]
    [SerializeField] private float timeBetweenWaves = 30f;

    [Header("Wave Settings")]
    [SerializeField] private EnemyStats[] enemyPrefabs;
    [SerializeField] private Transform[] spawnPoints;

    [Header("References")]
    [SerializeField] private FlowFieldManager flowfieldManager;
    [SerializeField] private Transform player;
    [SerializeField] private WaveTimerUI waveTimerUI;

    private int currentWave = 0;
    private float timer;
    private WaveBudgetCalculator budgetCalculator;
    private WaveComposer waveComposer;
    private EnemySpawner enemySpawner;

    private void Start()
    {
        budgetCalculator = new WaveBudgetCalculator(startBudget, difficultyMultiplier);
        waveComposer = new WaveComposer(enemyPrefabs);
        enemySpawner = new EnemySpawner(spawnPoints, player);

        EnemyObjectPool.Instance.RegisterPrefabs(enemyPrefabs);

        // Eerste wave direct starten
        StartNextWave();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        float timeLeft = Mathf.Max(0f, timeBetweenWaves - timer);
        waveTimerUI.UpdateTimer(timeLeft, currentWave);

        if (timer >= timeBetweenWaves)
        {
            timer = 0f;
            StartNextWave();
        }
    }

    [ContextMenu("Start Next Wave")]
    public void StartNextWave()
    {
        int budget = budgetCalculator.GetCurrentBudget();
        Debug.Log($"--- STARTING WAVE {currentWave} (Budget: {budget} pnt) ---");

        var enemiesToSpawn = waveComposer.ComposeWave(budget);
        enemySpawner.SpawnAll(enemiesToSpawn, flowfieldManager);

        budgetCalculator.AdvanceToNextWave();
        currentWave++;

        timer = 0f;
    }
}  

