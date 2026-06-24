using UnityEngine;

public class RevivePowerUp : MonoBehaviour, IPowerUp
{
    private void Start()
    {
        PowerUp(FindFirstObjectByType<PlayerStats>());
    }
    public void PowerUp(PlayerStats stats)
    {
        //stats = FindFirstObjectByType<PlayerStats>();
        stats.playerLives++;
        PlayerHealth health = stats.GetComponent<PlayerHealth>();
        health.UpdateStats();
    }
}
