using TMPro;
using UnityEngine;

public class AmmoUI : MonoBehaviour
{
    [SerializeField] private ActiveWeapon weaponManager;
    [SerializeField] private TextMeshProUGUI ammoText;

    void Update()
    {
        if (Time.timeScale == 0f) return;
        GunAmmo ammo = weaponManager.CurrentWeapon.GetComponent<GunAmmo>();

        ammoText.text = $"{ammo.currentAmmo}/{ammo.maxAmmo}";
    }
}
