//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class UiEntity {

    public PlayerResourceComponent playerResource { get { return (PlayerResourceComponent)GetComponent(UiComponentsLookup.PlayerResource); } }
    public bool hasPlayerResource { get { return HasComponent(UiComponentsLookup.PlayerResource); } }

    public void AddPlayerResource(GameResource newResource) {
        var index = UiComponentsLookup.PlayerResource;
        var component = CreateComponent<PlayerResourceComponent>(index);
        component.resource = newResource;
        AddComponent(index, component);
    }

    public void ReplacePlayerResource(GameResource newResource) {
        var index = UiComponentsLookup.PlayerResource;
        var component = CreateComponent<PlayerResourceComponent>(index);
        component.resource = newResource;
        ReplaceComponent(index, component);
    }

    public void RemovePlayerResource() {
        RemoveComponent(UiComponentsLookup.PlayerResource);
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
public sealed partial class UiMatcher {

    static Entitas.IMatcher<UiEntity> _matcherPlayerResource;

    public static Entitas.IMatcher<UiEntity> PlayerResource {
        get {
            if (_matcherPlayerResource == null) {
                var matcher = (Entitas.Matcher<UiEntity>)Entitas.Matcher<UiEntity>.AllOf(UiComponentsLookup.PlayerResource);
                matcher.componentNames = UiComponentsLookup.componentNames;
                _matcherPlayerResource = matcher;
            }

            return _matcherPlayerResource;
        }
    }
}
