using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class GameController : MonoBehaviour {
    private Systems systems;

	void Start () {
        var context = Contexts.sharedInstance;
        systems = new Feature("Systems")
            .Add(new InputSystem(context))
            .Add(new TerrainClickSystem(context));
        systems.Initialize();
	}

    void Update()
    {
        systems.Execute();
        systems.Cleanup();
    }
}
