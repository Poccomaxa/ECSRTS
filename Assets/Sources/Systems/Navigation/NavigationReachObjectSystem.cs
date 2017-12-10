using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;

public class NavigationReachObjectSystem : ReactiveSystem<GameEntity>, ICleanupSystem
{
    private IGroup<GameEntity> reachedObject;
    private GameContext gameContext;
    public NavigationReachObjectSystem(Contexts contexts) : base(contexts.game)
    {
        gameContext = contexts.game;
        reachedObject = gameContext.GetGroup(GameMatcher.NavigationObjectReached);
    }

    public void Cleanup()
    {
        foreach (var entity in reachedObject.GetEntities())
        {
            entity.isNavigationObjectReached = false;
        }
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            entity.isNavigationObjectReached = true;
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        if (entity.hasNavigationApproach && (entity.isNavigationReached || entity.isNavigationRecede) && entity.hasNavigationObjectTarget && entity.hasNavigationAgentRadius)
        {
            GameEntity navigationTarget = gameContext.GetEntityWithId(entity.navigationObjectTarget.entityId);
            if (navigationTarget != null && navigationTarget.hasView)
            {
                Collider[] colliders =  navigationTarget.view.gameObject.GetComponents<Collider>();
                foreach (var collider in colliders)
                {
                    Vector3 closest = collider.ClosestPoint(entity.position.position);
                    if ((closest - entity.position.position).sqrMagnitude < entity.navigationAgentRadius.radius + 0.09)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AnyOf(GameMatcher.NavigationReached, GameMatcher.NavigationRecede));
    }
}
