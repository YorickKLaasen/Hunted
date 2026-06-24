using UnityEngine;

public class PlayerTargetProvider : MonoBehaviour, ITargetProvider
{
    public Transform player;

    public Vector3 GetTargetPosition()
    {
        return player.position;
    }
}
