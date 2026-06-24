using UnityEngine;

public class BasicChestModifier : LootModifierBase
{
    [SerializeField] float uncommonBoost = 1.8f;
    [SerializeField] float rareBoost = 1.2f;

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
