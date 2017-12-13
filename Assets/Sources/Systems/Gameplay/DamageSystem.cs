using System;
using System.Collections.Generic;
using Entitas;

public class DamageSystem : ReactiveSystem<GameEntity>
{
    GameContext gameContext;
    public DamageSystem(Contexts contexts) : base(contexts.game)
    {
        gameContext = contexts.game;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            GameEntity entityToDamage = gameContext.GetEntityWithId(entity.damageAction.targetId);
            if (entityToDamage != null && entityToDamage.hasHealth)
            {
                entityToDamage.ReplaceHealth(entityToDamage.health.health - entity.damageAction.damage);
                if (entityToDamage.health.health < 0)
                {
                    entityToDamage.isDestroyed = true;
                }
            }
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isAct && entity.hasDamageAction;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Act, GameMatcher.DamageAction)); 
    }
}