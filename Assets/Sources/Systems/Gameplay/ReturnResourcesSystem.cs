using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;

public class ReturnResourcesSystem : ReactiveSystem<GameEntity> {
    IGroup<GameEntity> resourceDepots;
    public ReturnResourcesSystem(Contexts contexts) : base (contexts.game)
    {
        resourceDepots = contexts.game.GetGroup(GameMatcher.ResourceDepot);
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            foreach (var depot in resourceDepots)
            {
                entity.ReplaceNavigationTarget(depot.position.position);
                entity.ReplaceNavigationApproach(float.PositiveInfinity, 0);
                entity.ReplaceNavigationObjectTarget(depot.id.value);
                break;
            }
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasNavigationAgent && entity.isResourceFull && entity.isResourceMining;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.ResourceFull.Added());
    }
}
