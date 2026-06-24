using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/Weapon Data")]
public class WeaponDataSO : ScriptableObject
{
    public string weaponName;
    public Sprite icon;
    public GameObject weaponPrefab;
    public GameObject bulletPrefab;
    public WeaponType weaponType;
    public WeaponRarity weaponRarity;
    public float damage;
    public float critChance;
    public float fireRate;
    public float attackRange;
    public float noiseValue;
    public int magazineSize;
    public float reloadTime;

    public Sprite goldSprite;
    public Sprite enchantedSprite;
    public Sprite randomSprite;
    public Sprite fierySprite;

    public GameObject explosiveBullet;
    public GameObject fireBullet;
    //public GameObject piercingBullet;
}
public enum WeaponType
{
    Pistol,
    SMG,
    Assault_Rifle,
    Sniper,
    Shotgun,
    LMG,
    Explosive
}
public enum WeaponRarity
{
    Common,
    Uncommon,
    Rare,
    Epic,
    Legendary,
    Mythical
}
