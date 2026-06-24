using UnityEngine;

public class GunAmmo : MonoBehaviour
{
    [SerializeField] private WeaponController weaponController;
    [SerializeField] public int maxAmmo;
    [SerializeField] public int currentAmmo;

    private void Awake()
    {
        maxAmmo = weaponController.stats.magazineSize;
        currentAmmo = maxAmmo;
    }

    public void NewAmmo()
    {
        currentAmmo--;
    }
}
