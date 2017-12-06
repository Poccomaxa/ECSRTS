//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly NavigationRecedeComponent navigationRecedeComponent = new NavigationRecedeComponent();

    public bool isNavigationRecede {
        get { return HasComponent(GameComponentsLookup.NavigationRecede); }
        set {
            if (value != isNavigationRecede) {
                var index = GameComponentsLookup.NavigationRecede;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : navigationRecedeComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherNavigationRecede;

    public static Entitas.IMatcher<GameEntity> NavigationRecede {
        get {
            if (_matcherNavigationRecede == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.NavigationRecede);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherNavigationRecede = matcher;
            }

            return _matcherNavigationRecede;
        }
    }
}