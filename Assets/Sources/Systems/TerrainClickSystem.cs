using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;

public class TerrainClickSystem : IExecuteSystem {
    GameContext context;

    public TerrainClickSystem(Contexts context)
    {
        this.context = context.game;
    }

    public void Execute()
    {
        if (context.input.action != InputState.None)
        {
            Debug.Log(context.input.action);
        }
    }
}
