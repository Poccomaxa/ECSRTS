using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;

public class NavigationStartMiningSystem : ReactiveSystem<GameEntity> {
    GameContext gameContext;
    public NavigationStartMiningSystem(Contexts contexts) : base(contexts.game)
    {
        gameContext = contexts.game;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            entity.isNavigationAgentEnabled = false;
            entity.isNavigationObstacleEnabled = true;
            entity.isResourceMining = true;
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        if (entity.hasNavigationObjectTarget)
        {
            GameEntity navigationTarget = gameContext.GetEntityWithId(entity.navigationObjectTarget.entityId);
            if (navigationTarget != null && navigationTarget.isResourceSource)
            {
                return true;
            }
        }
        return false;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.NavigationObjectReached.Added());
    }
}
