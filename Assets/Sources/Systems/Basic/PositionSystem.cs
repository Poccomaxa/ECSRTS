using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;

public class PositionSystem : ReactiveSystem<GameEntity>
{
    public PositionSystem(Contexts contexts) : base(contexts.game)
    {
    }
    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            entity.view.gameObject.transform.position = entity.position.position;
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasPosition && entity.hasView;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Position.Added());
    }
}
