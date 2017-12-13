using Entitas;
using Entitas.CodeGeneration.Attributes;

[Ui]
public class PlayerResourceComponent : IComponent
{
    [EntityIndex]
    public GameResource resource;
}
