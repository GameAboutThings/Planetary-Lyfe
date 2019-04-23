using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField]
    private int framesPerTick = 30;
    [SerializeField]
    private int ticksPerChoice = 30;

    private static int frameCounter = 0;
    private static float seaLvl = 0f;
    private static float waterSurfacePercentage = 0f;
    private static Vector2 gridDimension = new Vector2(100, 100);
    private static List<Continent> continents;

    private static Lookup lookup;

    // Start is called before the first frame update
    void Start()
    {
        lookup = new Lookup();
    }

    // Update is called once per frame
    void Update()
    {
        frameCounter++;

        if (frameCounter < framesPerTick)
            return;

        frameCounter = 0;
        Tick();
    }

    private void Tick()
    {
        foreach (Continent c in continents)
        {
            c.Tick();
        }

        //Check collision
        bool br = true;
        do
        {
            LoopBegin:
            foreach (Continent c1 in continents)
            {
                foreach (Continent c2 in continents)
                {
                    if (MISC.ContinentsIntersect(c1, c2))
                    {
                        MergeContinents(c1, c2);
                        goto LoopBegin;
                    }
                }
            }
        } while (!br);
        
    }

    public static Vector2 GetDimension()
    {
        return gridDimension;
    }

    private static void MergeContinents(Continent _c1, Continent _c2)
    {
        continents.Remove(_c1);
        continents.Remove(_c2);
        Continent c = new Continent(_c1, _c2);
        continents.Add(c);
    }
}
