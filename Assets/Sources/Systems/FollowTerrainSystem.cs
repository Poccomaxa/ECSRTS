using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;

public class FollowTerrainSystem : IExecuteSystem
{
    GameContext gameContext;
    IGroup<GameEntity> group;
    public FollowTerrainSystem(Contexts contexts)
    {
        gameContext = contexts.game;
        group = contexts.game.GetGroup(GameMatcher.FollowTerrain);
    }

    public void Execute()
    {
        foreach (var entity in group.GetEntities())
        {
            if (entity.hasParentLink && entity.hasView)
            {
                GameEntity parentEntity = gameContext.GetEntityWithId(entity.parentLink.parentId);
                if (parentEntity != null && parentEntity.hasPosition)
                {
                    RaycastHit hitInfo;
                    if (Physics.Raycast(parentEntity.position.position, Vector3.down, out hitInfo,
                        float.PositiveInfinity, LayerMask.GetMask("Terrain")))
                    {
                        entity.ReplacePosition(hitInfo.point);
                        entity.ReplaceRotation(Quaternion.FromToRotation(Vector3.up, hitInfo.normal));
                    }
                }
            }
        }
    }
}
