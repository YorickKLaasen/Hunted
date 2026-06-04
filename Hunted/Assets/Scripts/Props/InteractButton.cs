using UnityEngine;
using UnityEngine.InputSystem;

public class InteractButton : MonoBehaviour
{
    [SerializeField] private GameObject button;
    [SerializeField] private Vector3 enlargedScale = new Vector3(1.5f, 1.5f, 1f);
    [SerializeField] private Vector3 normalScale = Vector3.one;
    [SerializeField] private float scaleSpeed = 5f;

    private bool shouldEnlarge;
    public bool playerInRange;

    private int playerLayer;

    private void Start()
    {
        playerLayer = LayerMask.NameToLayer("Player");
    }

    private void Update()
    {
        EnlargeButton();
    }

    private void EnlargeButton()
    {
        if (button == null) return;

        Vector3 targetScale = shouldEnlarge ? enlargedScale : normalScale;

        button.transform.localScale = Vector3.Lerp(
            button.transform.localScale,
            targetScale,
            Time.deltaTime * scaleSpeed
        );
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == playerLayer)
        {
            Debug.Log("Player entered trigger");
            shouldEnlarge = true;
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == playerLayer)
        {
            Debug.Log("Player exited trigger");
            shouldEnlarge = false;
            playerInRange = false;
        }
    }
}
