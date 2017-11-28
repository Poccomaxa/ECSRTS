using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.Unity;
using System;

public interface IDestroyEntity : IEntity, IDestroyed { }

public partial class GameEntity : IDestroyEntity { }
public partial class InputEntity : IDestroyEntity { }

public class DestroyedCleanupSystem : MultiReactiveSystem<IDestroyEntity, Contexts>
{
    public DestroyedCleanupSystem(Contexts contexts) : base(contexts) { }

    protected override void Execute(List<IDestroyEntity> entities)
    {
        foreach (var entity in entities)
        {
            entity.Destroy();
        }
    }

    protected override bool Filter(IDestroyEntity entity)
    {
        return entity.isDestroyed;
    }

    protected override ICollector[] GetTrigger(Contexts contexts)
    {
        return new ICollector[]
        {
            contexts.game.CreateCollector(GameMatcher.Destroyed),
            contexts.input.CreateCollector(InputMatcher.Destroyed)
        };
    }
}
