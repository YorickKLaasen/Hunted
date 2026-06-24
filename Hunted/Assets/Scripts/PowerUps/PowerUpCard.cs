using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class PowerUpCard : MonoBehaviour
{
    public Image iconImage;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;
    public Button button;

    private PowerUpSO data;

    public void Setup(PowerUpSO powerupData)
    {
        data = powerupData;
        iconImage.sprite = data.powerUpSprite;
        nameText.text = data.powerUpName;
        descriptionText.text = data.powerUpDescription;

        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => OnCardClicked());
    }

    private void OnCardClicked()
    {
        PowerUpBar.Instance.AddPowerup(data);
        PowerUpSelectionUI.Instance.Hide();
    }
}
