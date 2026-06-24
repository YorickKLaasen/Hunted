using UnityEngine;
[CreateAssetMenu(menuName = "PowerUp/PowerUp SO")]
public class PowerUpSO : ScriptableObject
{
    public string powerUpName;
    public Sprite powerUpSprite;
    [TextArea] public string powerUpDescription;
    public GameObject prefab;
}
