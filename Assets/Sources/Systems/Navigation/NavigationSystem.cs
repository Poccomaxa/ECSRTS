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
        navAgents = contexts.game.GetGroup(GameMatcher.NavigationAgent);
    }

    public void Execute()
    {
        foreach (var entity in navAgents.GetEntities())
        {
            NavMeshAgent agent = entity.view.gameObject.GetComponent<NavMeshAgent>();

            bool shouldStop = false;
            if (agent.hasPath && agent.remainingDistance < 0.1 && entity.hasNavigationTarget)
            {
                shouldStop = true;
            }

            if (entity.hasNavigationApproach)
            {
                if (entity.navigationApproach.timeInPath > 0.75f && entity.navigationApproach.remainingDistance < agent.remainingDistance)
                {
                    shouldStop = true;
                }
            }

            entity.ReplacePosition(agent.nextPosition);
            if (entity.hasNavigationTarget)
            {
                float timeInPath = entity.hasNavigationApproach ? entity.navigationApproach.timeInPath : 0;
                timeInPath += Time.deltaTime;
                entity.ReplaceNavigationApproach(agent.remainingDistance, timeInPath);
            }

            if (shouldStop)
            {
                agent.isStopped = true;
                entity.RemoveNavigationTarget();
                entity.RemoveNavigationApproach();
            }

            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance && !agent.hasPath || agent.velocity.sqrMagnitude == 0f)
            {
                //Debug.Log("I'm here!");
            }
        }
    }
}
