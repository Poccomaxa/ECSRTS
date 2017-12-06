using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Entitas;
using System;

public class NavigationTerrainClickSystem : ReactiveSystem<InputEntity> {
    GameContext gameContext;
    IGroup<GameEntity> navigationGroup;
    public NavigationTerrainClickSystem(Contexts contexts) : base(contexts.input) {
        gameContext = contexts.game;
        navigationGroup = gameContext.GetGroup(GameMatcher.NavigationAgent);
    }

    protected override void Execute(List<InputEntity> entities) {
        foreach (var entity in entities) {
            foreach (var navEntity in navigationGroup.GetEntities()) {
                if (navEntity.isSelected)
                {
                    navEntity.ReplaceNavigationTarget(entity.terrainClick.position);
                    navEntity.ReplaceNavigationApproach(float.PositiveInfinity, 0);
                    if (navEntity.hasNavigationObjectTarget)
                    {
                        navEntity.RemoveNavigationObjectTarget();
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
