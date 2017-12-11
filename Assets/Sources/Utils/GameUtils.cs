using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameUtils {
    public static bool IsEnoughResource(GameContext context, PlayerInventoryComponent inventory, GameResource resource, int amount)
    {
        if (inventory.resourceIndex.ContainsKey(resource))
        {
            GameEntity resourceEntity = context.GetEntityWithId(inventory.resourceIndex[resource]);
            if (resourceEntity != null)
            {
                return resourceEntity.resourceQuantity.quantity >= amount;
            }
        }

        return false;
    }
}
