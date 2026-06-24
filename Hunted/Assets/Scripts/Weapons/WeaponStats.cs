using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class WeaponStats : MonoBehaviour
{
    public WeaponDataSO baseData;

    public WeaponModifier modifier;
    public GenerateModifier generateModifier;
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

    public SpriteRenderer spriteRenderer;

    public GameObject weaponPrefab;
    public GameObject bulletPrefab;

    public void ApplyStats()
    {
        damage = baseData.damage;
        critChance = baseData.critChance;
        fireRate = baseData.fireRate;
        attackRange = baseData.attackRange;
        noiseValue = baseData.noiseValue;
        magazineSize = baseData.magazineSize;
        reloadTime = baseData.reloadTime;

        weaponName = baseData.weaponName;
        baseName = baseData.weaponName;

        icon = baseData.icon;
        weaponPrefab = baseData.weaponPrefab;
        bulletPrefab = baseData.bulletPrefab;

        modifier = WeaponModifier.None;

        spriteRenderer = GetComponentInChildren<SpriteRenderer>(); //  FIX
        UpdateVisual();
    }
    public void ApplyModifier(WeaponModifier mod)
    {
        modifier = mod;

        if (modifier == WeaponModifier.None)
            return;

        switch (modifier)
        {
            case WeaponModifier.Enhanced:
                generateModifier.GetEnhancedModifier(this);
                break;

            case WeaponModifier.Strong:
                generateModifier.GetStrongModifier(this);
                break;

            case WeaponModifier.Rapid:
                generateModifier.GetRapidModifier(this);
                break;

            case WeaponModifier.Gold:
                //icon = baseData.goldSprite;
                //spriteRenderer.sprite = icon;
                generateModifier.GetGoldModifier(this);
                break;

            case WeaponModifier.Deadly:
                generateModifier.GetDeadlyModifier(this);
                break;

            case WeaponModifier.Enchanted:
                //icon = baseData.enchantedSprite;
                //spriteRenderer.sprite = icon;
                generateModifier.GetEnchantedModifier(this);
                break;

            case WeaponModifier.Explosive:
                generateModifier.GetExplosiveModifier(this);
                break;

            case WeaponModifier.Fiery:
                //icon = baseData.fierySprite;
                //spriteRenderer.sprite = icon;
                generateModifier.GetFieryModifier(this);
                break;

            case WeaponModifier.Heavy:
                generateModifier.GetHeavyModifier(this);
                break;

            case WeaponModifier.Random:
                //icon = baseData.randomSprite;
                //spriteRenderer.sprite = icon;
                generateModifier.GetRandomModifier(this);
                break;

            case WeaponModifier.None:
            default:
                break;
        }

        if (modifier == WeaponModifier.Random)
        {
            weaponName = $"{GetRandomModifierText(modifier.ToString())} {baseName}";
        }
        else
        {
            weaponName = $"{GetColoredModifier(modifier.ToString())} {baseName}";
        }
        UpdateVisual();
    }

    private string GetColoredModifier(string modifier)
    {
        Color color = GetModifierColor(modifier);

        string hex = ColorUtility.ToHtmlStringRGB(color);

        return $"<color=#{hex}>{modifier}</color>";
    }
    private Color GetModifierColor(string modifier)
    {
        return modifier switch
        {
            //WeaponModifier.None => Color.white,

            "Enhanced" => new Color(0.5f, 0.65f, 0.85f),
            "Strong" => new Color(0.8f, 0.2f, 0.2f),
            "Enchanted" => new Color(0.75f, 0.2f, 1f),
            "Rapid" => new Color(0.6f, 0.9f, 0.6f),
            "Gold" => new Color(1f, 0.84f, 0f),
            "Deadly" => new Color(0.1f, 0.1f, 0.1f),
            "Explosive" => new Color(0.6f, 0.3f, 0.2f),
            "Fiery" => new Color(1f, 0.35f, 0f),
            "Heavy" => new Color(0.5f, 0.5f, 0.5f),

            //"Random" => GetRandomModifierText(text),

            _ => Color.white
        };
    }
    private string GetRandomModifierText(string text)
    {
        string result = "";

        for (int i = 0; i < text.Length; i++)
        {
            Color c = Random.ColorHSV(0f, 1f, 1f, 1f, 0.8f, 1f);
            string hex = ColorUtility.ToHtmlStringRGB(c);

            result += $"<color=#{hex}>{text[i]}</color>";
        }

        return result;
    }
    public void UpdateVisual()
    {
        if (spriteRenderer == null)
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        spriteRenderer.sprite = icon;
    }
}
