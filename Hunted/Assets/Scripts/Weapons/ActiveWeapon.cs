using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    //[SerializeField] public GameObject[] weapons;
    [SerializeField] public GunManager weapons;
    [SerializeField] public WeaponInventoryInput inventoryInput;
    public int currentIndex;
    public GameObject CurrentWeapon => weapons.playerWeapons[currentIndex];

    public void EquipWeapon(int index)
    {
        if (index < 0 || index >= weapons.playerWeapons.Count)
            return;

        currentIndex = index;

        for (int i = 0; i < weapons.playerWeapons.Count; i++)
        {
            bool active = (i == currentIndex);
            weapons.playerWeapons[i].SetActive(active);
        }

        Debug.Log("Equipped: " + weapons.playerWeapons[currentIndex].name);
    }
    public void EquipWeaponByType(WeaponType type)
    {
        int foundIndex = -1;

        for (int i = 0; i < weapons.playerWeapons.Count; i++)
        {
            WeaponController wc = weapons.playerWeapons[i].GetComponent<WeaponController>();

            if (wc.stats.baseData.weaponType == type)
            {
                foundIndex = i;
                break;
            }
        }

        if (foundIndex == -1)
        {
            Debug.LogWarning("Weapon type not found: " + type);
            return;
        }

        EquipWeapon(foundIndex);
    }
}
