using UnityEngine;

// Genereert obstakeldata voor de grid
public interface IObstacleProvider
{
    void MarkObstacles(FlowFieldGrid grid, LayerMask obstacleLayer);
}

// Berekent costfield vanaf een doelcel
public interface ICostFieldGenerator
{
    void Generate(FlowFieldGrid grid, Vector2Int targetCell);
}

// Berekent richtingen op basis van costfield
public interface IFlowFieldGenerator
{
    void Generate(FlowFieldGrid grid);
}

// Levert de target-positie (bv. player)
public interface ITargetProvider
{
    Vector3 GetTargetPosition();
}

// Geeft bewegingsrichting voor een wereldpositie
public interface IFlowFieldReader
{
    Vector2 GetDirectionAt(Vector3 worldPos);
}
