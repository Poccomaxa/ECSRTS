using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;
using System.Linq;

public class SelectionFrameSystem : IExecuteSystem
{
    public ICollector<InputEntity> actionStarted;
    public ICollector<InputEntity> actionEnded;
    public IGroup<InputEntity> frameStarted;
    public InputContext inputContext;
    IGroup<InputEntity> group;

    SelectionFrameSystem(Contexts contexts)
    {
        group = contexts.input.GetGroup(InputMatcher.InputPointerPosition);
        actionStarted = contexts.input.CreateCollector(InputMatcher.InputActionStarted.Added());
        actionEnded = contexts.input.CreateCollector(InputMatcher.InputActionEnded.Added());
        frameStarted = contexts.input.GetGroup(InputMatcher.InputSelectionFrameStart);
        inputContext = contexts.input;
    }

    public void Execute()
    {
        InputEntity pointerPosition = group.Last();
        foreach (var entity in actionStarted.GetCollectedEntities<InputEntity>())
        {
            if (entity.hasInputAction && entity.inputAction.action == InputAction.SELECT)
            {
                InputEntity frameEntity = inputContext.CreateEntity();
                frameEntity.AddInputSelectionFrameStart(pointerPosition.inputPointerPosition.position);
                frameEntity.AddInputSelectionFrameEnd(pointerPosition.inputPointerPosition.position);
            }
        }
        actionStarted.ClearCollectedEntities();

        foreach (var entity in frameStarted.GetEntities())
        {
            entity.ReplaceInputSelectionFrameEnd(pointerPosition.inputPointerPosition.position);
        }

        foreach (var entity in actionEnded.GetCollectedEntities<InputEntity>())
        {
            
        }
        actionEnded.ClearCollectedEntities();
    }
}
