using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lookup
{
    private List<string> continentNames_unused;
    private List<string> continentNames_used;

    public Lookup()
    {

    }

    public string GetRandomUnusedContinentName()
    {
        string name = continentNames_unused[Random.Range(0, continentNames_unused.Count + 1)];
        continentNames_unused.Remove(name);
        continentNames_used.Add(name);
        return name;
    }
}
