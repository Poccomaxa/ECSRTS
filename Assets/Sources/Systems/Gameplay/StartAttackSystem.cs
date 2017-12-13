using System;
using System.Linq;
using System.Collections.Generic;
using Entitas;

public class StartAttackSystem : ReactiveSystem<GameEntity>
{
    GameContext gameContext;
    public StartAttackSystem(Contexts contexts) : base(contexts.game)
    {
        gameContext = contexts.game;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            HashSet<int> enemiesInRange = new HashSet<int>(entity.detectedProximityEntities.entities.Where(index =>
            {
                GameEntity proximityEntity = gameContext.GetEntityWithId(index);
                if (proximityEntity != null)
                {
                    return proximityEntity.hasOwner && proximityEntity.owner.id != entity.owner.id;
                }
                else
                {
                    return false;
                }
            }));

            var actions = gameContext.GetEntitiesWithParentLink(entity.id.value);
            bool alreadyAttacking = false;
            foreach (var action in actions)
            {
                if (action.hasAttackTargetAction)
                {
                    if (enemiesInRange.Contains(action.attackTargetAction.targetId))
                    {
                        alreadyAttacking = true;
                    }
                    else
                    {
                        action.isDestroyed = true;
                    }
                }
            }            

            if (!alreadyAttacking && enemiesInRange.Count > 0)
            {
                int someEnemy = enemiesInRange.First();

                GameEntity attackingAction = gameContext.CreateEntity();
                attackingAction.AddAction(true);
                attackingAction.AddChannelAction(1f);
                attackingAction.AddCountdown(1f);
                attackingAction.AddParentLink(entity.id.value);
                attackingAction.AddAttackTargetAction(entity.id.value, someEnemy);
            }
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasDetectedProximityEntities;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.DetectedProximityEntities.Added());
    }
}
