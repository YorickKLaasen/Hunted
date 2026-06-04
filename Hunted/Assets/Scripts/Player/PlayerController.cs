using UnityEngine;

public class PlayerController : MonoBehaviour
{
    IPlayerInput _input;
    IMovement _movement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        _input = GetComponent<KeyboardInput>();
        _input = GetComponent<IPlayerInput>();

        _movement = GetComponent<IMovement>();
        Debug.Log(_input);
        Debug.Log(_movement);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movementInput = _input.GetMovementInput();
        _movement.Move(movementInput);
    }
}
