using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;

public class InterruptMiningSystem : ReactiveSystem<GameEntity>
{
    private GameContext gameContext;
    public InterruptMiningSystem(Contexts contexts) : base(contexts.game)
    {
        gameContext = contexts.game;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            entity.isResourceMining = false;

            var childEntities = gameContext.GetEntitiesWithParentLink(entity.id.value);
            foreach (var child in childEntities)
            {
                if (child.hasAction)
                {
                    child.isDestroyed = true;
                }
            }
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasNavigationTarget && entity.isResourceMining;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.NavigationTarget.Added());
    }
}
