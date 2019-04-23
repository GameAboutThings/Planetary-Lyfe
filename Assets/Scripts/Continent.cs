using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Continent
{
    private float lowestPoint;
    private float highestPoint;
    private Vector2 position;
    private Vector2 direction;
    private float radius;
    private string name;

    public Continent(Continent _a, Continent _b)
    {
        lowestPoint = _a.lowestPoint;
        if (_b.lowestPoint < lowestPoint)
            lowestPoint = _b.lowestPoint;

        highestPoint = _a.highestPoint;
        if (_b.highestPoint < highestPoint)
            highestPoint = _b.highestPoint;

        position = (_a.position + _b.position) / 2;
        direction = (_a.direction + _b.direction) / 2 + new Vector2(Random.value, Random.value).normalized;

        if (_a.radius > _b.radius)
            radius = _a.radius + _b.radius - Random.Range(0, _b.radius);
        else
            radius = _a.radius + _b.radius - Random.Range(0, _a.radius);
    }

    public void Tick()
    {
        position += direction;

        if (position.x > Planet.GetDimension().x)
            position.x -= Planet.GetDimension().x;
        else if (position.x < Planet.GetDimension().x)
            position.x += Planet.GetDimension().x;

        if (position.y > Planet.GetDimension().y)
            position.y -= Planet.GetDimension().y;
        else if (position.y < Planet.GetDimension().y)
            position.y += Planet.GetDimension().y;
    }

    public Vector2 GetPosition()
    {
        return position;
    }

    public float GetRadius()
    {
        return radius;
    }
}
