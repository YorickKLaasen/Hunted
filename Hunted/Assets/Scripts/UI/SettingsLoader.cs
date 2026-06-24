using UnityEngine;

public class SettingsLoader : MonoBehaviour
{
    [SerializeField] GameObject settingsPanel;
    public void LoadSettings()
    {
        //GameObject settingsPanel;
        //settingsPanel.Find("SettingsPanel");
        settingsPanel.SetActive(true);
    }
    public void UnLoadSettings()
    {
        //GameObject settingsPanel;
        //settingsPanel.Find("SettingsPanel");
        settingsPanel.SetActive(false);
    }
}
