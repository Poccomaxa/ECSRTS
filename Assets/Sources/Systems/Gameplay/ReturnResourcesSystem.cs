using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;

public class ReturnResourcesSystem : ReactiveSystem<GameEntity> {
    public ReturnResourcesSystem(Contexts contexts) : base (contexts.game) { }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            
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
