using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    [SerializeField] public List<GameObject> playerWeapons = new List<GameObject>();

    public List<WeaponType> GetWeaponTypes()
    {
        List<WeaponType> types = new List<WeaponType>();

        foreach (GameObject weapon in playerWeapons)
        {
            if (weapon == null) continue;

            WeaponController wc = weapon.GetComponent<WeaponController>();
            if (wc == null || wc.stats == null) continue;

            types.Add(wc.stats.baseData.weaponType);
        }

        return types;
    }
    public GameObject GetWeaponOfType(WeaponType type)
    {
        foreach (GameObject weapon in playerWeapons)
        {
            if (weapon == null) continue;

            WeaponController wc = weapon.GetComponent<WeaponController>();
            if (wc == null || wc.stats == null) continue;

            if (wc.stats.baseData.weaponType == type)
                return weapon;
        }

        return null;
    }
    public bool HasWeaponType(WeaponType type)
    {
        foreach (GameObject weapon in playerWeapons)
        {
            if (weapon == null) continue;

            WeaponController wc = weapon.GetComponent<WeaponController>();
            if (wc == null || wc.stats == null) continue;

            if (wc.stats.baseData.weaponType == type)
                return true;
        }

        return false;
    }
}
