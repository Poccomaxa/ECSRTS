using UnityEngine.AI;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
public class NavigationObstacleEnabledComponent : IComponent { }

[Game]
public class NavigationObstacleComponent : IComponent
{
    public NavMeshObstacle obstacle;
}
