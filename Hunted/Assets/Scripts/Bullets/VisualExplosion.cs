using UnityEngine;

public class VisualExplosion : MonoBehaviour
{
    [SerializeField] private float lifeTime = 2f;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }
}
