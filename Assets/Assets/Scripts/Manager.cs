using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject card;
    GameObject cardBuy1;
    GameObject[] cartas1;
    GameObject[] posicoes1;

    GameObject cardBuy2;
    GameObject[] cartas2;
    GameObject[] posicoes2;
    public Vector3 cardPosition;

    void Start()
    {
        cartas1 = GameObject.FindGameObjectsWithTag("Card1");
        posicoes1 = GameObject.FindGameObjectsWithTag("Posicao1");
        cardBuy1 = GameObject.FindGameObjectWithTag("Compra1");

        cartas2 = GameObject.FindGameObjectsWithTag("Card2");
        posicoes2 = GameObject.FindGameObjectsWithTag("Posicao2");
        cardBuy2 = GameObject.FindGameObjectWithTag("Compra2");
    }

    void Update()
    {

    }

    public void Buy1()
    {
        for (int index = 0; index < 5; index++)
        {
            if (cartas1[index] == null)
            {
                GameObject comprada = Instantiate(card);
                comprada.tag = "Card1";
                comprada.GetComponent<Controller>().team = 1;
                comprada.GetComponent<Controller>().CompareTeam();
                comprada.GetComponent<Controller>().cardPos = posicoes1[index];
                comprada.transform.position = posicoes1[index].transform.position;
                cartas1[index] = comprada;
                return;
            }
        }
    }
    public void Buy2()
    {
        for (int index = 0; index < 5; index++)
        {
            if (cartas2[index] == null)
            {
                GameObject comprada = Instantiate(card);
                comprada.tag = "Card2";
                comprada.GetComponent<Controller>().team = 2;
                comprada.GetComponent<Controller>().CompareTeam();
                comprada.GetComponent<Controller>().cardPos = posicoes2[index];
                comprada.transform.position = posicoes2[index].transform.position;
                cartas2[index] = comprada;
                return;
            }
        }
    }
}