using TMPro;
using UnityEngine;

public class TimeAliveTimer : MonoBehaviour
{
    public float timeAlive;
    [SerializeField] TextMeshProUGUI timerText;
    void Update()
    {
        timeAlive += Time.deltaTime;
        timerText.text = GetFormattedTime();
    }
    public string GetFormattedTime()
    {
        int hours = (int)(timeAlive / 3600);
        int minutes = (int)((timeAlive % 3600) / 60);
        int seconds = (int)(timeAlive % 60);
        return $"{hours}:{minutes:00}:{seconds:00}";
    }
}
