using UnityEngine;

public class FlowFieldGenerator : MonoBehaviour, IFlowFieldGenerator
{
    public void Generate(FlowFieldGrid grid)
    {
        for (int x = 0; x < grid.width; x++)
        {
            for (int z = 0; z < grid.height; z++)
            {
                var cell = grid.cells[x, z];

                if (cell.isObstacle || cell.bestCost == int.MaxValue)
                {
                    cell.direction = Vector2.zero;
                    continue;
                }

                if (cell.bestCost == 0)
                {
                    cell.direction = Vector2.zero;
                    continue;
                }

                int bestCost = cell.bestCost;
                Vector2Int bestDir = Vector2Int.zero;

                foreach (var dir in FlowFieldGrid.Directions)
                {
                    var neighbour = grid.GetCell(cell.gridIndex + dir);
                    if (neighbour == null || neighbour.isObstacle)
                        continue;

                    if (neighbour.bestCost < bestCost)
                    {
                        bestCost = neighbour.bestCost;
                        bestDir = dir;
                    }
                }

                cell.direction = new Vector2(bestDir.x, bestDir.y).normalized;
            }
        }
    }
}
