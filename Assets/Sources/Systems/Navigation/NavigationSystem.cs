using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Entitas;
using System;

public class NavigationSystem : IExecuteSystem
{
    IGroup<GameEntity> navAgents;
    public NavigationSystem(Contexts contexts)
    {
        navAgents = contexts.game.GetGroup(GameMatcher.NavigationAgentEnabled);
    }

    public void Execute()
    {
        foreach (var entity in navAgents.GetEntities())
        {
            NavMeshAgent agent = entity.view.gameObject.GetComponent<NavMeshAgent>();

            if (entity.hasNavigationTarget && !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance
                    && (!agent.hasPath || agent.velocity.sqrMagnitude == 0f))
            {
                entity.isNavigationReached = true;
            }

            if (entity.hasNavigationApproach)
            {
                if (entity.navigationApproach.timeInPath > 0.75f && entity.navigationApproach.remainingDistance < agent.remainingDistance)
                {
                    entity.isNavigationRecede = true;
                }
            }

            entity.ReplacePosition(agent.nextPosition);
            if (entity.hasNavigationTarget)
            {
                float timeInPath = entity.hasNavigationApproach ? entity.navigationApproach.timeInPath : 0;
                timeInPath += Time.deltaTime;
                entity.ReplaceNavigationApproach(agent.remainingDistance, timeInPath);
            }
        }
    }
}
