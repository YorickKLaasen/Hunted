using UnityEngine;

public class GetLootModifier : MonoBehaviour
{
    [SerializeField] ChestController chestController;
    [SerializeField] public float commonModifier, uncommonModifier, rareModifier, epicModifier, legendaryModifier, mythicalModifier;
    [SerializeField] ChestSO.ChestTier chestRarity;
    //[SerializeField] ChestSO.ChestTier[] boostedRarities;
    float modifier;
    private void Start()
    {
        chestRarity = chestController.chestSO.chestTier;
    }
    public float ModifyChestLoot()
    {
        //float modifier = 1f;

        switch (chestRarity)
        {
            case ChestSO.ChestTier.Common:
                modifier = commonModifier;
                break;

            case ChestSO.ChestTier.Uncommon:
                modifier = uncommonModifier;
                break;

            case ChestSO.ChestTier.Rare:
                modifier = rareModifier;
                break;

            case ChestSO.ChestTier.Epic:
                modifier = epicModifier;
                break;

            case ChestSO.ChestTier.Legendary:
                modifier = legendaryModifier;
                break;

            case ChestSO.ChestTier.Mythical:
                modifier = mythicalModifier;
                break;
        }

        Debug.Log("Loot modifier: " + modifier);
        return modifier;
    }

}
