using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
public class DamageActionComponent : IComponent
{
    public int targetId;
    public float damage;
}