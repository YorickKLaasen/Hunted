using System.Collections.Generic;
using UnityEngine;

public class FireTrail : MonoBehaviour
{
    [SerializeField] private float damage = 0.1f;

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log($"HIT: {other.name} | layer: {other.layer}");
        if (other.TryGetComponent<IDamageable>(out var dmg))
        {
            dmg.TakeDamage(damage);
        }
    }
}
    

