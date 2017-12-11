using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;

public class UnitProductionSystem : ReactiveSystem<InputEntity>
{
    public UnitProductionSystem(Contexts contexts) : base(contexts.input)
    {

    }
    protected override void Execute(List<InputEntity> entities)
    {
        foreach (var entity in entities)
        {

        }
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.hasInputAction && entity.inputAction.action == InputAction.BUILD_UNIT;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.InputAction.Added());
    }
}
