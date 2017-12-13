//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public DamageActionComponent damageAction { get { return (DamageActionComponent)GetComponent(GameComponentsLookup.DamageAction); } }
    public bool hasDamageAction { get { return HasComponent(GameComponentsLookup.DamageAction); } }

    public void AddDamageAction(int newTargetId, float newDamage) {
        var index = GameComponentsLookup.DamageAction;
        var component = CreateComponent<DamageActionComponent>(index);
        component.targetId = newTargetId;
        component.damage = newDamage;
        AddComponent(index, component);
    }

    public void ReplaceDamageAction(int newTargetId, float newDamage) {
        var index = GameComponentsLookup.DamageAction;
        var component = CreateComponent<DamageActionComponent>(index);
        component.targetId = newTargetId;
        component.damage = newDamage;
        ReplaceComponent(index, component);
    }

    public void RemoveDamageAction() {
        RemoveComponent(GameComponentsLookup.DamageAction);
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

    static Entitas.IMatcher<GameEntity> _matcherDamageAction;

    public static Entitas.IMatcher<GameEntity> DamageAction {
        get {
            if (_matcherDamageAction == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.DamageAction);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherDamageAction = matcher;
            }

            return _matcherDamageAction;
        }
    }
}
