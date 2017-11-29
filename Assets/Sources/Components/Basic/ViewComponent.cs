using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Ui]
public class ViewComponent : IComponent
{
    public GameObject gameObject = null;
}
