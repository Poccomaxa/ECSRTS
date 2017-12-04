//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly ResourceSourceComponent resourceSourceComponent = new ResourceSourceComponent();

    public bool isResourceSource {
        get { return HasComponent(GameComponentsLookup.ResourceSource); }
        set {
            if (value != isResourceSource) {
                var index = GameComponentsLookup.ResourceSource;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : resourceSourceComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherResourceSource;

    public static Entitas.IMatcher<GameEntity> ResourceSource {
        get {
            if (_matcherResourceSource == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ResourceSource);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherResourceSource = matcher;
            }

            return _matcherResourceSource;
        }
    }
}
