//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public NavigationAgentRadiusComponent navigationAgentRadius { get { return (NavigationAgentRadiusComponent)GetComponent(GameComponentsLookup.NavigationAgentRadius); } }
    public bool hasNavigationAgentRadius { get { return HasComponent(GameComponentsLookup.NavigationAgentRadius); } }

    public void AddNavigationAgentRadius(float newRadius) {
        var index = GameComponentsLookup.NavigationAgentRadius;
        var component = CreateComponent<NavigationAgentRadiusComponent>(index);
        component.radius = newRadius;
        AddComponent(index, component);
    }

    public void ReplaceNavigationAgentRadius(float newRadius) {
        var index = GameComponentsLookup.NavigationAgentRadius;
        var component = CreateComponent<NavigationAgentRadiusComponent>(index);
        component.radius = newRadius;
        ReplaceComponent(index, component);
    }

    public void RemoveNavigationAgentRadius() {
        RemoveComponent(GameComponentsLookup.NavigationAgentRadius);
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

    static Entitas.IMatcher<GameEntity> _matcherNavigationAgentRadius;

    public static Entitas.IMatcher<GameEntity> NavigationAgentRadius {
        get {
            if (_matcherNavigationAgentRadius == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.NavigationAgentRadius);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherNavigationAgentRadius = matcher;
            }

            return _matcherNavigationAgentRadius;
        }
    }
}
