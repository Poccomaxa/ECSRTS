//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    public InputActionComponent inputAction { get { return (InputActionComponent)GetComponent(InputComponentsLookup.InputAction); } }
    public bool hasInputAction { get { return HasComponent(InputComponentsLookup.InputAction); } }

    public void AddInputAction(InputAction newAction) {
        var index = InputComponentsLookup.InputAction;
        var component = CreateComponent<InputActionComponent>(index);
        component.action = newAction;
        AddComponent(index, component);
    }

    public void ReplaceInputAction(InputAction newAction) {
        var index = InputComponentsLookup.InputAction;
        var component = CreateComponent<InputActionComponent>(index);
        component.action = newAction;
        ReplaceComponent(index, component);
    }

    public void RemoveInputAction() {
        RemoveComponent(InputComponentsLookup.InputAction);
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
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherInputAction;

    public static Entitas.IMatcher<InputEntity> InputAction {
        get {
            if (_matcherInputAction == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.InputAction);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherInputAction = matcher;
            }

            return _matcherInputAction;
        }
    }
}
