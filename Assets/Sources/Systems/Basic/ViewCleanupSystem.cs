using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.Unity;
using System;

public interface IViewEntity : IEntity, IView { }

public partial class GameEntity : IViewEntity { }
public partial class UiEntity : IViewEntity { }

public class ViewCleanupSystem : MultiReactiveSystem<IViewEntity, Contexts> {
    public ViewCleanupSystem(Contexts contexts) : base(contexts) { }

    protected override void Execute(List<IViewEntity> entities) {
        foreach (var entity in entities)
        {
            entity.view.gameObject.Unlink();
            GameObject.Destroy(entity.view.gameObject);
        }
    }

    protected override bool Filter(IViewEntity entity) {
        return entity.hasView;
    }

    protected override ICollector[] GetTrigger(Contexts contexts) {
        return new ICollector[]
        {
            contexts.game.CreateCollector(GameMatcher.Destroyed),
            contexts.ui.CreateCollector(UiMatcher.Destroyed)
        };
    }
}
