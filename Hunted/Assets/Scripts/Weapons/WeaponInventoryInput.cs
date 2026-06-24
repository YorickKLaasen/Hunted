using UnityEngine;

public class WeaponInventoryInput : MonoBehaviour
{
    [SerializeField] ActiveWeapon activeWeapon;
    private void Start()
    {
        activeWeapon.currentIndex = 0;

        if (activeWeapon.weapons.playerWeapons.Count > 0)
        {
            activeWeapon.EquipWeapon(0);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) activeWeapon.EquipWeaponByType(WeaponType.Pistol);
        if (Input.GetKeyDown(KeyCode.Alpha2)) activeWeapon.EquipWeaponByType(WeaponType.LMG);
        if (Input.GetKeyDown(KeyCode.Alpha3)) activeWeapon.EquipWeaponByType(WeaponType.Sniper);
        if (Input.GetKeyDown(KeyCode.Alpha4)) activeWeapon.EquipWeaponByType(WeaponType.Shotgun);
        if (Input.GetKeyDown(KeyCode.Alpha5)) activeWeapon.EquipWeaponByType(WeaponType.Assault_Rifle);
        if (Input.GetKeyDown(KeyCode.Alpha6)) activeWeapon.EquipWeaponByType(WeaponType.SMG);
        if (Input.GetKeyDown(KeyCode.Alpha7)) activeWeapon.EquipWeaponByType(WeaponType.Explosive);
    }
    public void GetInventoryInput(KeyCode key)
    {
        switch (key)
        {
            case KeyCode.Alpha1:
                activeWeapon.EquipWeapon(0);
                Debug.Log("Weapon 1");
                break;

            case KeyCode.Alpha2:
                activeWeapon.EquipWeapon(1);
                Debug.Log("Weapon 2");
                break;

            case KeyCode.Alpha3:
                activeWeapon.EquipWeapon(2);
                Debug.Log("Weapon 3");
                break;
            case KeyCode.Alpha4:
                activeWeapon.EquipWeapon(3);
                Debug.Log("Weapon 4");
                break;

            case KeyCode.Alpha5:
                activeWeapon.EquipWeapon(4);
                Debug.Log("Weapon 5");
                break;

            case KeyCode.Alpha6:
                activeWeapon.EquipWeapon(5);
                Debug.Log("Weapon 6");
                break;
            case KeyCode.Alpha7:
                activeWeapon.EquipWeapon(6);
                Debug.Log("Weapon 7");
                break;
        }
    }
}