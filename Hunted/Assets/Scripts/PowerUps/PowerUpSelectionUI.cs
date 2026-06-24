using System.Collections.Generic;
using UnityEngine;

public class PowerUpSelectionUI : MonoBehaviour
{
    public static PowerUpSelectionUI Instance;

    [Header("Alle beschikbare powerups")]
    public List<PowerUpSO> allPowerups;

    [Header("UI")]
    public GameObject selectionPanel;
    public List<PowerUpCard> cards;

    void Awake() => Instance = this;

    void Start() => selectionPanel.SetActive(false);

    public void Show()
    {
        List<PowerUpSO> rolled = RollPowerups(cards.Count);

        for (int i = 0; i < cards.Count; i++)
            cards[i].Setup(rolled[i]);

        selectionPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Hide()
    {
        selectionPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    private List<PowerUpSO> RollPowerups(int amount)
    {
        List<PowerUpSO> result = new List<PowerUpSO>();

        for (int i = 0; i < amount; i++)
        {
            int index = Random.Range(0, allPowerups.Count);
            result.Add(allPowerups[index]);
        }

        return result;
    }
}
