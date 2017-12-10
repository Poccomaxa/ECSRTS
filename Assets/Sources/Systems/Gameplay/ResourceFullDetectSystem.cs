using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;

class ResourceFullDetectSystem : ReactiveSystem<GameEntity>
{
    public ResourceFullDetectSystem(Contexts contexts) : base(contexts.game)
    {
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            int count = entity.hasResourceQuantity ? entity.resourceQuantity.quantity : 0;
            entity.isResourceFull = count >= entity.resourceLimit.limit;
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasResourceLimit;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.ResourceQuantity.AddedOrRemoved());
    }
}
