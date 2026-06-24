using UnityEngine;

public class GenerateModifier : MonoBehaviour
{
 //   [SerializeField] WeaponStats stats;
    public void GetEnhancedModifier(WeaponStats stats)
    {
        stats.fireRate *= 1.25f;
        stats.damage *= 1.2f;
    }
    public void GetStrongModifier(WeaponStats stats)
    {
        stats.damage *= 2f;
    }
    public void GetEnchantedModifier(WeaponStats stats)
    {
        stats.damage *= 1.1f;
        stats.fireRate *= 1.1f;
        stats.critChance *= 1.1f;

        stats.icon = stats.baseData.enchantedSprite;
        stats.spriteRenderer.sprite = stats.icon;
    }
    public void GetRapidModifier(WeaponStats stats)
    {
        stats.fireRate *= 1.5f;
        stats.magazineSize *= Mathf.RoundToInt(1.3f);
        stats.reloadTime /= 1.65f;
    }
    public void GetGoldModifier(WeaponStats stats)
    {
        stats.icon = stats.baseData.goldSprite;
        stats.spriteRenderer.sprite = stats.icon;

        stats.damage = stats.damage *= 1.8f;
        stats.critChance = stats.critChance *= 1.5f;
        stats.fireRate = stats.fireRate *= 2;
        stats.attackRange = stats.attackRange *= 1.3f;
        stats.noiseValue = stats.noiseValue /= 1.5f;
        stats.magazineSize = stats.magazineSize * Mathf.RoundToInt(1.5f);
        stats.reloadTime = stats.reloadTime /= 1.4f;

    }
    public void GetDeadlyModifier(WeaponStats stats)
    {
        stats.critChance += 20;
        stats.damage *= 1.5f;
    }
    public void GetRandomModifier(WeaponStats stats)
    {

        stats.icon = stats.baseData.randomSprite;
        stats.spriteRenderer.sprite = stats.icon;

        stats.damage = Randomize(stats.damage);
        stats.critChance = Randomize(stats.critChance);
        stats.fireRate = Randomize(stats.fireRate);
        stats.attackRange = Randomize(stats.attackRange);
        stats.noiseValue = Randomize(stats.noiseValue);
        stats.magazineSize = Mathf.RoundToInt(Randomize(stats.magazineSize));
        stats.reloadTime = Randomize(stats.reloadTime);
    }
    public void GetExplosiveModifier(WeaponStats stats)
    {
        stats.damage *= 1.15f;
        stats.bulletPrefab = stats.baseData.explosiveBullet;
    }
    public void GetFieryModifier(WeaponStats stats)
    {
        stats.icon = stats.baseData.fierySprite;
        stats.spriteRenderer.sprite = stats.icon;

        stats.bulletPrefab = stats.baseData.fireBullet;

        stats.damage *= 1.05f;
        stats.reloadTime /= 1.05f;
        
    }
    public void GetHeavyModifier(WeaponStats stats)
    {
        stats.critChance += 5;
        stats.fireRate *= 1.25f;
        stats.magazineSize *= 2;
        stats.reloadTime *= 1.5f;
    }

    private float Randomize(float baseValue)
    {
        float multiplier = Random.Range(0.5f, 1.5f);
        return baseValue * multiplier;
    }
}
