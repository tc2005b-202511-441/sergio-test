using UnityEngine;
using System.Collections.Generic;

public class Logic
{
    public static List<int> GeneratePlaces(int bricks)
    {
        List<int> places = new List<int>();
        for (int i = 0; i < 10; i++) places.Add(0);
        for (int b = 0; b < bricks; b++)
        {
            int place = 0;
            do // para no sobreescribir el "1"
            {
                place = Random.Range(0, 10);
            } while (places[place] == 1);
            places[place] = 1;
        }
        return places;
    }
}
