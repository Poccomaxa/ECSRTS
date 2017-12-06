using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Entitas;
using System;

public class NavigationAgentCleanupSystem : ReactiveSystem<GameEntity> {
    public NavigationAgentCleanupSystem(Contexts contexts) : base(contexts.game)
    {

    }
    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            NavMeshAgent agent = entity.view.gameObject.GetComponent<NavMeshAgent>();
            if (agent != null)
            {
                agent.enabled = false;
            }
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasView && !entity.isNavigationAgent;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.NavigationAgent.Removed());
    }
}
