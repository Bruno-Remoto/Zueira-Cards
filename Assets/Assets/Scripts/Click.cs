using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms;

public class Click : MonoBehaviour
{
    public GameObject ultimaCarta;
    Vector3 vaila;
    bool canGo = false;
    public Text nameText;
    public Text hpText;
    public Text defText;
    public Text atkText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit local;
            if (Physics.Raycast(raio, out local))
            {
                if(local.collider.transform.tag == "Card")
                {
                    print("Pegou Carta");
                    if(ultimaCarta == null)
                    {
                        local.collider.GetComponent<Controller>().startPosition = local.collider.transform.position;
                        local.collider.GetComponent<Controller>().isHeld = true;
                        ultimaCarta = local.collider.gameObject;
                    }
                    else if (ultimaCarta != local.collider.gameObject)
                    {
                        ultimaCarta.GetComponent<Controller>().isHeld = false;
                        ultimaCarta.transform.position = ultimaCarta.GetComponent<Controller>().startPosition;
                        local.collider.GetComponent<Controller>().startPosition = local.collider.transform.position;
                        local.collider.GetComponent<Controller>().isHeld = true;
                        ultimaCarta = local.collider.gameObject;
                    }
                    else if (ultimaCarta == local.collider.gameObject)
                    {
                        ultimaCarta.GetComponent<Controller>().isHeld = false;
                        ultimaCarta.transform.position = ultimaCarta.GetComponent<Controller>().startPosition;
                        ultimaCarta = null;
                    }
                }
                else if(local.collider.transform.tag == "Rota")
                {
                    ultimaCarta.GetComponent<Controller>().isHeld = false;
                    canGo = true;
                    vaila = local.collider.transform.position;
                }
            }
        }
        if (canGo && ultimaCarta != null)
        {
            ultimaCarta.transform.position = Vector3.MoveTowards(ultimaCarta.transform.position, vaila, 1);
        }
        if (ultimaCarta == null)
        {
            canGo = false;
            nameText.enabled = false;
            hpText.enabled = false;
            defText.enabled = false;
            atkText.enabled = false;
        }
        else
        {
            nameText.enabled = true;
            nameText.text = ultimaCarta.GetComponent<Controller>().cardName;

            hpText.enabled = true;
            hpText.text = "HP: " + ultimaCarta.GetComponent<Controller>().hp;

            defText.enabled = true;
            defText.text = "DEF: " + ultimaCarta.GetComponent<Controller>().def;

            atkText.enabled = true;
            atkText.text = "ATK: " + ultimaCarta.GetComponent<Controller>().atk;
        }
    }
}
