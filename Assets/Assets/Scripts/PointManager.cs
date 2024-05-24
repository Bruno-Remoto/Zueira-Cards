using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    public int ptsTeam1;
    public int ptsTeam2;

    public int hpTeam1 = 5;
    public int hpTeam2 = 5;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator CalcularPts()
    {
        yield return new WaitForSeconds(1);
        if(ptsTeam1 > ptsTeam2)
        {
            hpTeam2--;
        }
        else if(ptsTeam1 < ptsTeam2)
        {
            hpTeam1--;
        }
    }
}
