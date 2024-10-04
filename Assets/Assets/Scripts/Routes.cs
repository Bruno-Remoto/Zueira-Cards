using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Routes : MonoBehaviour
{
    public int atkTeam1;
    public int atkTeam2;

    /*public int hpTeam1 = 5;
    public int hpTeam2 = 5;*/

    public float affectAmount1Team1;
    public string affectType1Team1;
    public string affectStatus1Team1;

    public float affectAmount2Team1;
    public string affectType2Team1;
    public string affectStatus2Team1;

    public float affectAmount1Team2;
    public string affectType1Team2;
    public string affectStatus1Team2;

    public float affectAmount2Team2;
    public string affectType2Team2;
    public string affectStatus2Team2;

    public GameObject AttackerTeam1;
    public GameObject AttackerTeam2;

    public GameObject[] Team1Cards;
    public GameObject[] Team2Cards;

    PointManager ptsManager;

    void Start()
    {
        ptsManager = GameObject.Find("GameManager").GetComponent<PointManager>();
    }

    private void Update()
    {
        
    }

    void CalculateAttackersDmg(GameObject Attacker)
    {
        if (!Attacker.GetComponent<Attacker>().activeCard)
        {
            /*if(Attacker.GetComponent<Attacker>().team == 1)
            {
                Attacker.GetComponent<Attacker>().ReceiveBuff(true, buffTeam1,buffTeam1Type, "Damage");
                Attacker.GetComponent<Attacker>().ReceiveBuff(true, debuffTeam1, debuffTeam1Type, "Health");
            }
            if (Attacker.GetComponent<Attacker>().team == 2)
            {
                Attacker.GetComponent<Attacker>().ReceiveBuff(true, buffTeam2, buffTeam2Type, "Damage");
                Attacker.GetComponent<Attacker>().ReceiveBuff(true, debuffTeam2, debuffTeam2Type, "Health");
            }*/
        }
    }
    public IEnumerator Skirmish()
    {
        bool team1Lost = false;
        bool team2Lost = false;

        AttackerTeam1.GetComponent<Attacker>().CompareType(AttackerTeam2.GetComponent<Attacker>().type);
        float dmgTeam1 = AttackerTeam1.GetComponent<Attacker>().CalculateHitDamage();

        AttackerTeam2.GetComponent<Attacker>().CompareType(AttackerTeam1.GetComponent<Attacker>().type);
        float dmgTeam2 = AttackerTeam2.GetComponent<Attacker>().CalculateHitDamage();


        bool attacker1Dead = AttackerTeam1.GetComponent<Attacker>().TakeDamageAndCheckDeath(dmgTeam2);
        if (attacker1Dead)
        {
            team1Lost = AttackerDead("Team1");
        }
        bool attacker2Dead = AttackerTeam2.GetComponent<Attacker>().TakeDamageAndCheckDeath(dmgTeam1);
        if (attacker2Dead)
        {
            team2Lost = AttackerDead("Team2");
        }
        yield return new WaitForSeconds(2);
        if (!team1Lost && !team2Lost)
        {
            //Ambos ainda vivos
            Skirmish();
        }
        else if (team1Lost && !team2Lost)
        {
            //Time 1 Perdeu
            print("Time 1 Perdeu");
        }
        else if (!team1Lost && team2Lost)
        {
            //Time 2 Perdeu
            print("Time 2 Perdeu");
        }
        else
        {
            //Empate
            print("Empatou");
        }
    }
    bool AttackerDead(string Team)
    {
        bool lost = false;
        if(Team == "Team1")
        {
            AttackerTeam1 = Team1Cards[0];
            for(int index = 1; index >= Team1Cards.Length; index++)
            {
                int previousIndex = index--;
                if(index <= 0)
                {
                    AttackerTeam1 = Team1Cards[index];
                    Team1Cards[index] = null;
                }
                else
                {
                    Team1Cards[previousIndex] = Team1Cards[index];
                    Team1Cards[index] = null;
                }
            }
            if (Team1Cards.Length <= 0 && AttackerTeam1 == null)
            {
                lost = true;
            }
        }
        if (Team == "Team2")
        {
            AttackerTeam2 = Team2Cards[0];
            for (int index = 1; index >= Team2Cards.Length; index++)
            {
                int previousIndex = index--;
                if(index <= 0)
                {
                    AttackerTeam2 = Team2Cards[index];
                    Team2Cards[index] = null;
                }
                else
                {
                    Team2Cards[previousIndex] = Team2Cards[index];
                    Team2Cards[index] = null;
                }
            }
            if (Team2Cards.Length <= 0 )
            {
                lost = true;
            }
        }
        return lost;
    }
    /*public void OnRoundEnd()
    {
        print("Hp 1 : " + hpTeam1);
        print("Hp 2 : " + hpTeam2);
        hpTeam1 -= atkTeam2;
        hpTeam2 -= atkTeam1;
        if (hpTeam1 < 0 && hpTeam2 < 0)
        {
            print("Empate em uma rota");
        }
        else if (hpTeam1 < 0)
        {
            if(hpTeam2 > 0)
            {
                print("Team 2 Ganhou uma rota");
                ptsManager.ptsTeam2++;
            }
        }
        else if(hpTeam2 < 0)
        {
            if(hpTeam1 > 0)
            {
                print("Team 1 Ganhou uma rota");
                ptsManager.ptsTeam1++;
            }
        }
        else
        {
            OnRoundEnd();
        }
    }*/
}
