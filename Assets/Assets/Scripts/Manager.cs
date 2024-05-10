using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject card;
    GameObject cardBuy;
    GameObject[] cartas;
    GameObject[] posicoes;
    public Vector3 cardPosition;

    void Start()
    {
        cartas = GameObject.FindGameObjectsWithTag("Card");
        posicoes = GameObject.FindGameObjectsWithTag("Posicoes");
        cardBuy = GameObject.FindGameObjectWithTag("Compra");
    }

    void Update()
    {
        
    }

    public void Buy()
    {
        for(int index = 0; index < 5; index++)
        {
            if(cartas[index] == null)
            {
                GameObject comprada = Instantiate(card);
                comprada.transform.position = posicoes[index].transform.position;
                cartas[index] = comprada;
                return;
            }
        }
    }
}
