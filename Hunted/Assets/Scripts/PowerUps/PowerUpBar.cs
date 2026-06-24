using UnityEngine;
using UnityEngine.UI;
public class PowerUpBar : MonoBehaviour
{
    public static PowerUpBar Instance;

    public GameObject powerupPrefab;
    public Transform iconContainer;

    void Awake()
    {
        Instance = this;
    }

    public void AddPowerup(PowerUpSO data)
    {
        Instantiate(data.prefab, iconContainer);
    }
}
