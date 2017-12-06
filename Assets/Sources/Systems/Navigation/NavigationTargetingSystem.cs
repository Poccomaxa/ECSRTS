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
            NavMeshAgent navAgent = entity.view.gameObject.GetComponent<NavMeshAgent>();
            if (navAgent != null)
            {
                navAgent.destination = entity.navigationTarget.target;
                navAgent.isStopped = false;
            }
            entity.isNavigationAgent = true;
            entity.isNavigationObstacle = false;
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
