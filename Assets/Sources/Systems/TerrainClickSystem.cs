using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;

public class TerrainClickSystem : IExecuteSystem {
    private GameContext context;    

    public TerrainClickSystem(Contexts context)
    {
        this.context = context.game;
    }

    public void Execute()
    {
        if (context.input.action != InputState.Down)
        {
            Ray pointRay = Camera.main.ScreenPointToRay(context.input.pointerPosition);
            RaycastHit hit;
            if (Physics.Raycast(pointRay, out hit))
            {
                context.CreateEntity().AddTerrainClick(hit.point, hit.normal);                
            }
        }
    }
}
