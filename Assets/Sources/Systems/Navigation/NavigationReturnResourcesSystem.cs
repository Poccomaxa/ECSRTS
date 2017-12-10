using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;

public class NavigationReturnResourcesSystem : ReactiveSystem<GameEntity>, ICleanupSystem
{
    IGroup<GameEntity> resourcesReturned;
    GameContext gameContext;
    public NavigationReturnResourcesSystem(Contexts contexts) : base(contexts.game)
    {
        gameContext = contexts.game;
        resourcesReturned = gameContext.GetGroup(GameMatcher.ResourcesReturned);
    }

    public void Cleanup()
    {
        foreach (var entity in resourcesReturned.GetEntities())
        {
            entity.RemoveResourcesReturned();
        }
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            GameEntity action = gameContext.CreateEntity();
            action.isAct = true;
            action.AddAction(false);
            action.AddParentLink(entity.id.value);            
            action.AddTransferResourceAction(entity.id.value, gameContext.playerInventory.resourceIndex[entity.resource.resource], entity.resourceQuantity.quantity);

            entity.AddResourcesReturned(entity.resource.resource);
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        if (entity.hasNavigationObjectTarget && entity.hasResource)
        {
            GameEntity navigationTarget = gameContext.GetEntityWithId(entity.navigationObjectTarget.entityId);
            if (navigationTarget != null && navigationTarget.isResourceDepot)
            {
                return true;
            }
        }
        return false;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.NavigationObjectReached.Added());
    }
}
