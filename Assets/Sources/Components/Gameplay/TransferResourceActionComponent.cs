using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
public class TransferResourceAction : IComponent
{
    public int fromEntityId;
    public int toEntityId;
    public int amount;	
}
