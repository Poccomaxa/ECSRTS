using UnityEngine.AI;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
public class NavigationAgentEnabledComponent : IComponent { }

[Game]
public class NavigationAgentComponent : IComponent
{
    public NavMeshAgent agent;
}

[Game]
public class NavigationAgentRadiusComponent : IComponent
{
    public float radius;
}
