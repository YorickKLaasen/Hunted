using UnityEngine;

public class GreenChestModifier : LootModifierBase
{
    [SerializeField] float uncommonBoost = 2.25f;
    [SerializeField] float rareBoost = 1.5f;

    public override int GetModifiedWeight(WeaponLootEntry entry)
    {
        float boost = entry.weapon.weaponRarity switch
        {
            WeaponRarity.Uncommon => uncommonBoost,
            WeaponRarity.Rare => rareBoost,
            _ => 1f
        };

        return Mathf.RoundToInt(entry.weight * boost);
    }
}
