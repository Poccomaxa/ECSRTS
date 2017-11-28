//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ContextsGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class Contexts : Entitas.IContexts {

    public static Contexts sharedInstance {
        get {
            if (_sharedInstance == null) {
                _sharedInstance = new Contexts();
            }

            return _sharedInstance;
        }
        set { _sharedInstance = value; }
    }

    static Contexts _sharedInstance;

    public GameContext game { get; set; }
    public InputContext input { get; set; }

    public Entitas.IContext[] allContexts { get { return new Entitas.IContext [] { game, input }; } }

    public Contexts() {
        game = new GameContext();
        input = new InputContext();

        var postConstructors = System.Linq.Enumerable.Where(
            GetType().GetMethods(),
            method => System.Attribute.IsDefined(method, typeof(Entitas.CodeGeneration.Attributes.PostConstructorAttribute))
        );

        foreach (var postConstructor in postConstructors) {
            postConstructor.Invoke(this, null);
        }
    }

    public void Reset() {
        var contexts = allContexts;
        for (int i = 0; i < contexts.Length; i++) {
            contexts[i].Reset();
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EntityIndexGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class Contexts {

    public const string Id = "Id";
    public const string InputAction = "InputAction";
    public const string ParentLink = "ParentLink";

    [Entitas.CodeGeneration.Attributes.PostConstructor]
    public void InitializeEntityIndices() {
        input.AddEntityIndex(new Entitas.PrimaryEntityIndex<InputEntity, int>(
            Id,
            input.GetGroup(InputMatcher.Id),
            (e, c) => ((IdComponent)c).value));
        game.AddEntityIndex(new Entitas.PrimaryEntityIndex<GameEntity, int>(
            Id,
            game.GetGroup(GameMatcher.Id),
            (e, c) => ((IdComponent)c).value));

        input.AddEntityIndex(new Entitas.EntityIndex<InputEntity, InputAction>(
            InputAction,
            input.GetGroup(InputMatcher.InputAction),
            (e, c) => ((InputActionComponent)c).action));

        game.AddEntityIndex(new Entitas.EntityIndex<GameEntity, int>(
            ParentLink,
            game.GetGroup(GameMatcher.ParentLink),
            (e, c) => ((ParentLinkComponent)c).parentId));
    }
}

public static class ContextsExtensions {

    public static InputEntity GetEntityWithId(this InputContext context, int value) {
        return ((Entitas.PrimaryEntityIndex<InputEntity, int>)context.GetEntityIndex(Contexts.Id)).GetEntity(value);
    }

    public static GameEntity GetEntityWithId(this GameContext context, int value) {
        return ((Entitas.PrimaryEntityIndex<GameEntity, int>)context.GetEntityIndex(Contexts.Id)).GetEntity(value);
    }

    public static System.Collections.Generic.HashSet<InputEntity> GetEntitiesWithInputAction(this InputContext context, InputAction action) {
        return ((Entitas.EntityIndex<InputEntity, InputAction>)context.GetEntityIndex(Contexts.InputAction)).GetEntities(action);
    }

    public static System.Collections.Generic.HashSet<GameEntity> GetEntitiesWithParentLink(this GameContext context, int parentId) {
        return ((Entitas.EntityIndex<GameEntity, int>)context.GetEntityIndex(Contexts.ParentLink)).GetEntities(parentId);
    }
}
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.VisualDebugging.CodeGeneration.Plugins.ContextObserverGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class Contexts {

#if (!ENTITAS_DISABLE_VISUAL_DEBUGGING && UNITY_EDITOR)

    [Entitas.CodeGeneration.Attributes.PostConstructor]
    public void InitializeContexObservers() {
        try {
            CreateContextObserver(game);
            CreateContextObserver(input);
        } catch(System.Exception) {
        }
    }

    public void CreateContextObserver(Entitas.IContext context) {
        if (UnityEngine.Application.isPlaying) {
            var observer = new Entitas.VisualDebugging.Unity.ContextObserver(context);
            UnityEngine.Object.DontDestroyOnLoad(observer.gameObject);
        }
    }

#endif
}
