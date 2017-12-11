using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class GameController : MonoBehaviour {
    private Systems systems;

	void Awake () {
        var context = Contexts.sharedInstance;
        systems = new Feature("Systems")      
            .Add(new StartGameSystem(context))
            .Add(new InputSystem(context))
            .Add(new CountdownSystem(context))
            .Add(new TerrainClickSystem(context))
            .Add(new TerrainClickHighlightSystem(context))
            .Add(new SelectedHighlightSystem(context))
            .Add(new SelectionCleanupSystem(context))
            .Add(new SelectionFrameSystem(context))
            .Add(new SelectionSystem(context))
            .Add(new SelectionFrameUISystem(context))
            .Add(new SelectionFrameUiCleanupSystem(context))
            .Add(new ViewSetupSystem(context))
            .Add(new FollowTerrainSystem(context))
            .Add(new NavigationAgentSetupSystem(context))
            .Add(new NavigationObstacleSetupSystem(context))
            .Add(new NavigationTerrainClickSystem(context))
            .Add(new NavigationToObjectSystem(context))
            .Add(new NavigationReactivateAgentSystem(context))
            .Add(new NavigationEnableDisableSystem(context))
            .Add(new NavigationAgentRadiusSetupSystem(context))
            .Add(new NavigationTargetingSystem(context))
            .Add(new NavigationSystem(context))
            .Add(new NavigationReachObjectSystem(context))
            .Add(new NavigationStartMiningSystem(context))
            .Add(new NavigationReturnResourcesSystem(context))
            .Add(new NavigationStoppingSystem(context))
            .Add(new InterruptMiningSystem(context))

            .Add(new UnitProductionSystem(context))
            .Add(new InventoryInitSystem(context))
            .Add(new MiningSystem(context))
            .Add(new ChannelActionSystem(context))
            .Add(new ReturnResourcesSystem(context))
            .Add(new BackToMiningSystem(context))
            .Add(new TransferResourcesSystem(context))            
            .Add(new ResourceFullDetectSystem(context))
            .Add(new CreateUnitSystem(context))

            .Add(new PlayerResourceSystem(context))
            .Add(new TextSystem(context))

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
