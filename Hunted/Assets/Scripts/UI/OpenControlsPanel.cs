using UnityEngine;

public class OpenControlsPanel : MonoBehaviour
{
    [SerializeField] GameObject controlsPanel;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            controlsPanel.SetActive(!controlsPanel.activeSelf);
        }
    }
}
