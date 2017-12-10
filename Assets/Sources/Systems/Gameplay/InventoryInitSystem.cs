using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;

class InventoryInitSystem : IInitializeSystem
{
    GameContext gameContext;
    public InventoryInitSystem(Contexts contexts)
    {
        gameContext = contexts.game;
    }

    public void Initialize()
    {
        GameEntity gold = gameContext.CreateEntity();
        gold.ReplaceResource(GameResource.GOLD);
        gold.ReplaceResourceQuantity(25);
        Dictionary<GameResource, int> playerResouces = new Dictionary<GameResource, int>();
        playerResouces.Add(GameResource.GOLD, gold.id.value);
        gameContext.ReplacePlayerInventory(playerResouces);
        gold.AddParentLink(gameContext.playerInventoryEntity.id.value);
    }
}
