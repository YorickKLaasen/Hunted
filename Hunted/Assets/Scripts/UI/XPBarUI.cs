using UnityEngine;
using UnityEngine.UI;
public class XPBarUI : MonoBehaviour
{
    [SerializeField] private Image xpBarFill;

    void Update()
    {
        if (PlayerXP.Instance == null) return;
        xpBarFill.fillAmount = PlayerXP.Instance.currentXP / PlayerXP.Instance.xpToNextLevel;
    }
}
