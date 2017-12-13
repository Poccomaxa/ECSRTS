using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Ui]
public class AssetComponent : IComponent
{
    public string assetPath;
}
