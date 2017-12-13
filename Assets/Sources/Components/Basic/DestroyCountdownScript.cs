using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Ui]
public class DestroyCountdownComponent : IComponent
{
    public float timeToLive;
}
