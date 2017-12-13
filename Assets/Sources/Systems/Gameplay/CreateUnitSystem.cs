using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;

public class CreateUnitSystem : ReactiveSystem<GameEntity>
{
    GameContext gameContext;
    public CreateUnitSystem(Contexts contexts) : base(contexts.game)
    {
        gameContext = contexts.game;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            GameEntity actionOwner = gameContext.GetEntityWithId(entity.parentLink.parentId);
            if (actionOwner != null)
            {
                GameEntity newWorker = null;
                switch (entity.unitType.type)
                {
                    case UnitType.WORKER:
                        newWorker = UnitFactory.CreateWorker(gameContext);
                        break;
                    case UnitType.WARRIOR:
                        newWorker = UnitFactory.CreateWarrior(gameContext);
                        break;
                }

                newWorker.AddPosition(actionOwner.position.position);
                newWorker.AddNavigationTarget(actionOwner.position.position);
            }
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isAct && entity.isCreateUnitAction && entity.hasParentLink && entity.hasUnitType;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Act.Added());
    }
}
