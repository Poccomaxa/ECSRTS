using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;

public class SelectionFrameUiCleanupSystem : ReactiveSystem<InputEntity>
{
    UiContext uiContext;
    public SelectionFrameUiCleanupSystem(Contexts contexts) : base(contexts.input)
    {
        uiContext = contexts.ui;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        if (entities.Count > 0)
        {
            uiContext.selectionUiEntity.isDestroyed = true;
        }
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.hasInputSelectionFrameStart && entity.hasInputSelectionFrameEnd && entity.isDestroyed;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.AllOf(InputMatcher.InputSelectionFrameEnd,
            InputMatcher.InputSelectionFrameStart, InputMatcher.Destroyed));
    }
}
