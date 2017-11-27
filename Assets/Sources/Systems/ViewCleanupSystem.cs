using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;

public class ViewCleanupSystem : ReactiveSystem<GameEntity> {
    public ViewCleanupSystem(Contexts contexts) : base(contexts.game) { }

    protected override void Execute(List<GameEntity> entities) {
        foreach (var entity in entities)
        {
            GameObject.Destroy(entity.view.gameObject);
        }
    }

    protected override bool Filter(GameEntity entity) {
        return entity.hasView;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
        return context.CreateCollector(GameMatcher.Destroyed);
    }
}
