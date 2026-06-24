using System.Collections.Generic;
using UnityEngine;

public class ChestLootRoller : MonoBehaviour
{
    private ChestController chest;
    [SerializeField] private WeaponDesicionManager decisionManager;

    // Sleep het juiste modifier script hierop, mag leeg blijven (geen modifier)
    [SerializeField] private LootModifierBase lootModifier;

    private void Awake()
    {
        chest = GetComponent<ChestController>();
        decisionManager = FindFirstObjectByType<WeaponDesicionManager>();
    }

    private void OnEnable() => chest.OnChestOpened += RollLoot;
    private void OnDisable() => chest.OnChestOpened -= RollLoot;

    private void RollLoot()
    {
        var lootTable = chest.chestSO.weaponLootTable;

        if (lootTable == null || lootTable.Count == 0)
        {
            Debug.LogError("WeaponLootTable invalid!");
            return;
        }

        WeaponLootEntry picked = PickWeapon(lootTable);
        Debug.Log($"Gekozen weapon: {picked.weapon.name} | Base weight: {picked.weight} | Modified weight: {GetWeight(picked)}");

        // Instantiate hier zodat TryAddWeapon een echte instantie krijgt
        GameObject instance = Instantiate(picked.weapon.weaponPrefab);
        instance.SetActive(false); // voorkom dat hij zichtbaar spawnt
        decisionManager.TryAddWeapon(instance);
    }

    private WeaponLootEntry PickWeapon(List<WeaponLootEntry> lootTable)
    {
        int totalWeight = 0;
        foreach (var entry in lootTable)
            totalWeight += GetWeight(entry);

        int roll = Random.Range(0, totalWeight);
        int current = 0;

        foreach (var entry in lootTable)
        {
            current += GetWeight(entry);
            if (roll < current) return entry;
        }

        return lootTable[^1]; // fallback
    }

    // Als er geen modifier is, gebruik je gewoon het base weight
    private int GetWeight(WeaponLootEntry entry)
    {
        return lootModifier != null
            ? lootModifier.GetModifiedWeight(entry)
            : entry.weight;
    }
}
