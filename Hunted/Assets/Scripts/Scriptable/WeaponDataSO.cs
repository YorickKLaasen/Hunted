using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/Weapon Data")]
public class WeaponDataSO : ScriptableObject
{
    public string weaponName;

    public int damage;
    public float critChance;
    public float attackSpeed;

    public Sprite icon;

    public GameObject weaponPrefab;
}
public enum WeaponType
{
    Melee,
    Ranged
}
