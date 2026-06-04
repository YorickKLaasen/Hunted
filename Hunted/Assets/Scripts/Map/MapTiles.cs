using UnityEngine;
using UnityEngine.Tilemaps;
[CreateAssetMenu(menuName = "Scriptable Object/BiomeTiles")]
public class MapTiles : ScriptableObject
{
    [Header("Ground")]
    public WeightedTile[] groundTiles;
    public TileBase[] dirtTiles;
    //public TileBase[] groundToShoreTiles;
    [Header("Hill")]
    public TileBase[] hillWallTiles;
    [Header("Shore")]
    public TileBase[] shoreTiles;
    //public TileBase[] shoreCornerTiles;
    //public TileBase[] waterToShoreTiles;
    [Header("Water")]
    //public TileBase[] riverWaterTile;
    //public TileBase shoreWaterTile;
    public WeightedTile[] oceanWaterTiles;

    [System.Serializable]
    public struct WeightedTile
    {
        public TileBase tile;
        public int weight;
    }
}
