using UnityEngine;

public class PauseEnemies : MonoBehaviour
{
    private ChestController chest;
    private void Awake()
    {
        chest = GetComponent<ChestController>();
    }
    private void OnEnable()
    {
        chest.OnChestOpened += DisableEnemies;
    }

    private void OnDisable()
    {
        chest.OnChestOpened -= DisableEnemies;
    }

    private void DisableEnemies()
    {
        Debug.Log("Enemies uitgeschakeld");

        // Later:
        // enemyMovement.enabled = false;
        // enemyAttack.enabled = false;
    }
}
