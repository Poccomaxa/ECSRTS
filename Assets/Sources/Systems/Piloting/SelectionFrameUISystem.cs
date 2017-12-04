using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;

public class SelectionFrameUISystem : ReactiveSystem<InputEntity> {
    UiContext uiContext;
    public SelectionFrameUISystem(Contexts contexts) : base (contexts.input)
    {
        uiContext = contexts.ui;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        foreach (var entity in entities)
        {
            if (entity.hasInputSelectionFrameStart && entity.hasInputSelectionFrameEnd)
            {
                Vector3 sPos = entity.inputSelectionFrameStart.position;
                Vector3 ePos = entity.inputSelectionFrameEnd.position;

                Rect builtRect = RectUtils.CreateFromPoints(sPos, ePos);

                UiEntity rectEntity = uiContext.selectionUiEntity;
                if (rectEntity == null)
                {
                    rectEntity = uiContext.CreateEntity();
                    rectEntity.isSelectionUi = true;
                    rectEntity.AddAsset("Prefabs/SelectionRect");
                }
                rectEntity.ReplaceRect(builtRect);
            }
        }
    }

    protected override bool Filter(InputEntity entity)
    {
        return true;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.AllOf(InputMatcher.InputSelectionFrameStart,
            InputMatcher.InputSelectionFrameEnd));
    }
}
