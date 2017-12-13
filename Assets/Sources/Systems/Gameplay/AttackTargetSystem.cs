using System;
using System.Collections.Generic;
using Entitas;

public class AttackTargetSystem : ReactiveSystem<GameEntity>
{
    GameContext gameContext;
    public AttackTargetSystem(Contexts contexts) : base(contexts.game)
    {
        gameContext = contexts.game;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            GameEntity source = gameContext.GetEntityWithId(entity.attackTargetAction.attackerId);
            if (source != null)
            {
                GameEntity bulletEntity = gameContext.CreateEntity();
                bulletEntity.AddAsset("Prefabs/Bullet");
                bulletEntity.AddPosition(source.position.position);
                bulletEntity.AddFollow(40f);
                bulletEntity.AddTargetLink(entity.attackTargetAction.targetId);
            }
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasAttackTargetAction && entity.isAct;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.AttackTargetAction, GameMatcher.Act));
    }
}