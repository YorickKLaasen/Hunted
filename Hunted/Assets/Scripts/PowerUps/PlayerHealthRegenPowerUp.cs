using UnityEngine;

public class PlayerHealthRegenPowerUp : MonoBehaviour,IPowerUp
{
    private void Start()
    {
        PowerUp(FindFirstObjectByType<PlayerStats>());
    }
    public void PowerUp(PlayerStats stats)
    {
        //stats = FindFirstObjectByType<PlayerStats>();
        stats.healthRegenPerSecond = stats.healthRegenPerSecond += .1f;
        PlayerHealth health = stats.GetComponent<PlayerHealth>();
        health.UpdateStats();
    }
}
