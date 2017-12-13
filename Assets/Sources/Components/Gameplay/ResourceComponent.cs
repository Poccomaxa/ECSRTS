using Entitas;
using Entitas.CodeGeneration.Attributes;

public enum GameResource
{
    GOLD
}

[Game]
public class ResourceComponent : IComponent
{
    public GameResource resource;
}
