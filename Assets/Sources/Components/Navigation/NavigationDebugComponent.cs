using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Entitas;

public class NavigationDebugComponent : IComponent {
    public float distanceLeft;
    public NavMeshPathStatus status;
}
