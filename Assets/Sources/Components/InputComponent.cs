using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

public enum InputState
{
    None,
    Down,
    Pressed,
    Up
}

[Unique]
public class InputComponent : IComponent {
    public InputState selection = InputState.None;
    public InputState action = InputState.None;
}
