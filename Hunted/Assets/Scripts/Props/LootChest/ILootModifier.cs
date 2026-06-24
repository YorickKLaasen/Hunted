using UnityEngine;

public interface ILootModifier
{
    int GetModifiedWeight(WeaponLootEntry entry);
}
