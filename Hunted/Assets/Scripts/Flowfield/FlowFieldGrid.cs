using UnityEngine;

public class FlowFieldGrid
{
    public int width;
    public int height;
    public float cellSize;
    public Vector3 origin;

    public FlowFieldCell[,] cells;

    public FlowFieldGrid(int width, int height, float cellSize, Vector3 origin)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.origin = origin;

        cells = new FlowFieldCell[width, height];
        for (int x = 0; x < width; x++)
            for (int z = 0; z < height; z++)
                cells[x, z] = new FlowFieldCell(new Vector2Int(x, z), GetWorldPosFromCell(x, z));
    }

    public Vector3 GetWorldPosFromCell(int x, int y)
    {
        return origin + new Vector3(x * cellSize + cellSize / 2f, y * cellSize + cellSize / 2f, 0f);
    }

    public Vector2Int GetCellFromWorldPos(Vector3 worldPos)
    {
        Vector3 local = worldPos - origin;
        int x = Mathf.Clamp(Mathf.FloorToInt(local.x / cellSize), 0, width - 1);
        int y = Mathf.Clamp(Mathf.FloorToInt(local.y / cellSize), 0, height - 1);
        return new Vector2Int(x, y);
    }
    public void SetOrigin(Vector3 newOrigin)
    {
        origin = newOrigin;
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                cells[x, y].worldPos = GetWorldPosFromCell(x, y);
            }
        }
    }
    public FlowFieldCell GetCell(Vector2Int gridPos)
    {
        if (gridPos.x < 0 || gridPos.x >= width || gridPos.y < 0 || gridPos.y >= height)
            return null;
        return cells[gridPos.x, gridPos.y];
    }

    public bool IsInBounds(Vector2Int gridPos)
    {
        return gridPos.x >= 0 && gridPos.x < width && gridPos.y >= 0 && gridPos.y < height;
    }

    public static readonly Vector2Int[] Directions = new Vector2Int[]
    {
        new Vector2Int(0, 1),
        new Vector2Int(1, 0),
        new Vector2Int(0, -1),
        new Vector2Int(-1, 0),
        new Vector2Int(1, 1),
        new Vector2Int(1, -1),
        new Vector2Int(-1, 1),
        new Vector2Int(-1, -1),
    };
}

public class FlowFieldCell
{
    public Vector2Int gridIndex;
    public Vector3 worldPos;

    public bool isObstacle;
    public int cost = 1;
    public int bestCost = int.MaxValue;
    public Vector2 direction = Vector2.zero;

    public FlowFieldCell(Vector2Int index, Vector3 worldPos)
    {
        this.gridIndex = index;
        this.worldPos = worldPos;
    }
}
