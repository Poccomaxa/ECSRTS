﻿using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class GameController : MonoBehaviour {
    private Systems systems;

    public GameObject clickHighlightPrefab;
	void Start () {
        var context = Contexts.sharedInstance;
        systems = new Feature("Systems")
            .Add(new InputSystem(context))
            .Add(new TerrainClickSystem(context))
            .Add(new TerrainClickHighlightSystem(context, clickHighlightPrefab));
        systems.Initialize();
	}

    void Update()
    {
        systems.Execute();
        systems.Cleanup();
    }
}
