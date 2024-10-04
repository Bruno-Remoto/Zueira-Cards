using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PointManager : MonoBehaviour
{
    public GameObject rota1;
    public GameObject rota2;
    public GameObject rota3;
    public GameObject rota4;
    public GameObject rota5;

    public Text txtGanhou1;
    public Text txtGanhou2;

    public Text txtWin1;
    public Text txtWin2;

    public Text txtEmpate;

    public Text Vidas1;
    public Text Vidas2;

    public int ptsTeam1;
    public int ptsTeam2;

    static public int hpTeam1 = 4;
    static public int manaTeam1 = 10;
    static public int hpTeam2 = 4;
    static public int manaTeam2 = 10;
    void Start()
    {
        txtGanhou1.enabled = false;
        txtGanhou2.enabled = false;
        txtWin1.enabled = false;
        txtWin2.enabled = false;
        txtEmpate.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vidas1.text = "Vidas Time 1: " + hpTeam1;
        Vidas2.text = "Vidas Time 2: " + hpTeam2;
    }
    public void EncerrarRound()
    {
        //rota1.GetComponent<Routes>().OnRoundEnd();
        //rota2.GetComponent<Routes>().OnRoundEnd();
        //rota3.GetComponent<Routes>().OnRoundEnd();
        //rota4.GetComponent<Routes>().OnRoundEnd();
        //rota5.GetComponent<Routes>().OnRoundEnd();
    }

    public IEnumerator CalcularPts()
    {
        yield return new WaitForSeconds(1);
        print("pts Team 1: " +  ptsTeam1);
        print("pts Team 2:" + ptsTeam2);
        if(ptsTeam1 > ptsTeam2)
        {
            hpTeam2--;
            print("Team 1 ganhou");
            txtGanhou1.enabled = true;
            StartCoroutine(Hide1Sec(txtGanhou1));
        }
        else if(ptsTeam1 < ptsTeam2)
        {
            hpTeam1--;
            print("Team 2 ganhou");
            txtGanhou2.enabled = true;
            StartCoroutine(Hide1Sec(txtGanhou2));
        }
        else
        {
            txtEmpate.enabled = true;
            StartCoroutine(Hide1Sec(txtEmpate));
        }
        
        if (hpTeam1 <= 0)
        {
            print("Team 2 venceu o jogo");
            txtGanhou2.enabled = false;
            txtWin2.enabled = true;
            StartCoroutine(Hide1Sec(txtWin2));
            StartCoroutine(WaitToLoadMenu());
        }
        else if(hpTeam2 <= 0)
        {
            print("Team 1 venceu o jogo");
            txtGanhou1.enabled = false;
            txtWin1.enabled = true;
            StartCoroutine(Hide1Sec(txtWin1));
            StartCoroutine(WaitToLoadMenu());
        }
        ptsTeam1 = 0;
        ptsTeam2 = 0;
        //rota1.GetComponent<Routes>().Reset();
        //rota2.GetComponent<Routes>().Reset();
        //rota3.GetComponent<Routes>().Reset();
        //rota4.GetComponent<Routes>().Reset();
        //rota5.GetComponent<Routes>().Reset();
    }

    IEnumerator Hide1Sec(Text txt)
    {
        yield return new WaitForSeconds(3);
        txt.enabled = false;
    }

    IEnumerator WaitToLoadMenu()
    {
        yield return new WaitForSeconds(3.1f);
        SceneManager.LoadScene("Menu");
    }
}