using System.Collections.Generic;
using Entitas;

[Game]
public class DetectProximityComponent : IComponent
{
    public float sqrDistance;
}

[Game]
public class DetectedProximityEntitiesComponent : IComponent
{
    public HashSet<int> entities;
}