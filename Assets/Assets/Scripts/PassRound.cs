using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassRound : MonoBehaviour
{
    Vector3 initialPos;
    void Start()
    {
        initialPos = transform.position;
    }

    void Update()
    {
        if(transform.position != initialPos)
        {
            StartCoroutine(Voltar());
        }
    }

    IEnumerator Voltar()
    {
        yield return new WaitForSeconds(0.25f);
        GameObject.Find("GameManager").GetComponent<Click>().canPass = true;
        transform.position = initialPos;
    }
}
