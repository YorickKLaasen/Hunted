using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ShowWeaponStats : MonoBehaviour
{
    [Header("RIGHT = CURRENT WEAPON")]
    [SerializeField] Image currentWeaponSprite;
    [SerializeField] TextMeshProUGUI currentWeaponName;
    [SerializeField] TextMeshProUGUI currentDamage;
    [SerializeField] TextMeshProUGUI currentCritChance;
    [SerializeField] TextMeshProUGUI currentFireRate;

    [Header("left = NEW WEAPON")]
    [SerializeField] Image newWeaponSprite;
    [SerializeField] TextMeshProUGUI newWeaponName;
    [SerializeField] TextMeshProUGUI newDamage;
    [SerializeField] TextMeshProUGUI newCritChance;
    [SerializeField] TextMeshProUGUI newFireRate;

    public void ShowStats(GameObject newWeapon, GameObject currentWeapon)
    {
        WeaponController newWC = newWeapon.GetComponent<WeaponController>();
        WeaponController currentWC = currentWeapon.GetComponent<WeaponController>();

        // WeaponStats newS = newWC.stats;
        //WeaponStats currentS = currentWC.stats;
        Debug.Log("NEW WEAPON");
        Debug.Log("Name: " + newWC.stats.weaponName);
        Debug.Log("Damage: " + newWC.stats.damage);
        Debug.Log("Icon: " + newWC.stats.icon);

        Debug.Log("BASEDATA");
        Debug.Log("Name: " + newWC.stats.baseData.weaponName);
        Debug.Log("Damage: " + newWC.stats.baseData.damage);
        // LEFT = CURRENT
        currentDamage.text = $"Damage: {currentWC.stats.damage}";
        currentCritChance.text = $"Crit: {currentWC.stats.critChance}%";
        currentFireRate.text = $"FireRate: {currentWC.stats.fireRate}";
        currentWeaponName.text = currentWC.stats.weaponName;
        currentWeaponSprite.sprite = currentWC.stats.icon;

        // RIGHT = NEW
        newDamage.text = $"Damage: {newWC.stats.damage}";
        newCritChance.text = $"Crit: {newWC.stats.critChance}%";
        newFireRate.text = $"FireRate: {newWC.stats.fireRate}";
        newWeaponName.text = newWC.stats.weaponName;
        newWeaponSprite.sprite = newWC.stats.icon;
    }
}
