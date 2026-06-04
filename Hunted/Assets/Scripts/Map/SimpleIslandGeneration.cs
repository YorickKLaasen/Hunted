using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SimpleIslandGenerator : MonoBehaviour
{
    public Tilemap groundTilemap;
    public Tilemap waterTilemap;

    [SerializeField] private MapTiles[] mapTileSets;
    private MapTiles currentTiles;

    [Header("Map Size")]
    public int width = 25;
    public int height = 25;

    [Header("Noise Settings")]
    public float noiseScale = 10f;
    public float islandFactor = 2f;
    public float offsetX;
    public float offsetY;

    [ContextMenu("Generate Island")]
    public void GenerateIsland()
    {
        groundTilemap.ClearAllTiles();
        waterTilemap.ClearAllTiles();
        currentTiles = mapTileSets[Random.Range(0, mapTileSets.Length)];

        offsetX = Random.Range(0f, 1000f);
        offsetY = Random.Range(0f, 1000f);
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                float noise = Mathf.PerlinNoise(
                    (x + offsetX) / noiseScale,
                    (y + offsetY) / noiseScale
                );

                float dx = (x / (float)width - 0.5f) * 2f;
                float dy = (y / (float)height - 0.5f) * 2f;

                float distance = Mathf.Sqrt(dx * dx + dy * dy);

                float islandMask = Mathf.Clamp01(1 - distance * islandFactor);

                float finalValue = noise * islandMask;

                Vector3Int pos = new Vector3Int(x, y, 0);

                if (finalValue > 0.05f)
                {
                    groundTilemap.SetTile(pos, GetWeightedGroundTile());
                }
                else
                {
                    waterTilemap.SetTile(pos, GetWeightedWaterTile());
                }
            }
        }

        GenerateShore();
    }
    void GenerateShore()
    {
        bool[,] firstLayer = new bool[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3Int pos = new Vector3Int(x, y, 0);

                if (groundTilemap.HasTile(pos) && HasWaterNeighbor(x, y))
                {
                    firstLayer[x, y] = true;
                }
            }
        }
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (firstLayer[x, y])
                {
                    Vector3Int pos = new Vector3Int(x, y, 0);
                    groundTilemap.SetTile(pos, GetRandomTile(currentTiles.shoreTiles));
                }
            }
        }
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3Int pos = new Vector3Int(x, y, 0);

                if (groundTilemap.HasTile(pos) && !firstLayer[x, y])
                {
                    if (HasShoreNeighbor(x, y, firstLayer))
                    {
                        groundTilemap.SetTile(pos, GetRandomTile(currentTiles.shoreTiles));
                    }
                }
            }
        }
    }
    bool HasShoreNeighbor(int x, int y, bool[,] shoreLayer)
    {
        Vector3Int[] dirs =
        {
        new Vector3Int(1,0,0),
        new Vector3Int(-1,0,0),
        new Vector3Int(0,1,0),
        new Vector3Int(0,-1,0)
    };

        foreach (var dir in dirs)
        {
            int nx = x + dir.x;
            int ny = y + dir.y;

            if (nx >= 0 && nx < width && ny >= 0 && ny < height)
            {
                if (shoreLayer[nx, ny])
                    return true;
            }
        }

        return false;
    }

    bool HasWaterNeighbor(int x, int y)
    {
        Vector3Int[] dirs =
        {
            new Vector3Int(1,0,0),
            new Vector3Int(-1,0,0),
            new Vector3Int(0,1,0),
            new Vector3Int(0,-1,0)
        };

        foreach (var dir in dirs)
        {
            Vector3Int neighbor = new Vector3Int(x, y, 0) + dir;

            if (waterTilemap.HasTile(neighbor))
                return true;
        }

        return false;
    }
    TileBase GetRandomTile(TileBase[] tiles)
    {
        if (tiles == null || tiles.Length == 0) return null;
        return tiles[Random.Range(0, tiles.Length)];
    }

    TileBase GetWeightedGroundTile()
    {
        int totalWeight = 0;

        foreach (var tile in currentTiles.groundTiles)
            totalWeight += tile.weight;

        int rand = Random.Range(0, totalWeight);

        int current = 0;

        foreach (var tile in currentTiles.groundTiles)
        {
            current += tile.weight;

            if (rand < current)
                return tile.tile;
        }

        return currentTiles.groundTiles[0].tile;
    }
    TileBase GetWeightedWaterTile()
    {
        int totalWeight = 0;

        foreach (var tile in currentTiles.oceanWaterTiles)
            totalWeight += tile.weight;

        int rand = Random.Range(0, totalWeight);

        int current = 0;

        foreach (var tile in currentTiles.oceanWaterTiles)
        {
            current += tile.weight;

            if (rand < current)
                return tile.tile;
        }
        return currentTiles.oceanWaterTiles[0].tile;
    }
}
