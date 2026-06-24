using System.Linq;
using UnityEngine;

public class WeaponInstance
{
    public WeaponDataSO baseData;

    public WeaponModifier modifier;

    public string baseName;
    public string weaponName;
    public Sprite icon;

    public float damage;
    public float critChance;
    public float fireRate;
    public float attackRange;
    public float noiseValue;
    public int magazineSize;
    public float reloadTime;

    public void Init(WeaponDataSO data)
    {
        baseData = data;

        icon = data.icon;

        baseName = data.weaponName;
        weaponName = data.weaponName;

        damage = data.damage;
        critChance = data.critChance;
        fireRate = data.fireRate;
        attackRange = data.attackRange;
        noiseValue = data.noiseValue;
        magazineSize = data.magazineSize;
        reloadTime = data.reloadTime;
    }

    public void RollModifier()
    {
        float chance = 1f;

        if (Random.value > chance)
        {
            modifier = WeaponModifier.None;
            return;
        }

        WeaponModifier[] possible = System.Enum.GetValues(typeof(WeaponModifier))
            .Cast<WeaponModifier>()
            .Where(m => m != WeaponModifier.None)
            .ToArray();

        modifier = possible[Random.Range(0, possible.Length)];

        ApplyModifier();
    }

    private void ApplyModifier()
    {
        switch (modifier)
        {
            case WeaponModifier.Enhanced:
                damage *= 1.15f;
                break;

            case WeaponModifier.Strong:
                damage *= 1.30f;
                break;

            case WeaponModifier.Rapid:
                fireRate *= 1.25f;
                break;

            case WeaponModifier.Deadly:
                critChance += 0.15f;
                break;

            case WeaponModifier.Enchanted:
                attackRange *= 1.2f;
                break;

            case WeaponModifier.Gold:
                break;
        }
    }

    public string GetDisplayName()
    {
        if (modifier == WeaponModifier.None)
            return baseName;

        return $"{modifier} {baseName}";
    }
}
