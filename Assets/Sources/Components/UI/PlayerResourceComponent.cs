﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Ui]
public class PlayerResourceComponent : IComponent
{
    [EntityIndex]
    public GameResource resource;
}
