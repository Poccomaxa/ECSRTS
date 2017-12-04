using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Entitas;
using System;

public class NavigationSetupSystem : ReactiveSystem<GameEntity> {
    public NavigationSetupSystem(Contexts contexts) : base(contexts.game){
    }

    protected override void Execute(List<GameEntity> entities) {
        foreach (var entity in entities) {
            NavMeshAgent agent = entity.view.gameObject.GetComponent<NavMeshAgent>();
            if (agent == null)
            {
                agent = entity.view.gameObject.AddComponent<NavMeshAgent>();
            }
            agent.enabled = true;
            agent.updatePosition = false;
            agent.acceleration = 20;
            agent.speed = 10;
            agent.angularSpeed = 360;
            agent.radius = 0.75f;
        }
    }

    protected override bool Filter(GameEntity entity) {
        return entity.hasView && entity.isNavigationAgent && entity.view.gameObject.GetComponent<NavMeshAgent>() == null;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
        return context.CreateCollector(GameMatcher.NavigationAgent.Added());
    }
}
