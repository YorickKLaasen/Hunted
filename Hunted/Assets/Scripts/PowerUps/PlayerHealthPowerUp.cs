using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class PlayerHealthPowerUp : MonoBehaviour, IPowerUp
{
    private void Start()
    {
        PowerUp(FindFirstObjectByType<PlayerStats>());
    }
    public void PowerUp(PlayerStats stats)
    {
        //stats = FindFirstObjectByType<PlayerStats>();
        stats.maxPlayerHealth = Mathf.CeilToInt(stats.maxPlayerHealth * 1.1f);
        //PlayerHealth health = stats.GetComponent<PlayerHealth>();
        //health.UpdateStats();
    }
}
