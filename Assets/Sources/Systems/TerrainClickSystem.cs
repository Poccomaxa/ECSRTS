using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Entitas;
using System;

public class TerrainClickSystem : ReactiveSystem<GameEntity> {
    private GameContext context;
    public TerrainClickSystem(Contexts contexts) : base(contexts.game)
    {
        context = contexts.game;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        GameEntity pointerPosition = context.GetGroup(GameMatcher.InputPointerPosition).Last();
        foreach (var e in entities)
        {
            Ray pointRay = Camera.main.ScreenPointToRay(pointerPosition.inputPointerPosition.position);
            RaycastHit hit;
            if (Physics.Raycast(pointRay, out hit))
            {
                context.CreateEntity().AddTerrainClick(hit.point, hit.normal);
            }            
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasInputAction && entity.isInputActionStarted && entity.inputAction.action == InputAction.ACT;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.InputAction.Added());
    }
}
