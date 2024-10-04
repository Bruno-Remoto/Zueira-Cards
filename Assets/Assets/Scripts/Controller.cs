using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public string cardName;
    public int atk = 0;
    public int def = 0;
    public int hp = 0;
    public int team = 1;
    public Material azul;
    public Material vermelho;
    public int tipoCarta;
    public bool isHeld = false;
    public bool isHovered = false;
    public bool canChange = true;
    public Vector3 startPosition;
    public GameObject cardPos;
    public GameObject cardSpawn;
    void Start()
    {
        ChooseCard();
        CompareTeam();
    }

    void ChooseCard()
    {
        cardSpawn = GameObject.Find("Game Manager").GetComponent<CardStatics>().cardStatics[1];
        //int randomIndex = Random.Range(0, 8);
        /*if (GameObject.Find("Game Manager").GetComponent<CardStatics>().cardStatics[randomIndex] != null)
        {

        }
        else
        {
            print("Tried Inexistant Card");
            ChooseCard();
        }*/
    }

    public void CompareTeam()
    {
        if (team == 1)
        {
            if (gameObject != null)
            {
                GetComponent<Renderer>().material.color = Color.blue;
            }
        }

        else if (team == 2)
        {
            if (gameObject != null)
            {
                GetComponent<Renderer>().material.color = Color.red;
            }
        }
    }

    void Update()
    {
        if (isHeld)
        {
            if(team == 1)
            {
                transform.position = new Vector3(4.5f, 4.15f, -11.92f);
            }
            else
            {
                transform.position = new Vector3(-6.51f, 4.15f, 13.65f);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Rota")
        {
            GameObject.Find("GameManager").GetComponent<Manager>().cardPosition = startPosition;
            Destroy(gameObject);
            GameObject spawned = Instantiate(cardSpawn, transform.position, Quaternion.identity);
            if(spawned.GetComponent<Attacker>() != null)
            {
                spawned.GetComponent<Attacker>().team = team;
            }
            Routes RouteScript = collision.gameObject.GetComponent<Routes>();
            if(team == 1)
            {
                if (RouteScript.AttackerTeam1 == null)
                    RouteScript.AttackerTeam1 = spawned;
                else
                {
                    int index = 0;
                    foreach (GameObject card in RouteScript.Team1Cards)
                    {
                        if(card == null)
                        {
                            RouteScript.Team1Cards[index] = spawned;
                        }
                        index++;
                    }
                }

            }
        }
    }
}
