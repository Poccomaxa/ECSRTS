using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Entitas;
using System;

public class NavigationAgentRadiusSetupSystem : ReactiveSystem<GameEntity>
{
    public NavigationAgentRadiusSetupSystem(Contexts contexts) : base(contexts.game)
    {

    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            NavMeshAgent agent = entity.view.gameObject.GetComponent<NavMeshAgent>();
            if (agent)
            {
                agent.radius = entity.navigationAgentRadius.radius;
            }
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isNavigationAgent && entity.hasNavigationAgentRadius && entity.hasView;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.NavigationAgentRadius.Added());
    }
}
