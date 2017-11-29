using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;

public class RectSystem : ReactiveSystem<UiEntity> {
    public RectSystem(Contexts contexts) : base(contexts.ui)
    {

    }

    protected override void Execute(List<UiEntity> entities)
    {
        foreach (var entity in entities)
        {
            RectTransform transform = entity.view.gameObject.GetComponent<RectTransform>();
            transform.anchorMin = new Vector2(0, 0);
            transform.anchorMax = new Vector2(0, 0);
            transform.offsetMin = new Vector2(entity.rect.rect.xMin, entity.rect.rect.yMin);
            transform.offsetMax = new Vector2(entity.rect.rect.xMax, entity.rect.rect.yMax);
        }
    }

    protected override bool Filter(UiEntity entity)
    {
        return entity.hasRect && entity.hasView && entity.view.gameObject.GetComponent<RectTransform>() != null;
    }

    protected override ICollector<UiEntity> GetTrigger(IContext<UiEntity> context)
    {
        return context.CreateCollector(UiMatcher.Rect.Added());
    }
}
