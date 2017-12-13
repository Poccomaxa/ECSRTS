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
            var actions = gameContext.GetEntitiesWithParentLink(entity.id.value);
            foreach (var action in actions)
            {
                action.isDestroyed = true;
            }

            if (entity.detectedProximityEntities.entities.Count > 0)
            {
                int someId = entity.detectedProximityEntities.entities.First();

                GameEntity attackingAction = gameContext.CreateEntity();
                attackingAction.AddAction(true);
                attackingAction.AddChannelAction(0.2f);
                attackingAction.AddCountdown(0.4f);
                attackingAction.AddParentLink(entity.id.value);
                attackingAction.AddAttackTargetAction(entity.id.value, someId);
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
