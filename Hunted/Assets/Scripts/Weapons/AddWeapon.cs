using UnityEngine;

public class AddWeapon : MonoBehaviour
{
    [SerializeField] private GunManager gunManager;
    [SerializeField] private WeaponSlotUI weaponSlotUI;
    [SerializeField] private Transform gunsParent;
    public void AddNewWeapon(GameObject weaponPrefab)
    {
        GameObject newWeapon = Instantiate(weaponPrefab);

        WeaponController wc = newWeapon.GetComponent<WeaponController>();
        //wc.Initialize(); //  DIRECT

        newWeapon.SetActive(false);

        // ONLY HERE instance maken
        //wc.instance = new WeaponInstance();
        //wc.instance.Init(wc.weaponDataSO);
        //wc.instance.RollModifier();

        WeaponType type = wc.stats.baseData.weaponType;

        GameObject oldWeapon = gunManager.GetWeaponOfType(type);

        if (oldWeapon != null)
        {
            gunManager.playerWeapons.Remove(oldWeapon);
            Destroy(oldWeapon);
        }

        newWeapon.transform.SetParent(gunsParent);
        newWeapon.transform.localPosition = Vector3.zero;

        gunManager.playerWeapons.Add(newWeapon);

        weaponSlotUI.PlaceWeaponIconSprite();
    }
    public bool HasWeaponType(WeaponType type)
    {
        foreach (GameObject weapon in gunManager.playerWeapons)
        {
            WeaponController wc = weapon.GetComponent<WeaponController>();

            if (wc.stats.baseData.weaponType == type)
                return true;
        }

        return false;
    }
    public GameObject GetWeaponOfType(WeaponType type)
    {
        foreach (GameObject weapon in gunManager.playerWeapons)
        {
            WeaponController wc = weapon.GetComponent<WeaponController>();

            if (wc.stats.baseData.weaponType == type)
                return weapon;
        }

        return null;
    }
}
