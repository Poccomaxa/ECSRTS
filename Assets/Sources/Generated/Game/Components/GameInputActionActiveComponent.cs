//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly InputActionActiveComponent inputActionActiveComponent = new InputActionActiveComponent();

    public bool isInputActionActive {
        get { return HasComponent(GameComponentsLookup.InputActionActive); }
        set {
            if (value != isInputActionActive) {
                var index = GameComponentsLookup.InputActionActive;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : inputActionActiveComponent;

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
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherInputActionActive;

    public static Entitas.IMatcher<GameEntity> InputActionActive {
        get {
            if (_matcherInputActionActive == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.InputActionActive);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherInputActionActive = matcher;
            }

            return _matcherInputActionActive;
        }
    }
}
