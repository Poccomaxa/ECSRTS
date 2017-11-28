using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Entitas;
using System;

public class SelectionSystem : ReactiveSystem<InputEntity>
{
    InputContext context;
    IGroup<GameEntity> selectableEntites;

    public SelectionSystem(Contexts contexts) : base(contexts.input)
    {
        context = contexts.input;
        selectableEntites = contexts.game.GetGroup(GameMatcher.Selectable);
    }

    protected override void Execute(List<InputEntity> entities)
    {
        InputEntity pointerPosition = context.GetGroup(InputMatcher.InputPointerPosition).Last();
        foreach (var entity in entities)
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(pointerPosition.inputPointerPosition.position);
            RaycastHit hit;
            if (Physics.Raycast(mouseRay, out hit, float.PositiveInfinity, LayerMask.GetMask("Selectable")))
            {
                GameEntity selectedEntity = selectableEntites.GetEntities()
                        .Where(sel => sel.hasView && sel.view.gameObject == hit.collider.gameObject).First();
                selectedEntity.isSelected = true;
            }
        }
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.isInputActionStarted && entity.hasInputAction && entity.inputAction.action == InputAction.SELECT;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.InputActionStarted.Added());
    }
}
