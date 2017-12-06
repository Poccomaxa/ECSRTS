using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Entitas;
using System;

public class NavigationObstacleCleanupSystem : ReactiveSystem<GameEntity>
{
    public NavigationObstacleCleanupSystem(Contexts contexts) : base(contexts.game)
    {

    }
    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            NavMeshObstacle obstacle = entity.view.gameObject.GetComponent<NavMeshObstacle>();
            if (obstacle != null)
            {
                obstacle.enabled = false;
            }
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasView && !entity.isNavigationObstacle;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.NavigationObstacle.Removed());
    }
}
