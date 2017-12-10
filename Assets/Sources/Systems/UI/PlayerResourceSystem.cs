using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;

public class PlayerResourceSystem : ReactiveSystem<GameEntity>
{
    private UiContext uiContext;
    private GameContext gameContext;
    public PlayerResourceSystem(Contexts contexts) : base(contexts.game)
    {
        uiContext = contexts.ui;
        gameContext = contexts.game;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            var uiEntities = uiContext.GetEntitiesWithPlayerResource(entity.resource.resource);
            foreach (var uiEntity in uiEntities)
            {
                uiEntity.ReplaceText(entity.resourceQuantity.quantity.ToString());
            }
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasResource && entity.hasResourceQuantity && entity.hasParentLink && entity.parentLink.parentId == gameContext.playerInventoryEntity.id.value;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.ResourceQuantity.Added());
    }
}
