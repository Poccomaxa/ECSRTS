//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    public CountdownComponent countdown { get { return (CountdownComponent)GetComponent(InputComponentsLookup.Countdown); } }
    public bool hasCountdown { get { return HasComponent(InputComponentsLookup.Countdown); } }

    public void AddCountdown(float newTimeLeft) {
        var index = InputComponentsLookup.Countdown;
        var component = CreateComponent<CountdownComponent>(index);
        component.timeLeft = newTimeLeft;
        AddComponent(index, component);
    }

    public void ReplaceCountdown(float newTimeLeft) {
        var index = InputComponentsLookup.Countdown;
        var component = CreateComponent<CountdownComponent>(index);
        component.timeLeft = newTimeLeft;
        ReplaceComponent(index, component);
    }

    public void RemoveCountdown() {
        RemoveComponent(InputComponentsLookup.Countdown);
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
public partial class InputEntity : ICountdown { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherCountdown;

    public static Entitas.IMatcher<InputEntity> Countdown {
        get {
            if (_matcherCountdown == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.Countdown);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherCountdown = matcher;
            }

            return _matcherCountdown;
        }
    }
}
