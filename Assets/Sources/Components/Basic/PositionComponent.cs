using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
public class PositionComponent : IComponent
{
    public Vector3 position;
}
