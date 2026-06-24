using UnityEngine;
using UnityEngine.UI;

public class WeaponReload : MonoBehaviour
{
    [SerializeField] private WeaponController weaponController;
    [SerializeField] private GunAmmo gunAmmo;
    [SerializeField] Image reloadBar;
    private float reloadDuration;
    private float nextReloadTime;
    private bool isReloading;

    [SerializeField] private KeyCode _reloadKey = KeyCode.R;

    private void Awake()
    {
        if (reloadBar == null)
        {
            GameObject obj = GameObject.Find("ReloadBar");

            if (obj != null)
            {
                reloadBar = obj.GetComponent<Image>();
            }
            else
            {
                Debug.LogWarning("ReloadBar object not found in scene!");
            }
        }
        reloadDuration = weaponController.stats.reloadTime;
        reloadBar.fillAmount = 0;
    }
    private void Update()
    {
        if (Input.GetKeyDown(_reloadKey))
        {
            Reload();
        }

        if (isReloading) 
        {
            UpdateReloadBar();

            if (Time.time >= nextReloadTime)
            {

            FinishReload();
            }
        }
    }
    public void Reload()
    {
        if (isReloading) return;
        if (gunAmmo.currentAmmo == gunAmmo.maxAmmo) return;

        isReloading = true;
        print("reloading....");
        nextReloadTime = Time.time + reloadDuration;
    }
    public void UpdateReloadBar()
    {
        float t = 1f - ((nextReloadTime - Time.time) / reloadDuration);
        reloadBar.fillAmount = t;
    }
    public void FinishReload()
    {
        isReloading = false;
        print("finished reloading");
        gunAmmo.currentAmmo = gunAmmo.maxAmmo;
        reloadBar.fillAmount = 0;
    }
}
