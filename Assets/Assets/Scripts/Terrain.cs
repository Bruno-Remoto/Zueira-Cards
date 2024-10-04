using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain : MonoBehaviour
{
    public int cost;

    public int team;

    public float affectAmount1;
    public string affectType1;
    public string affectStatus1;
    
    public float affectAmount2;
    public string affectType2;
    public string affectStatus2;

    bool AttemptSpawn()
    {
        bool success = true;
        if(team == 1)
        {
            if (cost >= PointManager.manaTeam1) { }
            else
            {
                success = false;
            }
        }
        if (team == 2)
        {
            if (cost >= PointManager.manaTeam2) { }
            else
            {
                success = false;
            }
        }
        return success;
    }
}
