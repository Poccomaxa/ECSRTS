using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Input]
public class TerrainClickComponent : IComponent
{
    public Vector3 position;
    public Vector3 normal;
}
