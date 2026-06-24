using UnityEngine;

public class RedChestModifier : LootModifierBase
{
    [SerializeField] float epicBoost = 1.35f;
    [SerializeField] float legendaryBoost = 1.8f;
    [SerializeField] float mythicalBoost = 1.6f;

    public override int GetModifiedWeight(WeaponLootEntry entry)
    {
        float boost = entry.weapon.weaponRarity switch
        {
            WeaponRarity.Epic => epicBoost,
            WeaponRarity.Legendary => legendaryBoost,
            WeaponRarity.Mythical => mythicalBoost,
            _ => 1f
        };

        return Mathf.CeilToInt(entry.weight * boost);
    }
}
