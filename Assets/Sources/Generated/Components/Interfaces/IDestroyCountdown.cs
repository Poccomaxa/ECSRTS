//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityInterfaceGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public interface IDestroyCountdown {

    DestroyCountdownComponent destroyCountdown { get; }
    bool hasDestroyCountdown { get; }

    void AddDestroyCountdown(float newTimeToLive);
    void ReplaceDestroyCountdown(float newTimeToLive);
    void RemoveDestroyCountdown();
}
