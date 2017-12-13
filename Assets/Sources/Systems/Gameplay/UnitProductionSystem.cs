using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;

public class UnitProductionSystem : ReactiveSystem<InputEntity>
{
    GameContext gameContext;
    IGroup<GameEntity> selected;
    public UnitProductionSystem(Contexts contexts) : base(contexts.input)
    {
        gameContext = contexts.game;
        selected = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Selected, GameMatcher.UnitProduction));
    }

    protected override void Execute(List<InputEntity> entities)
    {
        GameEntity[] selectedUnitProduction = selected.GetEntities();
        if (selectedUnitProduction.Length > 0)
        {
            GameEntity unitProductionBuilding = selectedUnitProduction[0];
            foreach (var entity in entities)
            {
                int price = DeterminePrice(entity.unitType.type);
                if (GameUtils.IsEnoughResource(gameContext, gameContext.playerInventory, GameResource.GOLD, price))
                {
                    GameEntity buildWorkerAction = gameContext.CreateEntity();
                    buildWorkerAction.AddChannelAction(5f);
                    buildWorkerAction.AddCountdown(5f);
                    buildWorkerAction.AddAction(false);
                    buildWorkerAction.AddParentLink(unitProductionBuilding.id.value);
                    buildWorkerAction.AddUnitType(entity.unitType.type);
                    buildWorkerAction.isCreateUnitAction = true;

                    GameEntity payResourcesAction = gameContext.CreateEntity();
                    payResourcesAction.AddTransferResourceAction(gameContext.playerInventory.resourceIndex[GameResource.GOLD], 
                            buildWorkerAction.id.value, price);
                    payResourcesAction.AddAction(false);
                    payResourcesAction.isAct = true;
                }
                else
                {
                    //TODO: Not enough warning
                }
            }
        }
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.hasInputAction && entity.inputAction.action == InputAction.BUILD_UNIT && entity.hasUnitType;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.InputAction.Added());
    }

    private int DeterminePrice(UnitType type)
    {
        switch (type)
        {
            case UnitType.WARRIOR:
                return 100;
            case UnitType.WORKER:
                return 50;
        }
        return 0;
    }

}
