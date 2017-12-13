//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public TargetLinkComponent targetLink { get { return (TargetLinkComponent)GetComponent(GameComponentsLookup.TargetLink); } }
    public bool hasTargetLink { get { return HasComponent(GameComponentsLookup.TargetLink); } }

    public void AddTargetLink(int newLinkId) {
        var index = GameComponentsLookup.TargetLink;
        var component = CreateComponent<TargetLinkComponent>(index);
        component.linkId = newLinkId;
        AddComponent(index, component);
    }

    public void ReplaceTargetLink(int newLinkId) {
        var index = GameComponentsLookup.TargetLink;
        var component = CreateComponent<TargetLinkComponent>(index);
        component.linkId = newLinkId;
        ReplaceComponent(index, component);
    }

    public void RemoveTargetLink() {
        RemoveComponent(GameComponentsLookup.TargetLink);
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

    static Entitas.IMatcher<GameEntity> _matcherTargetLink;

    public static Entitas.IMatcher<GameEntity> TargetLink {
        get {
            if (_matcherTargetLink == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.TargetLink);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherTargetLink = matcher;
            }

            return _matcherTargetLink;
        }
    }
}