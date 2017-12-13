using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;

public class SelectionCleanupSystem : ReactiveSystem<GameEntity>
{
    GameContext gameContext;
    public SelectionCleanupSystem(Contexts contexts) : base(contexts.game)
    {
        gameContext = contexts.game;
    }
    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            var childs = gameContext.GetEntitiesWithParentLink(entity.id.value);
            foreach (var child in childs)
            {
                if (child.isUnitSelection)
                {
                    child.isDestroyed = true;
                    break;
                }
            }
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasId;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return new Collector<GameEntity>(
            new [] 
            {
                context.GetGroup(GameMatcher.Selected),
                context.GetGroup(GameMatcher.Destroyed)
            },
            new []
            {
                GroupEvent.Removed,
                GroupEvent.Added
            }
        );
    }
}
