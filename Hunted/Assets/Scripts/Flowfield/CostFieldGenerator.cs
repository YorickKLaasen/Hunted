using System.Collections.Generic;
using UnityEngine;

public class CostFieldGenerator : MonoBehaviour, ICostFieldGenerator
{
    public void Generate(FlowFieldGrid grid, Vector2Int targetCell)
    {
        ResetCosts(grid);

        var targetCellObj = grid.GetCell(targetCell);
        if (targetCellObj == null || targetCellObj.isObstacle)
            return;

        Queue<FlowFieldCell> queue = new Queue<FlowFieldCell>();
        targetCellObj.bestCost = 0;
        queue.Enqueue(targetCellObj);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();

            foreach (var dir in FlowFieldGrid.Directions)
            {
                var neighbour = grid.GetCell(current.gridIndex + dir);
                if (neighbour == null || neighbour.isObstacle)
                    continue;

                int stepCost = (dir.x != 0 && dir.y != 0) ? 14 : 10;
                int newCost = current.bestCost + stepCost;

                if (newCost < neighbour.bestCost)
                {
                    neighbour.bestCost = newCost;
                    queue.Enqueue(neighbour);
                }
            }
        }
    }

    private void ResetCosts(FlowFieldGrid grid)
    {
        for (int x = 0; x < grid.width; x++)
        {
            for (int z = 0; z < grid.height; z++)
            {
                var cell = grid.cells[x, z];
                cell.bestCost = cell.isObstacle ? int.MaxValue : int.MaxValue;
            }
        }
    }
}
