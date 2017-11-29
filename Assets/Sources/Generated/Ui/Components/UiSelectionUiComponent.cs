//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class UiContext {

    public UiEntity selectionUiEntity { get { return GetGroup(UiMatcher.SelectionUi).GetSingleEntity(); } }

    public bool isSelectionUi {
        get { return selectionUiEntity != null; }
        set {
            var entity = selectionUiEntity;
            if (value != (entity != null)) {
                if (value) {
                    CreateEntity().isSelectionUi = true;
                } else {
                    entity.Destroy();
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class UiEntity {

    static readonly SelectionUiComponent selectionUiComponent = new SelectionUiComponent();

    public bool isSelectionUi {
        get { return HasComponent(UiComponentsLookup.SelectionUi); }
        set {
            if (value != isSelectionUi) {
                var index = UiComponentsLookup.SelectionUi;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : selectionUiComponent;

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
public sealed partial class UiMatcher {

    static Entitas.IMatcher<UiEntity> _matcherSelectionUi;

    public static Entitas.IMatcher<UiEntity> SelectionUi {
        get {
            if (_matcherSelectionUi == null) {
                var matcher = (Entitas.Matcher<UiEntity>)Entitas.Matcher<UiEntity>.AllOf(UiComponentsLookup.SelectionUi);
                matcher.componentNames = UiComponentsLookup.componentNames;
                _matcherSelectionUi = matcher;
            }

            return _matcherSelectionUi;
        }
    }
}