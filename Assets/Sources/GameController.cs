using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class GameController : MonoBehaviour {
    private Systems systems;

	void Start () {
        var context = Contexts.sharedInstance;
        systems = new Feature("Systems")
            .Add(new InputSystem(context))
            .Add(new TerrainClickSystem(context))
            .Add(new TerrainClickHighlightSystem(context))
            .Add(new ViewFabricSystem(context))
            .Add(new PositionSystem(context))
            .Add(new RotationSystem(context))
            .Add(new NavigationSetupSystem(context))
            .Add(new NavigationTargetingSystem(context))
            .Add(new NavigationSystem(context))
            .Add(new DestroyCountdownSystem(context))
            .Add(new ViewCleanupSystem(context))
            .Add(new DestroyedCleanupSystem(context));

        systems.Initialize();

        GameEntity entity = context.game.CreateEntity();
        entity.AddAsset("Prefabs/Unit");
        Ray centerRay = Camera.main.ScreenPointToRay(Vector3.zero);
        RaycastHit hit;
        if (Physics.Raycast(centerRay, out hit)) {
            entity.AddNavigation(hit.point);
        }
	}

    void Update()
    {
        systems.Execute();
        systems.Cleanup();
    }
}
