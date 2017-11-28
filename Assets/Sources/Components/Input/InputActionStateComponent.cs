﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

[Input]
public class InputActionStartedComponent : IComponent { }

[Input]
public class InputActionActiveComponent : IComponent { }

[Input]
public class InputActionEndedComponent : IComponent { }

[Input]
public class InputPointerPositionComponent : IComponent
{
    public Vector3 position;
}