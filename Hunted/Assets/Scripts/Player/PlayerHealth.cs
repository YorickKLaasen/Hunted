using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour, IDamageablePlayer
{
    public float currentPlayerHealth;
    public float currentPlayerLives;
    public float healthRegenPerSecond;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Image healthBarFill;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        currentPlayerLives = playerController.playerStats.playerLives;
        currentPlayerHealth = playerController.playerStats.maxPlayerHealth;
        healthRegenPerSecond = playerController.playerStats.healthRegenPerSecond;
        UpdateHealthBar();
    }
    void UpdateHealthBar()
    {
        if (healthBarFill == null) return;
        healthBarFill.fillAmount = currentPlayerHealth / playerController.playerStats.maxPlayerHealth;
    }
    public void UpdateStats()
    {
        currentPlayerLives = playerController.playerStats.playerLives;
        healthRegenPerSecond = playerController.playerStats.healthRegenPerSecond;
    }
    public void TakeDamage(float damage)
    {
        currentPlayerHealth -= damage;
        //DamageTextPool.Instance.ShowDamage(damage, transform.position + Vector3.up);
        UpdateHealthBar();
        if (currentPlayerHealth <= 0)
        {
            currentPlayerLives--;
            if (currentPlayerLives <= 0)
            {
                PlayerDie();
            }
        }
    }
    public void PlayerDie()
    {
        print("Died");
        GameObject.Find("Canvas").transform.Find("GameOverPanel").gameObject.SetActive(true);
    }
}
