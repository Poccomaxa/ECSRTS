using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.Unity;

public class GoldMineBinder : MonoBehaviour {

    void Start()
    {
        GameContext gameContext = Contexts.sharedInstance.game;
        GameEntity entity = gameContext.CreateEntity();
        gameObject.Link(entity, gameContext);

        entity.AddView(gameObject);
        entity.AddResource(GameResource.GOLD);
        entity.AddResourceQuantity(UnityEngine.Random.Range(2500, 3200));
        entity.AddPosition(transform.position);
        entity.isResourceSource = true;
    }
}
