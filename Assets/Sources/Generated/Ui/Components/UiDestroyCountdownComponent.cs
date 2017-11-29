//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class UiEntity {

    public DestroyCountdownComponent destroyCountdown { get { return (DestroyCountdownComponent)GetComponent(UiComponentsLookup.DestroyCountdown); } }
    public bool hasDestroyCountdown { get { return HasComponent(UiComponentsLookup.DestroyCountdown); } }

    public void AddDestroyCountdown(float newTimeToLive) {
        var index = UiComponentsLookup.DestroyCountdown;
        var component = CreateComponent<DestroyCountdownComponent>(index);
        component.timeToLive = newTimeToLive;
        AddComponent(index, component);
    }

    public void ReplaceDestroyCountdown(float newTimeToLive) {
        var index = UiComponentsLookup.DestroyCountdown;
        var component = CreateComponent<DestroyCountdownComponent>(index);
        component.timeToLive = newTimeToLive;
        ReplaceComponent(index, component);
    }

    public void RemoveDestroyCountdown() {
        RemoveComponent(UiComponentsLookup.DestroyCountdown);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityInterfaceGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class UiEntity : IDestroyCountdown { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class UiMatcher {

    static Entitas.IMatcher<UiEntity> _matcherDestroyCountdown;

    public static Entitas.IMatcher<UiEntity> DestroyCountdown {
        get {
            if (_matcherDestroyCountdown == null) {
                var matcher = (Entitas.Matcher<UiEntity>)Entitas.Matcher<UiEntity>.AllOf(UiComponentsLookup.DestroyCountdown);
                matcher.componentNames = UiComponentsLookup.componentNames;
                _matcherDestroyCountdown = matcher;
            }

            return _matcherDestroyCountdown;
        }
    }
}