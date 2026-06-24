using UnityEngine;

public class PlayerXP : MonoBehaviour, IXPReceiver
{
    public static PlayerXP Instance { get; private set; }

    public float currentXP { get; private set; }
    public float xpToNextLevel { get; private set; }
    public int currentLevel { get; private set; } = 1;

    [SerializeField] private float xpMultiplier = 1.3f;

    void Awake() => Instance = this;

    void Start() => xpToNextLevel = 10f;

    public void GainXP(float amount)
    {
        currentXP += amount;

        if (currentXP >= xpToNextLevel)
            LevelUp();
    }

    void LevelUp()
    {
        currentXP -= xpToNextLevel;
        currentLevel++;
        xpToNextLevel *= xpMultiplier;
        PowerUpSelectionUI.Instance.Show();
        Debug.Log($"Level Up! Nu level {currentLevel}");
    }
}
