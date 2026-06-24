using UnityEngine;

public class AutomaticInput : MonoBehaviour, IWeaponInput
{
    public bool GetShootInput()
    {
        return Input.GetMouseButton(0);
    }
}
