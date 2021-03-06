﻿using System;
using Entitas;
using UnityEngine;

public class FollowSystem : IExecuteSystem
{
    IGroup<GameEntity> followObjects;
    GameContext gameContext;

    public FollowSystem(Contexts contexts)
    {
        followObjects = contexts.game.GetGroup(GameMatcher.Follow);
        gameContext = contexts.game;
    }

    public void Execute()
    {
        foreach (var entity in followObjects)
        {
            if (!entity.hasTargetLink)
            {
                continue;
            }

            GameEntity targetEntity = gameContext.GetEntityWithId(entity.targetLink.linkId);
            if (targetEntity != null)
            {
                float distanceToTravel = Time.deltaTime * entity.follow.speed;
                Vector3 direction = targetEntity.position.position - entity.position.position;
                if (direction.sqrMagnitude < distanceToTravel * distanceToTravel)
                {
                    entity.isDestroyed = true;
                    GameEntity damageAction = gameContext.CreateEntity();
                    damageAction.isAct = true;
                    damageAction.AddAction(false);
                    damageAction.AddDamageAction(entity.targetLink.linkId, 10f);
                }
                else
                {
                    Vector3 step = direction.normalized * distanceToTravel;
                    entity.ReplacePosition(entity.position.position + step);
                    entity.ReplaceRotation(Quaternion.FromToRotation(Vector3.forward, direction));
                }
            }
            else
            {
                entity.isDestroyed = true;
            }
        }
    }
}