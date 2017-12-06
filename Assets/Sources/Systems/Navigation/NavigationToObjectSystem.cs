using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Entitas;
using System;

public class NavigationToObjectSystem : ReactiveSystem<InputEntity>
{
    GameContext gameContext;
    IGroup<GameEntity> navigationGroup;
    public NavigationToObjectSystem(Contexts contexts) : base(contexts.input)
    {
        gameContext = contexts.game;
        navigationGroup = gameContext.GetGroup(GameMatcher.NavigationAgent);
    }

    protected override void Execute(List<InputEntity> entities)
    {
        foreach (var entity in entities)
        {
            GameEntity interactable = gameContext.GetEntityWithId(entity.interactableClick.entityId);
            if (interactable != null && interactable.hasPosition)
            {
                foreach (var navEntity in navigationGroup.GetEntities())
                {
                    if (navEntity.isSelected)
                    {
                        navEntity.ReplaceNavigationTarget(interactable.position.position);
                        navEntity.ReplaceNavigationApproach(float.PositiveInfinity, 0);
                        navEntity.ReplaceNavigationObjectTarget(entity.interactableClick.entityId);
                    }
                }
            }
        }
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.hasInteractableClick;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.InteractableClick.Added());
    }
}
