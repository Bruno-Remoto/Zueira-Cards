using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Routes : MonoBehaviour
{
    public int atkTeam1;
    public int atkTeam2;

    PointManager ptsManager;

    void Start()
    {
        ptsManager = GameObject.Find("GameManager").GetComponent<PointManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnRoundEnd()
    {
        if(atkTeam1 > atkTeam2)
        {
            ptsManager.hpTeam2--;
        }
        else if(atkTeam1 < atkTeam2)
        {
            ptsManager.hpTeam1--;
        }
        else
        {
            print("Empatou");
        }
    }
}
