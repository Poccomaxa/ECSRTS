using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
public class RotationComponent : IComponent
{
    public Quaternion rotation;
}
