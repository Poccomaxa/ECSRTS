using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;
using UnityEngine.EventSystems;

public class InputSystem : IExecuteSystem, ICleanupSystem
{
    InputContext context;

    public InputSystem(Contexts context)
    {
        this.context = context.input;
    }

    public void Execute()
    {
        DetectMouseButton(0, InputAction.SELECT);
        DetectMouseButton(1, InputAction.ACT);

        if (Input.GetKeyDown(KeyCode.C))
        {
            InputEntity newInput = context.CreateEntity();
            newInput.AddInputAction(InputAction.CHEAT_CREATE_ENEMY_WARRIOR);
        }

        var entity = context.CreateEntity();
        entity.AddInputPointerPosition(Input.mousePosition);        
    }
    
    private void DetectMouseButton(int button, InputAction action)
    {
        InputEntity entity = context.CreateEntity();
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
        var inputActions = context.GetGroup(InputMatcher.InputAction).GetEntities();
        foreach (var entity in inputActions)
        {
            entity.Destroy();
        }
        var pointerPositions = context.GetGroup(InputMatcher.InputPointerPosition).GetEntities();
        foreach (var entity in pointerPositions)
        {
            entity.Destroy();
        }
    }
}
