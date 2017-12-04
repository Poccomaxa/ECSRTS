using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class GameController : MonoBehaviour {
    private Systems systems;

	void Start () {
        var context = Contexts.sharedInstance;
        systems = new Feature("Systems")            
            .Add(new StartGameSystem(context))
            .Add(new InputSystem(context))
            .Add(new TerrainClickSystem(context))
            .Add(new TerrainClickHighlightSystem(context))
            .Add(new SelectedHighlightSystem(context))
            .Add(new SelectionCleanupSystem(context))
            .Add(new SelectionFrameSystem(context))
            .Add(new SelectionSystem(context))
            .Add(new SelectionFrameUISystem(context))
            .Add(new SelectionFrameUiCleanupSystem(context))
            .Add(new FollowTerrainSystem(context))
            .Add(new ViewSetupSystem(context))
            .Add(new NavigationSetupSystem(context))
            .Add(new NavigationTerrainClickSystem(context))
            .Add(new NavigationTargetingSystem(context))
            .Add(new NavigationSystem(context))
            .Add(new PositionSystem(context))
            .Add(new RotationSystem(context))
            .Add(new RectSystem(context))
            .Add(new DestroyCountdownSystem(context))
            .Add(new ViewCleanupSystem(context))
            .Add(new DestroyedCleanupSystem(context));

        context.game.OnEntityCreated += AddId;
        context.input.OnEntityCreated += AddId;

        systems.Initialize();
	}

    void Update()
    {
        systems.Execute();
        systems.Cleanup();
    }

    private void AddId(IContext context, IEntity entity)
    {
        (entity as IId).AddId(entity.creationIndex);
    }
}
