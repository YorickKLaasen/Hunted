using UnityEngine;

public interface IMovement
{
    float movementSpeed {get; }

    void Move(Vector2 pDirection);
}