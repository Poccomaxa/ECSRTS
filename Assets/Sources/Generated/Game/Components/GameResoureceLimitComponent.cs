//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public ResoureceLimitComponent resoureceLimit { get { return (ResoureceLimitComponent)GetComponent(GameComponentsLookup.ResoureceLimit); } }
    public bool hasResoureceLimit { get { return HasComponent(GameComponentsLookup.ResoureceLimit); } }

    public void AddResoureceLimit(int newLimit) {
        var index = GameComponentsLookup.ResoureceLimit;
        var component = CreateComponent<ResoureceLimitComponent>(index);
        component.limit = newLimit;
        AddComponent(index, component);
    }

    public void ReplaceResoureceLimit(int newLimit) {
        var index = GameComponentsLookup.ResoureceLimit;
        var component = CreateComponent<ResoureceLimitComponent>(index);
        component.limit = newLimit;
        ReplaceComponent(index, component);
    }

    public void RemoveResoureceLimit() {
        RemoveComponent(GameComponentsLookup.ResoureceLimit);
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

    static Entitas.IMatcher<GameEntity> _matcherResoureceLimit;

    public static Entitas.IMatcher<GameEntity> ResoureceLimit {
        get {
            if (_matcherResoureceLimit == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ResoureceLimit);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherResoureceLimit = matcher;
            }

            return _matcherResoureceLimit;
        }
    }
}