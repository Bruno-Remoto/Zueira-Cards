using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public string cardName;
    public int atk = 0;
    public int def = 0;
    public int hp = 0;
    public bool isHeld = false;
    public Vector3 startPosition;
    void Start()
    {
        cardName = "Guerreiro";
        atk = Random.Range(1, 6);
        def = Random.Range(0, 6);
        hp = Random.Range(5, 11);
    }

    // Update is called once per frame
    void Update()
    {
        if (isHeld)
        {
            transform.position = new Vector3(-1.58f, 4.15f, -11.92f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Rota")
        {
            Destroy(gameObject);
            print("Invocou Carta");
        }
    }
}
