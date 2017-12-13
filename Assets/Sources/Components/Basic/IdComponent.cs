using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Input, Ui]
public class IdComponent : IComponent
{
    [PrimaryEntityIndex]
    public int value;
}
