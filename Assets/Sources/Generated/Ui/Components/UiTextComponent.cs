//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class UiEntity {

    public TextComponent text { get { return (TextComponent)GetComponent(UiComponentsLookup.Text); } }
    public bool hasText { get { return HasComponent(UiComponentsLookup.Text); } }

    public void AddText(string newText) {
        var index = UiComponentsLookup.Text;
        var component = CreateComponent<TextComponent>(index);
        component.text = newText;
        AddComponent(index, component);
    }

    public void ReplaceText(string newText) {
        var index = UiComponentsLookup.Text;
        var component = CreateComponent<TextComponent>(index);
        component.text = newText;
        ReplaceComponent(index, component);
    }

    public void RemoveText() {
        RemoveComponent(UiComponentsLookup.Text);
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

    static Entitas.IMatcher<UiEntity> _matcherText;

    public static Entitas.IMatcher<UiEntity> Text {
        get {
            if (_matcherText == null) {
                var matcher = (Entitas.Matcher<UiEntity>)Entitas.Matcher<UiEntity>.AllOf(UiComponentsLookup.Text);
                matcher.componentNames = UiComponentsLookup.componentNames;
                _matcherText = matcher;
            }

            return _matcherText;
        }
    }
}