using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;

public class ChannelActionSystem : ReactiveSystem<GameEntity>, ICleanupSystem
{
    IGroup<GameEntity> actGroup;
    public ChannelActionSystem(Contexts contexts) : base(contexts.game)
    {
        actGroup = contexts.game.GetGroup(GameMatcher.Act);
    }

    public void Cleanup()
    {
        foreach (var entity in actGroup.GetEntities())
        {
            if (entity.action.repeatable)
            {
                entity.isAct = false;
            } else
            {
                entity.isDestroyed = true;
            }            
        }   
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            entity.isAct = true;
            if (entity.action.repeatable)
            {
                //If overflowTime > channelTime maybe act right away?
                entity.ReplaceCountdown(Mathf.Max(0f, entity.channelAction.channelTime - entity.countownEnded.overflowTime));
            }            
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasCountownEnded && entity.hasAction && entity.hasChannelAction;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.CountownEnded.Added());
    }
}
