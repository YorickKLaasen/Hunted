using UnityEngine;

public class Movement : MonoBehaviour, IMovement
{
    [SerializeField] private float _movementSpeed = 5f;

    public float movementSpeed => _movementSpeed;

    public void Move(Vector2 pDirection)
    {
        transform.position += (Vector3)(pDirection * _movementSpeed * Time.deltaTime);
    }
}
