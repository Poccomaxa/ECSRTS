//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class UiEntity {

    public AssetComponent asset { get { return (AssetComponent)GetComponent(UiComponentsLookup.Asset); } }
    public bool hasAsset { get { return HasComponent(UiComponentsLookup.Asset); } }

    public void AddAsset(string newAssetPath) {
        var index = UiComponentsLookup.Asset;
        var component = CreateComponent<AssetComponent>(index);
        component.assetPath = newAssetPath;
        AddComponent(index, component);
    }

    public void ReplaceAsset(string newAssetPath) {
        var index = UiComponentsLookup.Asset;
        var component = CreateComponent<AssetComponent>(index);
        component.assetPath = newAssetPath;
        ReplaceComponent(index, component);
    }

    public void RemoveAsset() {
        RemoveComponent(UiComponentsLookup.Asset);
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
public partial class UiEntity : IAsset { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class UiMatcher {

    static Entitas.IMatcher<UiEntity> _matcherAsset;

    public static Entitas.IMatcher<UiEntity> Asset {
        get {
            if (_matcherAsset == null) {
                var matcher = (Entitas.Matcher<UiEntity>)Entitas.Matcher<UiEntity>.AllOf(UiComponentsLookup.Asset);
                matcher.componentNames = UiComponentsLookup.componentNames;
                _matcherAsset = matcher;
            }

            return _matcherAsset;
        }
    }
}
