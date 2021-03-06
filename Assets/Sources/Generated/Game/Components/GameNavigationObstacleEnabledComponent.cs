//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly NavigationObstacleEnabledComponent navigationObstacleEnabledComponent = new NavigationObstacleEnabledComponent();

    public bool isNavigationObstacleEnabled {
        get { return HasComponent(GameComponentsLookup.NavigationObstacleEnabled); }
        set {
            if (value != isNavigationObstacleEnabled) {
                var index = GameComponentsLookup.NavigationObstacleEnabled;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : navigationObstacleEnabledComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
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

    static Entitas.IMatcher<GameEntity> _matcherNavigationObstacleEnabled;

    public static Entitas.IMatcher<GameEntity> NavigationObstacleEnabled {
        get {
            if (_matcherNavigationObstacleEnabled == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.NavigationObstacleEnabled);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherNavigationObstacleEnabled = matcher;
            }

            return _matcherNavigationObstacleEnabled;
        }
    }
}
