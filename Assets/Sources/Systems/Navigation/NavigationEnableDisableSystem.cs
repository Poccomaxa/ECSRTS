using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;

public class NavigationEnableDisableSystem : ReactiveSystem<GameEntity>
{
    public NavigationEnableDisableSystem(Contexts contexts) : base(contexts.game)
    {

    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            if (entity.hasNavigationObstacle && !entity.isNavigationObstacleEnabled)
            {
                entity.navigationObstacle.obstacle.enabled = false;
            }

            if (entity.hasNavigationAgent && !entity.isNavigationAgentEnabled)
            {
                entity.navigationAgent.agent.enabled = false;
            }

            if (entity.hasNavigationObstacle && entity.isNavigationObstacleEnabled)
            {
                entity.navigationObstacle.obstacle.enabled = true;
            }

            if (entity.hasNavigationAgent && entity.isNavigationAgentEnabled)
            {
                entity.navigationAgent.agent.enabled = true;
            }
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return true;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AnyOf(GameMatcher.NavigationObstacle, GameMatcher.NavigationAgentEnabled));
    }
}
