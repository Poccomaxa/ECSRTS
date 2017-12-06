using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
public class TransferResourceAction : IComponent
{
    public int fromEntityId;
    public int toEntityId;
    public int amount;	
}
