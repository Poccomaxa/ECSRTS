//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class UiEntity {

    public TextViewComponent textView { get { return (TextViewComponent)GetComponent(UiComponentsLookup.TextView); } }
    public bool hasTextView { get { return HasComponent(UiComponentsLookup.TextView); } }

    public void AddTextView(UnityEngine.UI.Text newTextView) {
        var index = UiComponentsLookup.TextView;
        var component = CreateComponent<TextViewComponent>(index);
        component.textView = newTextView;
        AddComponent(index, component);
    }

    public void ReplaceTextView(UnityEngine.UI.Text newTextView) {
        var index = UiComponentsLookup.TextView;
        var component = CreateComponent<TextViewComponent>(index);
        component.textView = newTextView;
        ReplaceComponent(index, component);
    }

    public void RemoveTextView() {
        RemoveComponent(UiComponentsLookup.TextView);
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

    static Entitas.IMatcher<UiEntity> _matcherTextView;

    public static Entitas.IMatcher<UiEntity> TextView {
        get {
            if (_matcherTextView == null) {
                var matcher = (Entitas.Matcher<UiEntity>)Entitas.Matcher<UiEntity>.AllOf(UiComponentsLookup.TextView);
                matcher.componentNames = UiComponentsLookup.componentNames;
                _matcherTextView = matcher;
            }

            return _matcherTextView;
        }
    }
}
