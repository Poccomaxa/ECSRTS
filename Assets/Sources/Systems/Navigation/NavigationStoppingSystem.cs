using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Entitas;
using System;

public class NavigationStoppingSystem : ReactiveSystem<GameEntity>, ICleanupSystem
{
    GameContext gameContext;
    IGroup<GameEntity> stoppingComponents;
    public NavigationStoppingSystem(Contexts contexts) : base(contexts.game)
    {
        stoppingComponents = contexts.game.GetGroup(GameMatcher.AnyOf(GameMatcher.NavigationReached, GameMatcher.NavigationRecede));
        gameContext = contexts.game;
    }

    public void Cleanup()
    {
        foreach (var entity in stoppingComponents.GetEntities())
        {
            entity.isNavigationReached = false;
            entity.isNavigationRecede = false;
        }
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            if (entity.hasNavigationObjectTarget)
            {
                GameEntity navigationTarget = gameContext.GetEntityWithId(entity.navigationObjectTarget.entityId);
                if (navigationTarget != null && navigationTarget.isResourceSource)
                {
                    continue;
                }
            }
            entity.navigationAgent.agent.isStopped = true;
            entity.RemoveNavigationTarget();
            entity.RemoveNavigationApproach();
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasView && (entity.isNavigationReached || entity.isNavigationRecede) && entity.isNavigationAgentEnabled;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AnyOf(GameMatcher.NavigationReached, GameMatcher.NavigationRecede));
    }
}
