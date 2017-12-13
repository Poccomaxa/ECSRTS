using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

public enum InputAction
{
    SELECT,
    ACT,
    BUILD_UNIT,
    CHEAT_CREATE_ENEMY_WARRIOR
}

[Input]
public class InputActionComponent : IComponent
{
    [EntityIndex]
    public InputAction action;
}
