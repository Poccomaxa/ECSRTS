using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;

public class TerrainClickHighlightSystem : ReactiveSystem<GameEntity>
{
    private GameObject clickHighlightPrefab;
    public TerrainClickHighlightSystem(Contexts contexts, GameObject clickHighlightPrefab) : base(contexts.game)
    {
        this.clickHighlightPrefab = clickHighlightPrefab;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity entity in entities)
        {
            GameObject newPrefab = GameObject.Instantiate(clickHighlightPrefab);
            newPrefab.transform.position = entity.terrainClick.position;
            newPrefab.transform.rotation = Quaternion.FromToRotation(Vector3.up, entity.terrainClick.normal);
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasTerrainClick;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.TerrainClick.Added());
    }
}
