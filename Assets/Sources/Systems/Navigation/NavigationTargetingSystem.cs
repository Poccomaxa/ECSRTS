using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Entitas;
using System;

public class NavigationTargetingSystem : ReactiveSystem<GameEntity>
{
    public NavigationTargetingSystem(Contexts contexts) : base(contexts.game) { }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            entity.navigationAgent.agent.destination = entity.navigationTarget.target;
            entity.navigationAgent.agent.isStopped = false;
            entity.isNavigationAgentEnabled = true;
            entity.isNavigationObstacleEnabled = false;
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasView && entity.hasNavigationTarget;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.NavigationTarget.Added());
    }
}
