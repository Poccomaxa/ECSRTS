using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public enum GameResource
{
    GOLD
}

public class ResourceComponent : IComponent {
    public GameResource resource;
}
