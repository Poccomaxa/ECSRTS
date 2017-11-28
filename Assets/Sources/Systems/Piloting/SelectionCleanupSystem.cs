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
                if (child.isSelection)
                {
                    child.isDestroyed = true;
                }
            }
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return true;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Selected.Removed());
    }
}
