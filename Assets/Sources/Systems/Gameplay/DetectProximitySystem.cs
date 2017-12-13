using System;
using System.Collections.Generic;
using Entitas;

public class DetectProximitySystem : ReactiveSystem<GameEntity>
{
    IGroup<GameEntity> proximitySeekingEntities;
    public DetectProximitySystem(Contexts contexts) : base(contexts.game)
    {
        proximitySeekingEntities = contexts.game.GetGroup(GameMatcher.DetectProximity);
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var detectEntity in proximitySeekingEntities.GetEntities())
        {
            HashSet<int> detectedEntities = new HashSet<int>();
            foreach (var entity in entities)
            {
                if (entity.id.value == detectEntity.id.value)
                {
                    continue;
                }

                if (entity.hasParentLink && entity.parentLink.parentId == detectEntity.id.value)
                {
                    continue;
                }

                if ((detectEntity.position.position - entity.position.position).sqrMagnitude <= detectEntity.detectProximity.sqrDistance)
                {
                    detectedEntities.Add(entity.id.value);
                }
            }

            if (!detectEntity.hasDetectedProximityEntities || !detectEntity.detectedProximityEntities.entities.SetEquals(detectedEntities))
            {
                detectEntity.ReplaceDetectedProximityEntities(detectedEntities);
            }
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasPosition;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Position.Added());
    }
}