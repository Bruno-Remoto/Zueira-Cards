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
    void Start()
    {
        tipoCarta = Random.Range(1, 3);
        team = Random.Range(1, 3);
        if(tipoCarta == 1) // Carta de Ataque
        {
            cardName = "Guerreiro";
            atk = Random.Range(1, 6);
            def = Random.Range(0, 6);
            hp = Random.Range(5, 11);
        }
        else if(tipoCarta == 2) // Carta de Terreno
        {
            cardName = "Terreno";
            atk = Random.Range(1, 6);
        }

        if(team == 1)
        {
            if(gameObject != null)
            {
                GetComponent<Renderer>().material.color = Color.blue;
            }
        }

        else if(team == 2)
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
            transform.position = new Vector3(4.5f, 4.15f, -11.92f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Rota")
        {
            GameObject.Find("GameManager").GetComponent<Manager>().cardPosition = startPosition;
            Destroy(gameObject);
            if(team == 1)
            {
                if(tipoCarta == 1)
                {
                    print("Invocou Guerreiro com " + atk + " de ataque.");
                    collision.gameObject.GetComponent<Routes>().atkTeam1 += atk;
                    collision.gameObject.GetComponent<Routes>().hpTeam1 += hp;
                }
                else
                {
                    print("Invocou Terreno com " + atk + " de debuff.");
                    collision.gameObject.GetComponent<Routes>().atkTeam2 -= atk;
                }
            }
            else
            {
                if (tipoCarta == 1)
                {
                    print("Invocou Guerreiro com " + atk + " de ataque.");
                    collision.gameObject.GetComponent<Routes>().atkTeam2 += atk;
                    collision.gameObject.GetComponent<Routes>().hpTeam2 += hp;
                }
                else
                {
                    print("Invocou Terreno com " + atk + " de debuff.");
                    collision.gameObject.GetComponent<Routes>().atkTeam1 -= atk;
                }
            }
        }
    }
}
