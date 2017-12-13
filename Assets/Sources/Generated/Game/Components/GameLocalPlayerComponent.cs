//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity localPlayerEntity { get { return GetGroup(GameMatcher.LocalPlayer).GetSingleEntity(); } }
    public LocalPlayer localPlayer { get { return localPlayerEntity.localPlayer; } }
    public bool hasLocalPlayer { get { return localPlayerEntity != null; } }

    public GameEntity SetLocalPlayer(int newId) {
        if (hasLocalPlayer) {
            throw new Entitas.EntitasException("Could not set LocalPlayer!\n" + this + " already has an entity with LocalPlayer!",
                "You should check if the context already has a localPlayerEntity before setting it or use context.ReplaceLocalPlayer().");
        }
        var entity = CreateEntity();
        entity.AddLocalPlayer(newId);
        return entity;
    }

    public void ReplaceLocalPlayer(int newId) {
        var entity = localPlayerEntity;
        if (entity == null) {
            entity = SetLocalPlayer(newId);
        } else {
            entity.ReplaceLocalPlayer(newId);
        }
    }

    public void RemoveLocalPlayer() {
        localPlayerEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public LocalPlayer localPlayer { get { return (LocalPlayer)GetComponent(GameComponentsLookup.LocalPlayer); } }
    public bool hasLocalPlayer { get { return HasComponent(GameComponentsLookup.LocalPlayer); } }

    public void AddLocalPlayer(int newId) {
        var index = GameComponentsLookup.LocalPlayer;
        var component = CreateComponent<LocalPlayer>(index);
        component.id = newId;
        AddComponent(index, component);
    }

    public void ReplaceLocalPlayer(int newId) {
        var index = GameComponentsLookup.LocalPlayer;
        var component = CreateComponent<LocalPlayer>(index);
        component.id = newId;
        ReplaceComponent(index, component);
    }

    public void RemoveLocalPlayer() {
        RemoveComponent(GameComponentsLookup.LocalPlayer);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherLocalPlayer;

    public static Entitas.IMatcher<GameEntity> LocalPlayer {
        get {
            if (_matcherLocalPlayer == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.LocalPlayer);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherLocalPlayer = matcher;
            }

            return _matcherLocalPlayer;
        }
    }
}
