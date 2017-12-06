using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;

public class MiningSystem : ReactiveSystem<GameEntity> {
    private GameContext gameContext;
    public MiningSystem(Contexts contexts) : base(contexts.game)
    {
        gameContext = contexts.game;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            GameEntity miningAction = gameContext.CreateEntity();
            miningAction.AddAction(true);
            miningAction.AddChannelAction(0.2f);
            miningAction.AddCountdown(0.2f);
            miningAction.AddParentLink(entity.id.value);
            miningAction.AddTransferResourceAction(entity.navigationObjectTarget.entityId, entity.id.value, 1);
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isResourceMining && entity.hasNavigationObjectTarget;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.ResourceMining.Added());
    }
}
