using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;

public class TerrainClickHighlightSystem : ReactiveSystem<InputEntity>
{
    private GameContext gameContext;
    public TerrainClickHighlightSystem(Contexts contexts) : base(contexts.input)
    {
        this.gameContext = contexts.game;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        foreach (InputEntity entity in entities)
        {            
            GameEntity newEntity = gameContext.CreateEntity();
            newEntity.AddAsset("Prefabs/ClickHighlightPrefab");
            newEntity.AddPosition(entity.terrainClick.position);
            newEntity.AddRotation(Quaternion.FromToRotation(Vector3.up, entity.terrainClick.normal));
            newEntity.AddDestroyCountdown(1);
        }
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.hasTerrainClick;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.TerrainClick.Added());
    }
}
