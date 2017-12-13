using System;
using System.Linq;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class CheatCreateWarriorsSystem : ReactiveSystem<InputEntity>
{
    GameContext gameContext;
    IGroup<InputEntity> pointerPosition;
    public CheatCreateWarriorsSystem(Contexts contexts) : base(contexts.input)
    {
        gameContext = contexts.game;
        pointerPosition = contexts.input.GetGroup(InputMatcher.InputPointerPosition);
    }

    protected override void Execute(List<InputEntity> entities)
    {
        

        if (pointerPosition.GetEntities().Length > 0)
        {
            Vector3 pos = pointerPosition.GetEntities().Last().inputPointerPosition.position;
            Ray pointRay = Camera.main.ScreenPointToRay(pos);
            RaycastHit hit;
            if (Physics.Raycast(pointRay, out hit, float.PositiveInfinity, LayerMask.GetMask("Terrain")))
            {
                GameEntity newWarrior = UnitFactory.CreateWarrior(gameContext);
                newWarrior.AddOwner(1);

                newWarrior.AddPosition(hit.point);
                newWarrior.AddNavigationTarget(hit.point);
            }
        }
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.hasInputAction && entity.inputAction.action == InputAction.CHEAT_CREATE_ENEMY_WARRIOR;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.InputAction.Added());
    }
}