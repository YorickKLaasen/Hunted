using UnityEngine;

public class WeaponShoot : MonoBehaviour
{
    [SerializeField] private WeaponController weaponController;
    [SerializeField] private GunAmmo gunAmmo;
    [SerializeField] private Transform firePoint;

    float finalDamage;
    bool isCrit;
    private float nextShootTime;

    private void Awake()
    {
        weaponController = GetComponent<WeaponController>();
    }

    public bool CanShoot()
    {
        return Time.time >= nextShootTime;
    }

    public void Shoot()
    {
        if (!CanShoot()) return;

        if (gunAmmo.currentAmmo < 1) return;

        nextShootTime = Time.time + (1f / weaponController.stats.fireRate);

        ShootBullets();

        gunAmmo.NewAmmo();
    }
    private void ShootBullets()
    {
        int pelletCount = 1; 
        if (weaponController.stats.baseData.weaponType == WeaponType.Shotgun) 
        { 
            pelletCount = 6; 
        } 
        float spread = 5f; 
        for (int i = 0; i < pelletCount; i++) 
        { 
            float angle = Random.Range(-spread, spread); Quaternion rot = firePoint.rotation * Quaternion.Euler(0, 0, angle);

            GameObject bulletObj = Instantiate( weaponController.stats.bulletPrefab, firePoint.position, rot);


            Bullet bullet = bulletObj.GetComponent<Bullet>();

            float damage = weaponController.stats.damage;

            bool isCrit = CheckForCrit();
            if (isCrit)
            {
                damage *= 2f;
            }
            bullet.Initialize(damage); 
        } 
    }
    private bool CheckForCrit()
    {
        float roll = Random.Range(0f, 100f);
        return roll <= weaponController.stats.critChance;
    }
}

public enum ShootPattern
{
    Single,
    Shotgun
}