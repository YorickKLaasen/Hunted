using UnityEngine;

public abstract class LootModifierBase : MonoBehaviour, ILootModifier
{
    public abstract int GetModifiedWeight(WeaponLootEntry entry);
}
