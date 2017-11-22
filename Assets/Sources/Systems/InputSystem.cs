using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;

public class InputSystem : IExecuteSystem
{
    GameContext context;

    public InputSystem(Contexts context)
    {
        this.context = context.game;
        this.context.SetInput(InputState.None, InputState.None);
    }

    public void Execute()
    {
        context.input.selection = DetectMouseButton(0);
        context.input.action = DetectMouseButton(1);
    }

    private InputState DetectMouseButton(int button)
    {
        if (Input.GetMouseButtonDown(button))
        {
            return InputState.Down;
        }

        if (Input.GetMouseButton(button))
        {
            return InputState.Pressed;
        }

        if (Input.GetMouseButtonUp(button))
        {
            return InputState.Up;
        }

        return InputState.None;
    }
}
