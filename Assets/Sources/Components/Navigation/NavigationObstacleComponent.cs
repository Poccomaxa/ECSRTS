using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Entitas;
using Entitas.CodeGeneration.Attributes;

public class NavigationObstacleEnabledComponent : IComponent { }


public class NavigationObstacleComponent : IComponent
{
    public NavMeshObstacle obstacle;
}
