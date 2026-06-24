using UnityEngine;

public class Movement : MonoBehaviour, IMovement
{
    [SerializeField] private float _movementSpeed = 5f;
    PlayerController controller;
   // public float movementSpeed => _movementSpeed;
    private void Start()
    {
        controller = GetComponent<PlayerController>();
    }
    public void UpdateSpeed()
    {
        _movementSpeed = controller.playerStats.playerSpeed;
        //movementSpeed = _movementSpeed;
    }

    public void Move(Vector2 pDirection)
    {
        transform.position += (Vector3)(pDirection * _movementSpeed * Time.deltaTime);
    }
}
