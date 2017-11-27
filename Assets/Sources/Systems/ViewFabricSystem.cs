using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;

public class ViewFabricSystem : ReactiveSystem<GameEntity>
{
    public ViewFabricSystem(Contexts contexts) : base(contexts.game)
    {
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            var asset = Resources.Load<GameObject>(entity.asset.assetPath);
            GameObject gameObject = GameObject.Instantiate(asset);
            entity.AddView(gameObject);
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasAsset && !entity.hasView;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Asset.Added());
    }
}
