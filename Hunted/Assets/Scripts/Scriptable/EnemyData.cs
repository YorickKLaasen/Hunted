using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyData", menuName = "WaveSystem/EnemyData")]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public int pointValue;
    public float enemyHealth;
    public int enemyHitShield;
    public float enemyHealthRegen;
    public float enemyDamage;
    public float enemySpeed;
    public float xpYield;
}
