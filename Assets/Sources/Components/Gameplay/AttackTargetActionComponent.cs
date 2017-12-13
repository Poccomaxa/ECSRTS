using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
public class AttackTargetActionComponent : IComponent
{
    public int attackerId;
    public int targetId;
}
