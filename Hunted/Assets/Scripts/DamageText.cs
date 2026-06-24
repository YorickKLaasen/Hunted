using TMPro;
using UnityEngine;

public class DamageText : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float lifeTime = 1f;

    private TextMeshPro textMesh;
    private float timer;

    private void Awake()
    {
        textMesh = GetComponent<TextMeshPro>();
    }

    public void Setup(float damage)
    {
        textMesh.text = damage.ToString("F2");
        SetColorByDamage(damage);
        timer = lifeTime;
    }
    private void SetColorByDamage(float damage)
    {
        float normalized = Mathf.InverseLerp(0f, 100f, damage);

        Color color = Color.Lerp(Color.yellow, Color.red, normalized);

        textMesh.color = color;
    }

    private void Update()
    {
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;

        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            DamageTextPool.Instance.ReturnToPool(this);
        }
    }
}