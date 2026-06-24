using System.Linq;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private FireMode fireMode;
    //public WeaponDataSO weaponDataSO;
    public WeaponStats stats;

    public WeaponInstance instance;

    private WeaponShoot weaponShoot;
    private IWeaponInput weaponInput;


    private void Awake()
    {
        weaponShoot = GetComponent<WeaponShoot>();
        
    }
    public void Initialize()
    {
        stats.ApplyStats();

        stats.ApplyModifier(RollModifier());

        stats.UpdateVisual();
        //stats.ApplyStats();
    }
    public void InitializePreview()
    {
        stats.ApplyStats();
        stats.ApplyModifier(RollModifier());
        stats.UpdateVisual();
    }
    //public void Initialize()
    //{
    //    if (instance != null) return;

    //    instance = new WeaponInstance();
    //    instance.Init(weaponDataSO);
    //    instance.RollModifier();
    //}
    private WeaponModifier RollModifier()
    {
        WeaponModifier mod;

        if (Random.value > 0.5f)
            mod = WeaponModifier.None;
        else
        {
            WeaponModifier[] mods =
                System.Enum.GetValues(typeof(WeaponModifier))
                .Cast<WeaponModifier>()
                .Where(m => m != WeaponModifier.None)
                .ToArray();

            mod = mods[Random.Range(0, mods.Length)];
        }

        Debug.Log("Rolled modifier: " + mod);
        return mod;
    }
    private void Start()
    {
        switch (fireMode)
        {
            case FireMode.Automatic:
                weaponInput = GetComponent<AutomaticInput>();
                break;

            case FireMode.SemiAutomatic:
                weaponInput = GetComponent<SemiAutomaticInput>();
                break;
        }
    }

    private void Update()
    {
        if (weaponInput.GetShootInput())
        {
            weaponShoot.Shoot();
        }
    }
}
public enum FireMode { SemiAutomatic, Automatic }
