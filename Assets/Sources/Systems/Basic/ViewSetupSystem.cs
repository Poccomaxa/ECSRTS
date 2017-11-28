using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.Unity;
using System;

public class ViewSetupSystem : ReactiveSystem<GameEntity>
{
    GameContext context;
    public ViewSetupSystem(Contexts contexts) : base(contexts.game)
    {
        context = contexts.game;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            var asset = Resources.Load<GameObject>(entity.asset.assetPath);
            GameObject gameObject = GameObject.Instantiate(asset);
            gameObject.Link(entity, context);
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
