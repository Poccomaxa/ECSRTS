using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.Unity;
using UnityEngine.AI;

public class DepotSpawner : MonoBehaviour {
    void Start()
    {
        GameContext gameContext = Contexts.sharedInstance.game;
        GameEntity entity = gameContext.CreateEntity();
        gameObject.Link(entity, gameContext);

        entity.AddView(gameObject);
        entity.AddPosition(transform.position);
        entity.isResourceDepot = true;
        entity.ReplaceNavigationObstacle(gameObject.GetComponent<NavMeshObstacle>());
        entity.isNavigationObstacleEnabled = true;
        entity.AddSelectable("Prefabs/DepotSelection");
    }
}
