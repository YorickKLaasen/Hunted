using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class PowerUpHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [TextArea]
    public string description = "Beschrijving van de powerup";

    [Header("Tooltip UI")]
    public GameObject tooltipPanel;   // Sleep het Tooltip Panel hierin
    public TextMeshProUGUI tooltipText; // Of gebruik Text ipv TextMeshProUGUI

    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltipText.text = description;
        tooltipPanel.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltipPanel.SetActive(false);
    }
}
