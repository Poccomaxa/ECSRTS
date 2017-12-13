using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
public class OwnerComponent : IComponent
{
    public int id;
}

[Game]
[Unique]
public class LocalPlayer : IComponent
{
    public int id;
}