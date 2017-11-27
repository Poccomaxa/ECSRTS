using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;

public class DestroyedCleanupSystem : ICleanupSystem {
    IGroup<GameEntity> entitiesToDestroy;
    public DestroyedCleanupSystem(Contexts context) {
        entitiesToDestroy = context.game.GetGroup(GameMatcher.Destroyed);
    }

    public void Cleanup() {
        foreach (var entity in entitiesToDestroy.GetEntities()) {
            entity.Destroy();
        }
    }
}
