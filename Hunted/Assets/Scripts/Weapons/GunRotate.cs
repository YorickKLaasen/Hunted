using UnityEngine;

public class GunRotate : MonoBehaviour
{
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePos - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        Vector3 scale = transform.localScale;

        if (direction.x < 0)
        {
            scale.y = -2f;
        }
        else
        {
            scale.y = 2f;
        }

        transform.localScale = scale;
    }
}
