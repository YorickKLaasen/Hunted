using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] private EnemyData enemyData;

    public string enemyName;
    public int pointValue;
    public float enemyHealth;
    public int enemyHitShield; //voor Armored Enemies
    public float enemyHealthRegen;
    public float enemyDamage;
    public float enemySpeed;
    public float xpYield;

    public EnemyData EnemyData => enemyData;
    public string GetEnemyName() => enemyData != null ? enemyData.enemyName : enemyName;
    public int GetPointValue() => enemyData != null ? enemyData.pointValue : pointValue;
    private void Awake()
    {
        ApplyData();
    }

    public void ApplyData()
    {
        if (enemyData == null) return;

        enemyName = enemyData.enemyName;
        pointValue = enemyData.pointValue;
        enemyHealth = enemyData.enemyHealth;
        enemyHitShield = enemyData.enemyHitShield;
        enemyHealthRegen = enemyData.enemyHealthRegen;


        enemyDamage = enemyData.enemyDamage;
        enemySpeed = enemyData.enemySpeed;
        xpYield = enemyData.xpYield;
    }
}
