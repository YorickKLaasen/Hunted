using UnityEngine;

public class BlueChestModifier : LootModifierBase
{
    [SerializeField] float uncommonBoost = 2.05f;
    [SerializeField] float rareBoost = 1.6f;
    [SerializeField] float epicBoost = 1.25f;
    [SerializeField] float legendaryBoost = 1.1f;

    public override int GetModifiedWeight(WeaponLootEntry entry)
    {
        float boost = entry.weapon.weaponRarity switch
        {
            WeaponRarity.Uncommon => uncommonBoost,
            WeaponRarity.Rare => rareBoost,
            WeaponRarity.Epic => epicBoost,
            WeaponRarity.Legendary => legendaryBoost,
            _ => 1f
        };

        return Mathf.RoundToInt(entry.weight * boost);
    }
}
