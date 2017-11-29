using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Input, Ui]
public class IdComponent : IComponent
{
    [PrimaryEntityIndex]
    public int value;
}
