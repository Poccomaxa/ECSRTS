using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;

public class NavigationReactivateAgentSystem : ReactiveSystem<GameEntity>
{
    public NavigationReactivateAgentSystem(Contexts contexts) : base(contexts.game)
    {

    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            entity.isNavigationAgentEnabled = true;
            entity.isNavigationObstacleEnabled = false;
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return !entity.isNavigationAgentEnabled;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.NavigationTarget.Added());
    }
}
