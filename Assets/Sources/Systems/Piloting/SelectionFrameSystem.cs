using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;
using System.Linq;

public class SelectionFrameSystem : ReactiveSystem<InputEntity>
{
    public IGroup<InputEntity> frameStarted;
    public InputContext inputContext;
    IGroup<InputEntity> pointerGroup;

    public SelectionFrameSystem(Contexts contexts) : base(contexts.input)
    {
        pointerGroup = contexts.input.GetGroup(InputMatcher.InputPointerPosition);
        frameStarted = contexts.input.GetGroup(InputMatcher.InputSelectionFrameStart);
        inputContext = contexts.input;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.AnyOf(InputMatcher.InputActionStarted,
            InputMatcher.InputActionEnded, InputMatcher.InputActionActive));
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.hasInputAction && entity.inputAction.action == InputAction.SELECT;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        InputEntity pointerPosition = pointerGroup.Last();
        foreach (var entity in entities)
        {
            if (entity.isInputActionStarted)
            {
                InputEntity frameEntity = inputContext.CreateEntity();
                frameEntity.AddInputSelectionFrameStart(pointerPosition.inputPointerPosition.position);
                frameEntity.AddInputSelectionFrameEnd(pointerPosition.inputPointerPosition.position);                
            }

            if (entity.isInputActionEnded)
            {
                foreach (var cleanEntities in frameStarted.GetEntities())
                {
                    if (cleanEntities.hasInputSelectionFrameStart && cleanEntities.hasInputSelectionFrameEnd)
                    {
                        InputEntity selection = inputContext.CreateEntity();
                        selection.AddInputSelectionFrame(RectUtils.CreateFromPoints(cleanEntities.inputSelectionFrameStart.position,
                            cleanEntities.inputSelectionFrameEnd.position));
                        cleanEntities.isDestroyed = true;
                    }
                }
            }
        }

        foreach (var entity in frameStarted.GetEntities())
        {
            entity.ReplaceInputSelectionFrameEnd(pointerPosition.inputPointerPosition.position);
        }
    }
}
