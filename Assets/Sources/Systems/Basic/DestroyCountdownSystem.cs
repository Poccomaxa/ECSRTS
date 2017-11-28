using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;

public class DestroyCountdownSystem : IExecuteSystem {
    GameContext context;
    IGroup<GameEntity> group;
    public DestroyCountdownSystem(Contexts contexts) 
    {
        context = contexts.game;
        group = context.GetGroup(GameMatcher.DestroyCountdown);
    }

    public void Execute() {
        foreach (var entity in group.GetEntities()) {
            entity.destroyCountdown.timeToLive -= Time.deltaTime;
            if (entity.destroyCountdown.timeToLive <= 0) {
                entity.isDestroyed = true;
            }
        }
    }
}
