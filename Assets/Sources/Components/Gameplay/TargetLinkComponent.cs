using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
public class TargetLinkComponent : IComponent
{
    [EntityIndex]
    public int linkId;
}
