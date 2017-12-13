using UnityEngine.AI;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
public class NavigationDebugComponent : IComponent {
    public float distanceLeft;
    public NavMeshPathStatus status;
}
