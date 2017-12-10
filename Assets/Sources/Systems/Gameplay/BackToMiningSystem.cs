using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;

class BackToMiningSystem : ReactiveSystem<GameEntity>
{
    IGroup<GameEntity> resourceSources;
    public BackToMiningSystem(Contexts contexts) : base(contexts.game)
    {
        resourceSources = contexts.game.GetGroup(GameMatcher.ResourceSource);
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            foreach (var source in resourceSources.GetEntities())
            {
                entity.ReplaceNavigationTarget(source.position.position);
                entity.ReplaceNavigationApproach(float.PositiveInfinity, 0);
                entity.ReplaceNavigationObjectTarget(source.id.value);
            }            
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return true;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.ResourcesReturned.Added());
    }
}
