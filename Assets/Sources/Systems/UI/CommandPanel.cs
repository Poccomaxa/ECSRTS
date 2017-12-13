using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Entitas;

public class CommandPanel : MonoBehaviour
{
    public void BuildWorker()
    {
        InputEntity inputBuild = Contexts.sharedInstance.input.CreateEntity();
        inputBuild.AddInputAction(InputAction.BUILD_UNIT);
        inputBuild.AddUnitType(UnitType.WORKER);
    }

    public void BuildWarrior()
    {
        InputEntity inputBuild = Contexts.sharedInstance.input.CreateEntity();
        inputBuild.AddInputAction(InputAction.BUILD_UNIT);
        inputBuild.AddUnitType(UnitType.WARRIOR);
    }
}
