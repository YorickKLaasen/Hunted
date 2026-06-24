using UnityEngine;

public class WeaponDesicionManager : MonoBehaviour
{
    [SerializeField] private AddWeapon addWeapon;
    [SerializeField] private GunManager gunManager;
    [SerializeField] private ShowWeaponStats weaponStats;
    [SerializeField] private GameObject replaceUI;

    private GameObject pendingWeapon;

    public void TryAddWeapon(GameObject newWeapon)
    {
        WeaponController wc = newWeapon.GetComponent<WeaponController>();
        wc.Initialize();
        WeaponType type = wc.stats.baseData.weaponType;

        if (gunManager.HasWeaponType(type))
        {
            pendingWeapon = newWeapon;
            ShowReplaceUI();
        }
        else
        {
            addWeapon.AddNewWeapon(newWeapon);
        }
    }

    public void ConfirmReplace()
    {
        addWeapon.AddNewWeapon(pendingWeapon);

        replaceUI.SetActive(false);
        pendingWeapon = null;
    }

    public void CancelReplace()
    {
        Destroy(pendingWeapon);

        replaceUI.SetActive(false);
        pendingWeapon = null;
    }

    private void ShowReplaceUI()
    {
        //WeaponController newWC = pendingWeapon.GetComponent<WeaponController>();
        //WeaponController oldWC = GetOldWeapon().GetComponent<WeaponController>();

        //newWC.Initialize();

        weaponStats.ShowStats(pendingWeapon, GetOldWeapon());

        replaceUI.SetActive(true);
    }
    public GameObject GetOldWeapon()
    {
        WeaponController wc = pendingWeapon.GetComponent<WeaponController>();
        return gunManager.GetWeaponOfType(wc.stats.baseData.weaponType);
    }
}
