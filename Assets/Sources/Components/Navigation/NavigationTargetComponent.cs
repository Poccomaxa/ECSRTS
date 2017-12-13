using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
public class NavigationTargetComponent : IComponent
{
    public Vector3 target;
}
