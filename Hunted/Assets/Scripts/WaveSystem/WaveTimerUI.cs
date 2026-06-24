using TMPro;
using UnityEngine;

public class WaveTimerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI waveText;

    public void UpdateTimer(float secondsLeft, int currentWave)
    {
        int seconds = Mathf.CeilToInt(secondsLeft);
        timerText.text = $"Next Wave In: {seconds}s";
        waveText.text = $"Wave: {currentWave}";
    }
}
