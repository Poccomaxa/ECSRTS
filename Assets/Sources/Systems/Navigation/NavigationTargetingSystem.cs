using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Entitas;
using System;

public class NavigationTargetingSystem : ReactiveSystem<InputEntity> {
    GameContext gameContext;
    IGroup<GameEntity> navigationGroup;
    public NavigationTargetingSystem(Contexts contexts) : base(contexts.input) {
        gameContext = contexts.game;
        navigationGroup = gameContext.GetGroup(GameMatcher.Navigation);
    }

    protected override void Execute(List<InputEntity> entities) {
        foreach (var entity in entities) {
            foreach (var navEntity in navigationGroup.GetEntities()) {
                if (navEntity.isSelected)
                {
                    navEntity.ReplaceNavigation(entity.terrainClick.position);
                    NavMeshAgent navAgent = navEntity.view.gameObject.GetComponent<NavMeshAgent>();
                    if (navAgent != null)
                    {
                        navAgent.destination = entity.terrainClick.position;
                    }
                }
            }
        }
    }

    protected override bool Filter(InputEntity entity) {
        return entity.hasTerrainClick;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context) {
        return context.CreateCollector(InputMatcher.TerrainClick.Added());
    }
}
