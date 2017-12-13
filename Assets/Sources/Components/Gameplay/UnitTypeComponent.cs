using Entitas;
using Entitas.CodeGeneration.Attributes;

public enum UnitType
{
    WORKER,
    WARRIOR
}

[Game, Input]
public class UnitTypeComponent : IComponent
{
    public UnitType type;
}