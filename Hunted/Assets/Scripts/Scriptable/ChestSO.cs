using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Chest/Chests SO")]
public class ChestSO : ScriptableObject
{
    public ChestType chestType;
    public ChestTier chestTier;
    public List<WeaponLootEntry> weaponLootTable;
    public List<PowerUpLootEntry> powerUpLootTable;
    public List<ItemLootEntry> itemLootTable;
    public enum ChestType
    {
        Weapon,
        PowerUp,
        Item
    }
    public enum ChestTier
    {
        Common,
        Uncommon,
        Rare,
        Epic,
        Legendary,
        Mythical
    }
}
