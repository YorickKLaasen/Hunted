using System.Collections.Generic;
using UnityEngine;

public class DamageTextPool : MonoBehaviour
{
    public static DamageTextPool Instance { get; private set; }

    [Header("Setup")]
    [SerializeField] private DamageText damageTextPrefab;
    [SerializeField] private int poolSize = 100;

    [Header("Container")]
    [SerializeField] private Transform container; // <-- parent object
    [SerializeField] private List<DamageText> preplacedTexts;
    private readonly Queue<DamageText> pool = new();

    private void Awake()
    {
        Instance = this;

        if (container == null)
            container = transform;

        // 1. eerst handmatige objects toevoegen
        foreach (var text in preplacedTexts)
        {
            text.gameObject.SetActive(false);
            text.transform.SetParent(container);
            pool.Enqueue(text);
        }

        // 2. daarna aanvullen tot poolSize
        for (int i = pool.Count; i < poolSize; i++)
        {
            print("instantiated");
            DamageText text = Instantiate(damageTextPrefab, container);
            text.gameObject.SetActive(false);
            pool.Enqueue(text);
        }
    }

    public void ShowDamage(float damage, Vector3 position)
    {
        if (pool.Count == 0)
        {
            Debug.LogWarning("DamageText pool empty!");
            return;
        }

        DamageText text = pool.Dequeue();

        text.transform.SetParent(container);
        text.transform.position = position;
        text.gameObject.SetActive(true);

        text.Setup(damage);
    }

    public void ReturnToPool(DamageText text)
    {
        text.transform.SetParent(container);
        text.gameObject.SetActive(false);

        pool.Enqueue(text);
    }
}
