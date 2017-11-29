using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.Unity;
using System;
using System.Linq;

public class SelectionSystem : ReactiveSystem<InputEntity>
{
    IGroup<GameEntity> selectableGroup;
    IGroup<InputEntity> pointerGroup;
    IGroup<GameEntity> selectedEntities;
    public SelectionSystem(Contexts contexts) : base(contexts.input)
    {
        selectableGroup = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Selectable, GameMatcher.View));
        selectedEntities = contexts.game.GetGroup(GameMatcher.Selected);
        pointerGroup = contexts.input.GetGroup(InputMatcher.InputPointerPosition);
    }

    protected override void Execute(List<InputEntity> entities)
    {
        foreach (var selectionEntity in entities)
        {
            DeselectAll();
            Rect selectionRect = selectionEntity.inputSelectionFrame.rect;
            if (selectionRect.width < 2 || selectionRect.height < 2)
            {
                SelectByRay();
            }
            else
            {
                SelectByFrame(selectionRect);
            }

        }
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.hasInputSelectionFrame;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.InputSelectionFrame.Added());
    }

    private void SelectByFrame(Rect selectionRect)
    {
        foreach (var selectable in selectableGroup)
        {
            Vector3 unitCenter = Camera.main.WorldToScreenPoint(selectable.view.gameObject.transform.position);
            if (selectionRect.Contains(unitCenter))
            {
                selectable.isSelected = true;
            }
        }
    }

    private void SelectByRay()
    {
        InputEntity pointerPosition = pointerGroup.Last();
        Ray mouseRay = Camera.main.ScreenPointToRay(pointerPosition.inputPointerPosition.position);
        RaycastHit hit;
        if (Physics.Raycast(mouseRay, out hit, float.PositiveInfinity, LayerMask.GetMask("Selectable")))
        {
            GameEntity linkedEntity = (GameEntity)hit.collider.gameObject.GetEntityLink().entity;
            if (linkedEntity != null)
            {                
                linkedEntity.isSelected = true;
            }
        }
    }

    private void DeselectAll()
    {
        foreach (var entity in selectedEntities.GetEntities())
        {
            entity.isSelected = false;
        }
    }
}
