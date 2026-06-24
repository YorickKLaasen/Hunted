using UnityEngine;

public class PurpleChestModifier : LootModifierBase
{
    [SerializeField] float rareBoost = 2f;
    [SerializeField] float epicBoost = 1.5f;
    [SerializeField] float legendaryBoost = 1.25f;

    public override int GetModifiedWeight(WeaponLootEntry entry)
    {
        float boost = entry.weapon.weaponRarity switch
        {
            WeaponRarity.Rare => rareBoost,
            WeaponRarity.Epic => epicBoost,
            WeaponRarity.Legendary => legendaryBoost,
            _ => 1f
        };

        return Mathf.RoundToInt(entry.weight * boost);
    }
}
