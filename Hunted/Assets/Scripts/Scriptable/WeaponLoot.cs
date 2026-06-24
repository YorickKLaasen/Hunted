using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/LootEntry")]
public class WeaponLootEntry : ScriptableObject
{
    public WeaponDataSO weapon;
    public int weight;
}
