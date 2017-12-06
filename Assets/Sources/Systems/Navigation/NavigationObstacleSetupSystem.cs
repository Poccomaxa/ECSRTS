using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Entitas;
using System;

public class NavigationObstacleSetupSystem : ReactiveSystem<GameEntity>
{
    public NavigationObstacleSetupSystem(Contexts contexts) : base (contexts.game)
    {

    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            entity.ReplaceNavigationObstacle(entity.view.gameObject.GetComponent<NavMeshObstacle>());
            if (entity.navigationObstacle.obstacle == null)
            {
                entity.ReplaceNavigationObstacle(entity.view.gameObject.AddComponent<NavMeshObstacle>());
            }
            entity.navigationObstacle.obstacle.enabled = false;
            entity.navigationObstacle.obstacle.carving = true;
            entity.navigationObstacle.obstacle.shape = NavMeshObstacleShape.Capsule;
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasView && entity.hasNavigationObstacle;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.NavigationObstacle.Added());
    }
}
