using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;

public class InputSystem : IExecuteSystem, ICleanupSystem
{
    GameContext context;

    public InputSystem(Contexts context)
    {
        this.context = context.game;
    }

    public void Execute()
    {
        DetectMouseButton(0, InputAction.SELECT);
        DetectMouseButton(1, InputAction.ACT);

        var entity = context.CreateEntity();
        entity.AddInputPointerPosition(Input.mousePosition);        
    }
    
    private void DetectMouseButton(int button, InputAction action)
    {
        GameEntity entity = context.CreateEntity();
        entity.AddInputAction(action);

        if (Input.GetMouseButtonDown(button))
        {
            entity.isInputActionStarted = true;
        }

        if (Input.GetMouseButton(button))
        {
            entity.isInputActionActive = true;
        }

        if (Input.GetMouseButtonUp(button))
        {
            entity.isInputActionEnded = true;
        }
    }

    public void Cleanup()
    {
        var inputActions = context.GetGroup(GameMatcher.InputAction).GetEntities();
        foreach (var entity in inputActions)
        {
            entity.Destroy();
        }
        var pointerPositions = context.GetGroup(GameMatcher.InputPointerPosition).GetEntities();
        foreach (var entity in pointerPositions)
        {
            entity.Destroy();
        }
    }
}
