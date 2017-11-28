using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Entitas;
using Entitas.Unity;
using System;

public class SelectionSystem : ReactiveSystem<InputEntity>
{
    IGroup<InputEntity> group;
    IGroup<GameEntity> selectedEntities;

    public SelectionSystem(Contexts contexts) : base(contexts.input)
    {
        group = contexts.input.GetGroup(InputMatcher.InputPointerPosition);
        selectedEntities = contexts.game.GetGroup(GameMatcher.Selected);
    }

    protected override void Execute(List<InputEntity> entities)
    {
        InputEntity pointerPosition = group.Last();
        foreach (var entity in entities)
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(pointerPosition.inputPointerPosition.position);
            RaycastHit hit;
            if (Physics.Raycast(mouseRay, out hit, float.PositiveInfinity, LayerMask.GetMask("Selectable")))
            {
                GameEntity linkedEntity = (GameEntity)hit.collider.gameObject.GetEntityLink().entity;
                if (linkedEntity != null)
                {
                    DeselectAll();
                    linkedEntity.isSelected = true;
                }
            }
        }
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.isInputActionEnded && entity.hasInputAction && entity.inputAction.action == InputAction.SELECT;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.InputActionEnded.Added());
    }

    private void DeselectAll()
    {
        foreach (var entity in selectedEntities.GetEntities())
        {
            entity.isSelected = false;
        }
    }
}
