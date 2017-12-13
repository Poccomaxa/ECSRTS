using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
public class NavigationApproachComponent : IComponent
{
    public float remainingDistance;
    public float timeInPath;
}
