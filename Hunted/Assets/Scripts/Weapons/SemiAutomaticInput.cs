using UnityEngine;

public class SemiAutomaticInput : MonoBehaviour, IWeaponInput
{
    public bool GetShootInput()
    {
        return Input.GetMouseButtonDown(0);
    }
}
