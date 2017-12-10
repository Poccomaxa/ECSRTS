//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public ResourcesReturnedComponent resourcesReturned { get { return (ResourcesReturnedComponent)GetComponent(GameComponentsLookup.ResourcesReturned); } }
    public bool hasResourcesReturned { get { return HasComponent(GameComponentsLookup.ResourcesReturned); } }

    public void AddResourcesReturned(GameResource newResoureceType) {
        var index = GameComponentsLookup.ResourcesReturned;
        var component = CreateComponent<ResourcesReturnedComponent>(index);
        component.resourceType = newResoureceType;
        AddComponent(index, component);
    }

    public void ReplaceResourcesReturned(GameResource newResoureceType) {
        var index = GameComponentsLookup.ResourcesReturned;
        var component = CreateComponent<ResourcesReturnedComponent>(index);
        component.resourceType = newResoureceType;
        ReplaceComponent(index, component);
    }

    public void RemoveResourcesReturned() {
        RemoveComponent(GameComponentsLookup.ResourcesReturned);
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

    static Entitas.IMatcher<GameEntity> _matcherResourcesReturned;

    public static Entitas.IMatcher<GameEntity> ResourcesReturned {
        get {
            if (_matcherResourcesReturned == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ResourcesReturned);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherResourcesReturned = matcher;
            }

            return _matcherResourcesReturned;
        }
    }
}
