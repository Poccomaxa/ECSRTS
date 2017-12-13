using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Unique]
public class PlayerInventoryComponent : IComponent
{
    public Dictionary<GameResource, int> resourceIndex;
}
