using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Entitas;

public class PlayerResourceBinder : MonoBehaviour {

    private void Awake()
    {
        UiEntity resource = Contexts.sharedInstance.ui.CreateEntity();
        resource.AddTextView(GetComponent<Text>());
        resource.AddText("0");
        resource.AddPlayerResource(GameResource.GOLD);
    }
}
