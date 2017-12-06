//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public NavigationObjectTargetComponent navigationObjectTarget { get { return (NavigationObjectTargetComponent)GetComponent(GameComponentsLookup.NavigationObjectTarget); } }
    public bool hasNavigationObjectTarget { get { return HasComponent(GameComponentsLookup.NavigationObjectTarget); } }

    public void AddNavigationObjectTarget(int newEntityId) {
        var index = GameComponentsLookup.NavigationObjectTarget;
        var component = CreateComponent<NavigationObjectTargetComponent>(index);
        component.entityId = newEntityId;
        AddComponent(index, component);
    }

    public void ReplaceNavigationObjectTarget(int newEntityId) {
        var index = GameComponentsLookup.NavigationObjectTarget;
        var component = CreateComponent<NavigationObjectTargetComponent>(index);
        component.entityId = newEntityId;
        ReplaceComponent(index, component);
    }

    public void RemoveNavigationObjectTarget() {
        RemoveComponent(GameComponentsLookup.NavigationObjectTarget);
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

    static Entitas.IMatcher<GameEntity> _matcherNavigationObjectTarget;

    public static Entitas.IMatcher<GameEntity> NavigationObjectTarget {
        get {
            if (_matcherNavigationObjectTarget == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.NavigationObjectTarget);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherNavigationObjectTarget = matcher;
            }

            return _matcherNavigationObjectTarget;
        }
    }
}
