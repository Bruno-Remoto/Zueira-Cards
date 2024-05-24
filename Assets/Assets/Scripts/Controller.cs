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
    public bool isHeld = false;
    public bool isHovered = false;
    public bool canChange = true;
    public Vector3 startPosition;
    void Start()
    {
        cardName = "Guerreiro";
        atk = Random.Range(1, 6);
        def = Random.Range(0, 6);
        hp = Random.Range(5, 11);
        if(team == 1)
        {
            GetComponent<Material>().color = Color.blue;
        }
        else if(team == 2)
        {
            GetComponent<Material>().color = Color.red;
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
            print("Invocou Carta com " + atk + " de ataque.");

            if(team == 1)
            {
                collision.gameObject.GetComponent<Routes>().atkTeam1 += atk;
            }
            else
            {
                collision.gameObject.GetComponent<Routes>().atkTeam2 += atk;
            }
        }
    }
}
