using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Routes : MonoBehaviour
{
    public int atkTeam1;
    public int atkTeam2;

    public int hpTeam1 = 5;
    public int hpTeam2 = 5;

    PointManager ptsManager;

    void Start()
    {
        ptsManager = GameObject.Find("GameManager").GetComponent<PointManager>();
    }

    private void Update()
    {
        if(atkTeam1 < 0)
        {
            atkTeam1 = 0;
        }
        if (atkTeam2 < 0)
        {
            atkTeam2 = 0;
        }
    }

    public IEnumerator OnRoundEnd()
    {
        yield return new WaitForSeconds(0.1f);
        hpTeam1 -= atkTeam2;
        hpTeam2 -= atkTeam1;

        if(hpTeam1 == hpTeam2 && hpTeam1 <= 0)
        {
            print("Empate em uma rota");
        }
        else if(hpTeam1 <= 0)
        {
            ptsManager.ptsTeam2++;
            print("Team 2 Ganhou uma rota");
        }
        else if(hpTeam2 <= 0)
        {
            ptsManager.ptsTeam1++;
            print("Team 1 Ganhou uma rota");
        }
        else
        {
            OnRoundEnd();
        }
    }

    public void Reset()
    {
        hpTeam1 = 0;
        hpTeam2 = 0;
        atkTeam1 = 0;
        atkTeam2 = 0;
    }
}
