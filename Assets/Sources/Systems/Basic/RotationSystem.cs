using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;

public class RotationSystem : ReactiveSystem<GameEntity>
{
    public RotationSystem(Contexts contexts) : base(contexts.game)
    {

    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            entity.view.gameObject.transform.rotation = entity.rotation.rotation;
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasRotation && entity.hasView;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Rotation.Added());
    }
}
