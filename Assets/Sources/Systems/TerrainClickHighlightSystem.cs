using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;

public class TerrainClickHighlightSystem : ReactiveSystem<InputEntity>
{
    private GameObject clickHighlightPrefab;
    public TerrainClickHighlightSystem(Contexts contexts, GameObject clickHighlightPrefab) : base(contexts.input)
    {
        this.clickHighlightPrefab = clickHighlightPrefab;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        foreach (InputEntity entity in entities)
        {
            GameObject newPrefab = GameObject.Instantiate(clickHighlightPrefab);
            newPrefab.transform.position = entity.terrainClick.position;
            newPrefab.transform.rotation = Quaternion.FromToRotation(Vector3.up, entity.terrainClick.normal);
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
