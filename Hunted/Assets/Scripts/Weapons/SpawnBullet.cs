using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    [SerializeField] private WeaponController weaponController;
    [SerializeField] private Transform firePoint;

    private void Start()
    {
        weaponController = GetComponent<WeaponController>();
    }
    public void Spawn()
    {
        GameObject bulletObj = Instantiate(
            weaponController.stats.baseData.bulletPrefab,
            firePoint.position,
            firePoint.rotation);

        Bullet bullet = bulletObj.GetComponent<Bullet>();

        bullet.Initialize(weaponController.stats.damage);
    }
}
