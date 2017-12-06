using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;
using System.Linq;

public interface ICountdownEntity : ICountdown, ICountownEnded, IEntity { }

public partial class GameEntity : ICountdownEntity { }
public partial class InputEntity : ICountdownEntity { }
public partial class UiEntity : ICountdownEntity { }

public class CountdownSystem : MultiReactiveSystem<ICountdownEntity, Contexts>, ICleanupSystem
{
    Contexts contexts;
    public CountdownSystem(Contexts contexts) : base(contexts)
    {
        this.contexts = contexts;
    }

    public void Cleanup()
    {
        IEnumerable<ICountdownEntity> entities = new ICountdownEntity[0];
        entities = entities.Concat(contexts.game.GetGroup(GameMatcher.CountownEnded).GetEntities());
        entities = entities.Concat(contexts.input.GetGroup(InputMatcher.CountownEnded).GetEntities());
        entities = entities.Concat(contexts.ui.GetGroup(UiMatcher.CountownEnded).GetEntities());

        foreach (var entity in entities)
        {
            if (entity.hasCountownEnded)
            {
                entity.RemoveCountownEnded();
            }
        }        
    }

    protected override void Execute(List<ICountdownEntity> entities)
    {
        foreach (var entity in entities)
        {
            entity.ReplaceCountdown(entity.countdown.timeLeft - Time.deltaTime);
            if (entity.countdown.timeLeft <= 0)
            {
                entity.AddCountownEnded(entity.countdown.timeLeft);
                entity.RemoveCountdown();
            }
        }
    }

    protected override bool Filter(ICountdownEntity entity)
    {
        return entity.hasCountdown;
    }

    protected override ICollector[] GetTrigger(Contexts contexts)
    {
        return new ICollector[]
            {
                contexts.game.CreateCollector(GameMatcher.Countdown),
                contexts.input.CreateCollector(InputMatcher.Countdown),
                contexts.ui.CreateCollector(UiMatcher.Countdown)
            };
    }

}
