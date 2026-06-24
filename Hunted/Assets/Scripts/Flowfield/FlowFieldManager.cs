using UnityEngine;

// SRP: orchestreert de flow field, delegeert alle logica naar interfaces (DIP)
// OCP: nieuwe algoritmes implementeren = nieuwe klasse die interface implementeert, geen wijziging hier nodig
public class FlowFieldManager : MonoBehaviour, IFlowFieldReader
{
    [Header("Grid Settings")]
    public int gridWidth = 30;
    public int gridHeight = 30;
    public float cellSize = 1f;
    public Vector3 gridOrigin = Vector3.zero;
    [SerializeField] public LayerMask obstacleLayer;

    [Header("Update")]
    public float updateInterval = 0.2f;

    public FlowFieldGrid Grid { get; private set; }

    private IObstacleProvider obstacleProvider;
    private ICostFieldGenerator costFieldGenerator;
    private IFlowFieldGenerator flowFieldGenerator;
    private ITargetProvider targetProvider;

    private float timer;

    void Awake()
    {
        Grid = new FlowFieldGrid(gridWidth, gridHeight, cellSize, gridOrigin);

        // Dependency injection: implementaties kunnen later eenvoudig vervangen worden
        obstacleProvider = new PhysicsObstacleProvider();
        costFieldGenerator = new CostFieldGenerator();
        flowFieldGenerator = new FlowFieldGenerator();
        targetProvider = GetComponent<ITargetProvider>();

        obstacleProvider.MarkObstacles(Grid, obstacleLayer);
        RecalculateFlowField();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= updateInterval)
        {
            timer = 0f;
            RecalculateFlowField();
        }
    }

    public void RecalculateFlowField()
    {
        if (targetProvider == null) return;

        Vector3 playerPos = targetProvider.GetTargetPosition();
        Debug.Log($"Recalculating, player at {playerPos}, new origin: {playerPos - new Vector3(gridWidth * cellSize / 2f, gridHeight * cellSize / 2f, 0f)}");
        Grid.SetOrigin(playerPos - new Vector3(gridWidth * cellSize / 2f, gridHeight * cellSize / 2f, 0f));

        //Grid.origin = playerPos - new Vector3(
        //    gridWidth * cellSize / 2f,
        //    gridHeight * cellSize / 2f,
        //    0f
        //);

        obstacleProvider.MarkObstacles(Grid, obstacleLayer);

        Vector2Int targetCell = Grid.GetCellFromWorldPos(playerPos);
        costFieldGenerator.Generate(Grid, targetCell);
        flowFieldGenerator.Generate(Grid);
        //if (targetProvider == null) return;

        //Vector2Int targetCell = Grid.GetCellFromWorldPos(targetProvider.GetTargetPosition());
        //costFieldGenerator.Generate(Grid, targetCell);
        //flowFieldGenerator.Generate(Grid);
    }

    public Vector2 GetDirectionAt(Vector3 worldPos)
    {
        Vector2Int cellIndex = Grid.GetCellFromWorldPos(worldPos);
        var cell = Grid.GetCell(cellIndex);

        if (cell == null) return Vector2.zero;

        if (cell.direction != Vector2.zero || cell.bestCost == 0)
            return cell.direction;

        // Cell heeft geen geldige richting (bv. obstacle) — zoek beste buur
        int bestCost = int.MaxValue;
        Vector2 bestDir = Vector2.zero;

        foreach (var dir in FlowFieldGrid.Directions)
        {
            var neighbour = Grid.GetCell(cellIndex + dir);
            if (neighbour == null || neighbour.isObstacle) continue;

            if (neighbour.bestCost < bestCost)
            {
                bestCost = neighbour.bestCost;
                bestDir = new Vector2(dir.x, dir.y).normalized;
            }
        }

        return bestDir;
    }
    void OnDrawGizmosSelected()
    {
        Vector3 playerPos = transform.position; // of targetProvider als al gezet
        Vector3 size = new Vector3(gridWidth * cellSize, gridHeight * cellSize, 0.1f);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(playerPos, size);
    }
    void OnDrawGizmos()
    {
        if (Grid == null) return;

        for (int x = 0; x < Grid.width; x++)
        {
            for (int z = 0; z < Grid.height; z++)
            {
                var cell = Grid.cells[x, z];
                if (cell.isObstacle)
                {
                    Gizmos.color = Color.red;
                    Gizmos.DrawWireCube(cell.worldPos, Vector3.one * cellSize * 0.9f);
                    continue;
                }

                Gizmos.color = Color.white;
                Gizmos.DrawWireCube(cell.worldPos, Vector3.one * cellSize * 0.95f);

                if (cell.direction != Vector2.zero)
                {
                    Vector3 dir3 = new Vector3(cell.direction.x, cell.direction.y, 0);
                    Gizmos.color = Color.cyan;
                    Gizmos.DrawLine(cell.worldPos, cell.worldPos + dir3 * (cellSize * 0.4f));
                }
            }
        }
    }
}
