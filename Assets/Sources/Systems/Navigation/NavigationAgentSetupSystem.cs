using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Entitas;
using System;

public class NavigationAgentSetupSystem : ReactiveSystem<GameEntity> {
    public NavigationAgentSetupSystem(Contexts contexts) : base(contexts.game){
    }

    protected override void Execute(List<GameEntity> entities) {
        foreach (var entity in entities) {
            if (entity.hasPosition)
            {
                entity.view.gameObject.transform.position = entity.position.position;
            }

            entity.ReplaceNavigationAgent(entity.view.gameObject.GetComponent<NavMeshAgent>());
            if (entity.navigationAgent.agent == null)
            {
                entity.ReplaceNavigationAgent(entity.view.gameObject.AddComponent<NavMeshAgent>());
            }
            entity.ReplaceNavigationAgentRadius(0.75f);
            entity.navigationAgent.agent.enabled = false;
            entity.navigationAgent.agent.updatePosition = false;
            entity.navigationAgent.agent.acceleration = 20;
            entity.navigationAgent.agent.speed = 10;
            entity.navigationAgent.agent.angularSpeed = 360;
        }
    }

    protected override bool Filter(GameEntity entity) {
        return entity.hasView && entity.hasNavigationAgent && entity.view.gameObject.GetComponent<NavMeshAgent>() == null;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
        return context.CreateCollector(GameMatcher.NavigationAgent.Added());
    }
}
