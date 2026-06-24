using UnityEngine;

public class ChestController : MonoBehaviour
{
    public delegate void ChestFunctions();
    public event ChestFunctions OnChestOpened;
    [SerializeField] InteractButton button;
    [SerializeField] public ChestSO chestSO;
    [SerializeField] bool isOpened;
    private void Update()
    {
        if (button.playerInRange && Input.GetKeyDown(KeyCode.E) && !isOpened)
        {
            isOpened = true;
            OpenChest();
        }
    }
    public void OpenChest()
    {

        Debug.Log("Chest geopend");

        OnChestOpened?.Invoke();

    }
}
