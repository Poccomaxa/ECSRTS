using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class InputActionStartedComponent : IComponent { }

public class InputActionActiveComponent : IComponent { }

public class InputActionEndedComponent : IComponent { }

public class InputPointerPositionComponent : IComponent
{
    public Vector3 position;
}
