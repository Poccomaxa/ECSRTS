using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Ui, Input]
public class CountdownComponent : IComponent
{
    public float timeLeft;
}

[Game, Ui, Input]
public class CountownEndedComponent : IComponent
{
    public float overflowTime;
}
