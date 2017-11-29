using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;

public class SelectUnitsByFrameSystem : ReactiveSystem<InputEntity>
{
    IGroup<GameEntity> selectableGroup;
    public SelectUnitsByFrameSystem(Contexts contexts) : base(contexts.input)
    {
        selectableGroup = contexts.game.GetGroup(GameMatcher.Selectable);
    }

    protected override void Execute(List<InputEntity> entities)
    {
        foreach (var entity in entities)
        {

        }
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.hasInputSelectionFrame;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.InputSelectionFrame.Added());
    }
}
