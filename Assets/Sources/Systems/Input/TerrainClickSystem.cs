﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Entitas;
using Entitas.Unity;
using System;
using UnityEngine.EventSystems;

public class TerrainClickSystem : ReactiveSystem<InputEntity>, ICleanupSystem {
    private InputContext inputContext;
    public TerrainClickSystem(Contexts contexts) : base(contexts.input)
    {
        inputContext = contexts.input;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        if (EventSystem.current.IsPointerOverGameObject() || EventSystem.current.currentSelectedGameObject != null)
        {
            return;
        }

        InputEntity pointerPosition = inputContext.GetGroup(InputMatcher.InputPointerPosition).Last();
        foreach (var e in entities)
        {
            Ray pointRay = Camera.main.ScreenPointToRay(pointerPosition.inputPointerPosition.position);
            RaycastHit hit;
            if (Physics.Raycast(pointRay, out hit, float.PositiveInfinity, LayerMask.GetMask("Interactable")))
            {
                EntityLink entityLink = hit.collider.gameObject.GetEntityLink();
                if (entityLink != null)
                {                    
                    inputContext.CreateEntity().AddInteractableClick((entityLink.entity as IId).id.value);
                }
            } else if (Physics.Raycast(pointRay, out hit, float.PositiveInfinity, LayerMask.GetMask("Terrain")))
            {
                inputContext.CreateEntity().AddTerrainClick(hit.point, hit.normal);
            }            
        }
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.hasInputAction && entity.isInputActionStarted && entity.inputAction.action == InputAction.ACT;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.InputActionStarted.Added());
    }

    public void Cleanup()
    {
        var entities = inputContext.GetGroup(InputMatcher.TerrainClick).GetEntities();
        foreach (var entity in entities)
        {
            entity.Destroy();
        }
    }
}
