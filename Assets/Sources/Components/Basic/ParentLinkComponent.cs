﻿using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
public class ParentLinkComponent : IComponent
{
    [EntityIndex]
    public int parentId;
}
