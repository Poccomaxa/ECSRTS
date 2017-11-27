using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Entitas;
using System;

public class NavigationSystem : IExecuteSystem {
    IGroup<GameEntity> navAgents;
    public NavigationSystem(Contexts contexts) {
        navAgents = contexts.game.GetGroup(GameMatcher.Navigation);
    }

    public void Execute() {
        foreach (var entity in navAgents.GetEntities()) {
            NavMeshAgent agent = entity.view.gameObject.GetComponent<NavMeshAgent>();
            entity.ReplacePosition(agent.nextPosition);
        }
    }
}
