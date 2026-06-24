using UnityEngine;

// SRP: enige taak is bepalen welke cellen obstakels zijn
public class PhysicsObstacleProvider : IObstacleProvider
{
    public void MarkObstacles(FlowFieldGrid grid, LayerMask obstacleLayer)
    {
        for (int x = 0; x < grid.width; x++)
        {
            for (int z = 0; z < grid.height; z++)
            {
                var cell = grid.cells[x, z];
                bool hit = Physics2D.OverlapBox(
                    new Vector2(cell.worldPos.x, cell.worldPos.y),
                    Vector2.one * (grid.cellSize * 0.9f),
                    0f,
                    obstacleLayer
                );
                cell.isObstacle = hit;
                cell.cost = hit ? int.MaxValue : 1;
            }
        }
    }
}
