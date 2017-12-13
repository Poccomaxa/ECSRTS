//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public FollowComponent follow { get { return (FollowComponent)GetComponent(GameComponentsLookup.Follow); } }
    public bool hasFollow { get { return HasComponent(GameComponentsLookup.Follow); } }

    public void AddFollow(float newSpeed) {
        var index = GameComponentsLookup.Follow;
        var component = CreateComponent<FollowComponent>(index);
        component.speed = newSpeed;
        AddComponent(index, component);
    }

    public void ReplaceFollow(float newSpeed) {
        var index = GameComponentsLookup.Follow;
        var component = CreateComponent<FollowComponent>(index);
        component.speed = newSpeed;
        ReplaceComponent(index, component);
    }

    public void RemoveFollow() {
        RemoveComponent(GameComponentsLookup.Follow);
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

    static Entitas.IMatcher<GameEntity> _matcherFollow;

    public static Entitas.IMatcher<GameEntity> Follow {
        get {
            if (_matcherFollow == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Follow);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherFollow = matcher;
            }

            return _matcherFollow;
        }
    }
}
