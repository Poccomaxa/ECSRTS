using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;

public class StopMiningSystem : ReactiveSystem<GameEntity>
{
    public StopMiningSystem(Contexts contexts) : base(contexts.game)
    {

    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            entity.isResourceMining = false;
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasNavigationTarget && entity.isResourceMining;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.NavigationTarget.Added());
    }
}
