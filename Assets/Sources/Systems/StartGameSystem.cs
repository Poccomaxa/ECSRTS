using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;

public class StartGameSystem : IInitializeSystem
{
    private GameContext gameContext;

    public StartGameSystem(Contexts contexts)
    {
        gameContext = contexts.game;
    }

    public void Initialize()
    {
        for (int i = 0; i < 10; ++i)
        {
            GameEntity entity = gameContext.CreateEntity();
            entity.AddAsset("Prefabs/Unit");
            entity.isSelectable = true;
            Ray centerRay = Camera.main.ScreenPointToRay(Vector3.zero);
            RaycastHit hit;
            if (Physics.Raycast(centerRay, out hit))
            {
                entity.AddNavigation(hit.point);
            }
        }
    }
}
