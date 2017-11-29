using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.Unity;
using System;

public interface IAssetViewEntity : IEntity, IAsset, IView { }

public partial class GameEntity : IAssetViewEntity { }
public partial class UiEntity : IAssetViewEntity { }

public class ViewSetupSystem : MultiReactiveSystem<IAssetViewEntity, Contexts>
{
    GameContext context;
    public ViewSetupSystem(Contexts contexts) : base(contexts)
    {
        context = contexts.game;
    }

    protected override void Execute(List<IAssetViewEntity> entities)
    {
        foreach (var entity in entities)
        {
            var asset = Resources.Load<GameObject>(entity.asset.assetPath);
            GameObject gameObject = GameObject.Instantiate(asset);
            gameObject.Link(entity, context);
            entity.AddView(gameObject);

            if (gameObject.GetComponent<RectTransform>() != null)
            {
                gameObject.transform.SetParent(GameObject.FindObjectOfType<Canvas>().transform, false);
            }
        }
    }

    protected override bool Filter(IAssetViewEntity entity)
    {
        return entity.hasAsset && !entity.hasView;
    }

    protected override ICollector[] GetTrigger(Contexts contexts)
    {
        return new ICollector[]
        {
            contexts.game.CreateCollector(GameMatcher.Asset.Added()),
            contexts.ui.CreateCollector(UiMatcher.Asset.Added())
        };
    }
}
