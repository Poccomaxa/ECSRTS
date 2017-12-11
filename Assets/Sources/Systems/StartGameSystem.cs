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
        Ray centerRay = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;
        if (Physics.Raycast(centerRay, out hit))
        {
            for (int i = 0; i < 3; ++i)
            {
                GameEntity entity = UnitFactory.CreateWorker(gameContext);
                Vector3 newPoint = hit.point + new Vector3(UnityEngine.Random.Range(-0.1f, 0.1f), 0, UnityEngine.Random.Range(-0.1f, 0.1f));
                entity.AddNavigationTarget(newPoint);
                entity.AddPosition(newPoint);
            }
        }
    }
}
