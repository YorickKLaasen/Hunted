using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("PlayerHealthStats")]
    public float maxPlayerHealth;
    //public float currentPlayerHealth;
    public float healthRegenPerSecond;
    public int playerLives;
    [Header("ArmorStats")]
    public float playerArmor;


    [Header("SpeedStats")]
    public float playerSpeed;


}
