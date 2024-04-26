using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms;

public class Click : MonoBehaviour
{
    public GameObject ultimaCarta;
    public GameObject hoveredCarta;
    Vector3 vaila;
    bool canGo = false;
    public bool canPass = true;
    public Text nameText;
    public Text hpText;
    public Text defText;
    public Text atkText;
    void Start()
    {
        
    }

    void Update()
    {
            Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit local;
            if (Physics.Raycast(raio, out local))
            {
                if (local.collider.transform.tag == "Card")
                {
                    local.collider.GetComponent<Controller>().startPosition = local.collider.transform.position;
                    if (Input.GetButtonDown("Fire1"))
                    {
                        print("Pegou Carta");
                        if (ultimaCarta == null)
                        {
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
                    if (hoveredCarta != null && local.collider.GetComponent<Controller>().isHovered && local.collider.GetComponent<Controller>().canChange)
                    {
                        hoveredCarta.GetComponent<Controller>().canChange = false;
                        hoveredCarta.GetComponent<Controller>().isHovered = false;
                        hoveredCarta.transform.position = Vector3.MoveTowards(local.collider.transform.position, new Vector3(hoveredCarta.transform.position.x,
                                                                                                                             hoveredCarta.transform.position.y + 0.7f,
                                                                                                                             hoveredCarta.transform.position.z), 0.4f);
                    }
                    local.collider.GetComponent<Controller>().isHovered = true;
                    hoveredCarta = local.collider.gameObject;
                    if (hoveredCarta == null && local.collider.GetComponent<Controller>().isHovered && local.collider.GetComponent<Controller>().canChange)
                    {
                        local.collider.GetComponent<Controller>().canChange = false;
                        local.collider.GetComponent<Controller>().isHovered = false;
                        local.collider.transform.position = Vector3.MoveTowards(local.collider.transform.position, new Vector3(hoveredCarta.transform.position.x,
                                                                                                                               hoveredCarta.transform.position.y + 0.7f,
                                                                                                                               hoveredCarta.transform.position.z), 0.4f);
                    }
                }
                else if (hoveredCarta != null && local.collider.gameObject != hoveredCarta && hoveredCarta.GetComponent<Controller>().isHovered)
                {
                    hoveredCarta.GetComponent<Controller>().canChange = true;
                    hoveredCarta.GetComponent<Controller>().isHovered = false;
                    hoveredCarta.transform.position = Vector3.MoveTowards(hoveredCarta.transform.position, new Vector3(hoveredCarta.transform.position.x,
                                                                                                                       hoveredCarta.transform.position.y - 0.7f,
                                                                                                                       hoveredCarta.transform.position.z), 0.4f);
                }
                else if (local.collider.transform.tag == "Rota")
                {
                    if (Input.GetButtonDown("Fire1"))
                    {
                        ultimaCarta.GetComponent<Controller>().isHeld = false;
                        canGo = true;
                        vaila = local.collider.transform.position;
                    }
                }
                else if (local.collider.transform.tag == "Compra")
                {
                    if (Input.GetButtonDown("Fire1"))
                    {
                        //GameObject.Find("GameManager").GetComponent<Manager>().Buy();
                    }
                }
                else if (local.collider.transform.tag == "Botao" && canPass)
                {
                    if (Input.GetButtonDown("Fire1"))
                    {
                        canPass = false;
                        local.collider.transform.position = Vector3.MoveTowards(local.collider.transform.position, new Vector3(local.collider.transform.position.x,
                                                                                                                               local.collider.transform.position.y - 0.5f,
                                                                                                                               local.collider.transform.position.z), 0.3f);
                    }
                }
        }
        if (canGo && ultimaCarta != null)
        {
            ultimaCarta.transform.position = Vector3.MoveTowards(ultimaCarta.transform.position, vaila, 1);
        }
        if (ultimaCarta == null && hoveredCarta == null)
        {
            canGo = false;
            nameText.enabled = false;
            hpText.enabled = false;
            atkText.enabled = false;
        }
        else
        {
            nameText.enabled = true;
            nameText.text = hoveredCarta.GetComponent<Controller>().cardName;
            if (ultimaCarta != null)
                nameText.text = ultimaCarta.GetComponent<Controller>().cardName;

            hpText.enabled = true;
            hpText.text = "HP: " + hoveredCarta.GetComponent<Controller>().hp;
            if (ultimaCarta != null)
                hpText.text = "HP: " + ultimaCarta.GetComponent<Controller>().hp;

            atkText.enabled = true;
            atkText.text = "ATK: " + hoveredCarta.GetComponent<Controller>().atk;
            if (ultimaCarta != null)
                atkText.text = "ATK: " + ultimaCarta.GetComponent<Controller>().atk;
        }
    }
}
