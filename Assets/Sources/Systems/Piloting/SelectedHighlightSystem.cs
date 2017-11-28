using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;

public class SelectedHighlightSystem : ReactiveSystem<GameEntity>
{
    GameContext gameContext;
    public SelectedHighlightSystem(Contexts contexts) : base(contexts.game)
    {
        gameContext = contexts.game;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            GameEntity selectionView = gameContext.CreateEntity();
            selectionView.AddAsset("Prefabs/Selection");
            selectionView.AddParentLink(entity.id.value);
            selectionView.isFollowFloor = true;
            selectionView.isSelection = true;
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isSelected;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Selected.Added());
    }
}
