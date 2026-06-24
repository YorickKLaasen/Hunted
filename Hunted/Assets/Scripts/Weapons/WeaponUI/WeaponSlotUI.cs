using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeaponSlotUI : MonoBehaviour
{

    [SerializeField] private GunManager gunManager;
    [SerializeField] private List<WeaponSlotUIEntry> slots;
    private void Start()
    {
        PlaceWeaponIconSprite();
    }
    public void PlaceWeaponIconSprite()
    {
        foreach (GameObject weapon in gunManager.playerWeapons)
        {
            WeaponController weaponController = weapon.GetComponent<WeaponController>();

            WeaponType type = weaponController.stats.baseData.weaponType;
            Sprite icon = weaponController.stats.icon;
            string weaponName = weaponController.stats.weaponName;


            WeaponSlotUIEntry slot = slots.Find(s => s.weaponType == type);

            if (slot != null)
            {
                slot.iconImage.sprite = icon;
                slot.iconImage.enabled = true;

                slot.weaponNameText.text = weaponName;
                slot.weaponNameText.gameObject.SetActive(true);
            }
        }
    }

    public void CheckIfSlotFull()
    {
        //check via GunManager.GetWeaponTypes welke weapontypes nog niet bestaan.
        //checkt
    }
}
[System.Serializable]
public class WeaponSlotUIEntry
{
    public WeaponType weaponType;
    public UnityEngine.UI.Image iconImage;
    public TextMeshProUGUI weaponNameText;
}

