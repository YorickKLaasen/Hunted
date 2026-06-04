using UnityEngine;
//using UnityEngine.InputSystem;
public class KeyboardInput : MonoBehaviour, IPlayerInput
{
    [SerializeField] private KeyCode _forwardKey = KeyCode.W;
    [SerializeField] private KeyCode _leftKey = KeyCode.A;
    [SerializeField] private KeyCode _backwardKey = KeyCode.S;
    [SerializeField] private KeyCode _rightKey = KeyCode.D;
    public Vector2 GetMovementInput()
    {
        Vector2 currentInput = Vector2.zero;
        if (Input.GetKey(_leftKey))
        {
            currentInput.x--;
        }
        if (Input.GetKey(_rightKey))
        {
            currentInput.x++;
        }
        if (Input.GetKey(_forwardKey))
        {
            currentInput.y++;
        }
        if (Input.GetKey(_backwardKey))
        {
            currentInput.y--;
        }
        return currentInput.normalized;
    }
}
