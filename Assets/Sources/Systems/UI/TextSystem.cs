using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;

public class TextSystem : ReactiveSystem<UiEntity>
{
    public TextSystem(Contexts contexts) : base(contexts.ui)
    {
    }

    protected override void Execute(List<UiEntity> entities)
    {
        foreach (var entity in entities)
        {
            entity.textView.textView.text = entity.text.text;
        }
    }

    protected override bool Filter(UiEntity entity)
    {
        return entity.hasTextView && entity.hasText;
    }

    protected override ICollector<UiEntity> GetTrigger(IContext<UiEntity> context)
    {
        return context.CreateCollector(UiMatcher.Text.Added());
    }
}
