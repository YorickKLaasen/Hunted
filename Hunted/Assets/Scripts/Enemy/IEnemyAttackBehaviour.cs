using UnityEngine;

public interface IEnemyAttackBehaviour
{
    void OnHit(Collider2D collision, float damage);
}