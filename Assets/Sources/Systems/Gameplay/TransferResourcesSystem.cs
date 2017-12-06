using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;

public class TransferResourcesSystem : ReactiveSystem<GameEntity>
{
    private GameContext gameContext;
    public TransferResourcesSystem(Contexts contexts) : base(contexts.game)
    {
        gameContext = contexts.game;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach(var entity in entities)
        {
            GameEntity fromEntity = gameContext.GetEntityWithId(entity.transferResourceAction.fromEntityId);
            GameEntity toEntity = gameContext.GetEntityWithId(entity.transferResourceAction.toEntityId);
            if (fromEntity != null && toEntity != null &&
                fromEntity.hasResource && fromEntity.hasResourceQuantity && fromEntity.resourceQuantity.quantity >= entity.transferResourceAction.amount)
            {
                int prevToQuantity = toEntity.hasResourceQuantity ? toEntity.resourceQuantity.quantity : 0;
                toEntity.ReplaceResourceQuantity(prevToQuantity + entity.transferResourceAction.amount);
                fromEntity.ReplaceResourceQuantity(fromEntity.resourceQuantity.quantity - entity.transferResourceAction.amount);
                if (!toEntity.hasResource)
                {
                    toEntity.AddResource(fromEntity.resource.resource);
                }
            }
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasTransferResourceAction && entity.isAct;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Act.Added());
    }
}
