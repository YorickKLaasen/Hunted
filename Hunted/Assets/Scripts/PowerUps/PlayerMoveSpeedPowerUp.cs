using UnityEngine;

public class PlayerMoveSpeedPowerUp : MonoBehaviour, IPowerUp
{
    private void Start()
    {
        PowerUp(FindFirstObjectByType<PlayerStats>());
    }
    public void PowerUp(PlayerStats stats)
    {
        //stats = FindFirstObjectByType<PlayerStats>();
        stats.playerSpeed += 1;
        Movement movement = stats.GetComponent<Movement>();
        movement.UpdateSpeed();
    }
}
