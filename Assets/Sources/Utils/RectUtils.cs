using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RectUtils
{
    public static Rect CreateFromPoints(Vector2 a, Vector2 b)
    {
        return Rect.MinMaxRect(Mathf.Min(a.x, b.x), Mathf.Min(a.y, b.y), Mathf.Max(a.x, b.x), Mathf.Max(a.y, b.y));
    }
}
