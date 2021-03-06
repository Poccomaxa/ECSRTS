﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;

public class NavigationAgentRadiusSetupSystem : ReactiveSystem<GameEntity>
{
    public NavigationAgentRadiusSetupSystem(Contexts contexts) : base(contexts.game)
    {

    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            entity.navigationAgent.agent.radius = entity.navigationAgentRadius.radius;
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasNavigationAgent && entity.hasNavigationAgentRadius;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.NavigationAgentRadius.Added());
    }
}
