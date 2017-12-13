using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public static class UnitFactory
{
    public static GameEntity CreateWorker(GameContext gameContext)
    {
        GameEntity entity = gameContext.CreateEntity();
        entity.AddAsset("Prefabs/Unit");
        entity.AddSelectable("Prefabs/Selection");

        entity.ReplaceNavigationAgent(null);
        entity.ReplaceNavigationObstacle(null);
        entity.AddResourceLimit(5);

        return entity;
    }
    
    public static GameEntity CreateWarrior(GameContext gameContext)
    {
        GameEntity entity = gameContext.CreateEntity();
        entity.AddAsset("Prefabs/UnitWarrior");
        entity.AddSelectable("Prefabs/Selection");

        entity.AddDetectProximity(30f * 30f);
        entity.ReplaceNavigationAgent(null);
        entity.ReplaceNavigationObstacle(null);
        entity.AddResourceLimit(5);

        return entity;
    }
}
