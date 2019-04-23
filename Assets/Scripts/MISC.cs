using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MISC
{
    public static bool ContinentsIntersect(Continent _a, Continent _b)
    {
        return Distance2D(_a.GetPosition(), _b.GetPosition()) <= (_a.GetRadius() + _b.GetRadius());
    }

    public static float Distance2D(Vector2 _a, Vector2 _b)
    {
        return Mathf.Sqrt(Mathf.Pow(_a.x - _b.x, 2) + Mathf.Pow(_a.y - _b.y, 2));
    }
}
