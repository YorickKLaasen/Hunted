using UnityEngine;

public class ChestController : MonoBehaviour
{
    public delegate void ChestFunctions();
    public event ChestFunctions OnChestOpened;
    [SerializeField] InteractButton button;
    private void Update()
    {
        if (button.playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            OpenChest();
        }
    }
    public void OpenChest()
    {

        Debug.Log("Chest geopend");

        OnChestOpened?.Invoke();

    }
}
