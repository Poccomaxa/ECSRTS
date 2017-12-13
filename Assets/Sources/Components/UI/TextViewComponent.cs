using UnityEngine.UI;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Ui]
public class TextViewComponent : IComponent
{
    public Text textView;
}

[Ui]
public class TextComponent : IComponent
{
    public string text;
}