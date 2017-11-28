using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;

public class SelectedHighlightSystem : ReactiveSystem<GameEntity>
{
    public SelectedHighlightSystem(Contexts contexts) : base(contexts.game)
    {

    }
    protected override void Execute(List<GameEntity> entities)
    {
        throw new NotImplementedException();
    }

    protected override bool Filter(GameEntity entity)
    {
        throw new NotImplementedException();
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Asset);
    }
}
