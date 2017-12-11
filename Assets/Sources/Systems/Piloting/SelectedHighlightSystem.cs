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
            selectionView.AddAsset(entity.selectable.selectionAsset);
            selectionView.AddParentLink(entity.id.value);
            selectionView.isFollowTerrain = true;
            selectionView.isUnitSelection = true;
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isSelected && entity.hasSelectable;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Selected.Added());
    }
}
