//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public NavigationTargetComponent navigationTarget { get { return (NavigationTargetComponent)GetComponent(GameComponentsLookup.NavigationTarget); } }
    public bool hasNavigationTarget { get { return HasComponent(GameComponentsLookup.NavigationTarget); } }

    public void AddNavigationTarget(UnityEngine.Vector3 newTarget) {
        var index = GameComponentsLookup.NavigationTarget;
        var component = CreateComponent<NavigationTargetComponent>(index);
        component.target = newTarget;
        AddComponent(index, component);
    }

    public void ReplaceNavigationTarget(UnityEngine.Vector3 newTarget) {
        var index = GameComponentsLookup.NavigationTarget;
        var component = CreateComponent<NavigationTargetComponent>(index);
        component.target = newTarget;
        ReplaceComponent(index, component);
    }

    public void RemoveNavigationTarget() {
        RemoveComponent(GameComponentsLookup.NavigationTarget);
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

    static Entitas.IMatcher<GameEntity> _matcherNavigationTarget;

    public static Entitas.IMatcher<GameEntity> NavigationTarget {
        get {
            if (_matcherNavigationTarget == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.NavigationTarget);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherNavigationTarget = matcher;
            }

            return _matcherNavigationTarget;
        }
    }
}
