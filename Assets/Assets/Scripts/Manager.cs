using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject card;
    GameObject cardBuy;
    GameObject[] cartas;
    Vector3[] cardPositions;

    void Start()
    {
        cartas = GameObject.FindGameObjectsWithTag("Card");
        cardBuy = GameObject.Find("Comprar");
        foreach (GameObject carta in cartas)
        {
            int index = 0;
            cardPositions[index] = carta.transform.position;
            index++;
        }
    }

    void Update()
    {
        
    }

    public void Buy()
    {
        if(cartas.Length <= 5)
        {
            foreach (GameObject carta in cartas)
            {
                int index = 0;
                if(carta != null)
                {
                    GameObject comprada = Instantiate(card, cardBuy.transform);
                    comprada.transform.localScale = new Vector3(2.7678f, 0.154533f, 5.366488f);
                    comprada.transform.position = Vector3.MoveTowards(comprada.transform.position, cardPositions[index], 0.5f);
                    return;
                }
                index++;
            }
        }
    }
}
