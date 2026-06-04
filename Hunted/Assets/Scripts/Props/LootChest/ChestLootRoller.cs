using UnityEngine;

public class ChestLootRoller : MonoBehaviour
{
    private ChestController chest;
    private void Awake()
    {
        chest = GetComponent<ChestController>();
    }
    private void OnEnable()
    {
        chest.OnChestOpened += RollLoot;
    }

    private void OnDisable()
    {
        chest.OnChestOpened -= RollLoot;
    }

    private void RollLoot()
    {
        Debug.Log("Loot gerold");
    }
}
