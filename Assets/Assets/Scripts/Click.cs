using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms;

public class Click : MonoBehaviour
{
    public GameObject ultimaCarta;
    public GameObject hoveredCarta;

    public CameraControl CamControl;
    Vector3 vaila;
    bool canGo = false;
    public bool canPass = true;
    public Text nameText;
    public Text hpText;
    public Text atkText;

    public Text RouteHp1Text;
    public Text RouteAtk1Text;
    public Text RouteHp2Text;
    public Text RouteAtk2Text;
    void Start()
    {
        
    }

    void Update()
    {
            Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit local;
            if (Physics.Raycast(raio, out local))
            {
                RouteHp1Text.enabled = false;
                RouteAtk1Text.enabled = false;
                RouteHp2Text.enabled = false;
                RouteAtk2Text.enabled = false;
                if (local.collider.transform.tag == "Card1")
                {
                    if (CamControl.isP1 == true)
                    {
                        if (Input.GetButtonDown("Fire1"))
                        {
                            if (ultimaCarta == null)
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
                        if(hoveredCarta != null)
                        {
                            if (local.collider.GetComponent<Controller>().isHovered && local.collider.GetComponent<Controller>().canChange)
                            {
                                hoveredCarta.GetComponent<Controller>().canChange = false;
                                hoveredCarta.GetComponent<Controller>().isHovered = false;
                                hoveredCarta.transform.position = Vector3.MoveTowards(local.collider.transform.position, new Vector3(hoveredCarta.GetComponent<Controller>().cardPos.transform.position.x,
                                                                                                                                         hoveredCarta.GetComponent<Controller>().cardPos.transform.position.y + 0.7f,
                                                                                                                                         hoveredCarta.GetComponent<Controller>().cardPos.transform.position.z), 0.4f);
                            }
                            if (local.collider.gameObject != hoveredCarta)
                            {
                                hoveredCarta.GetComponent<Controller>().canChange = true;
                                hoveredCarta.GetComponent<Controller>().isHovered = false;
                                hoveredCarta.transform.position = Vector3.MoveTowards(hoveredCarta.transform.position, new Vector3(hoveredCarta.GetComponent<Controller>().cardPos.transform.position.x,
                                                                                                                                        hoveredCarta.GetComponent<Controller>().cardPos.transform.position.y - 0.7f,
                                                                                                                                        hoveredCarta.GetComponent<Controller>().cardPos.transform.position.z), 0.4f);
                                hoveredCarta = null;
                            }
                        }
                        local.collider.GetComponent<Controller>().isHovered = true;
                        hoveredCarta = local.collider.gameObject;
                        if (hoveredCarta == null && local.collider.GetComponent<Controller>().isHovered && local.collider.GetComponent<Controller>().canChange)
                        {
                            local.collider.GetComponent<Controller>().canChange = false;
                            local.collider.GetComponent<Controller>().isHovered = false;
                            local.collider.transform.position = Vector3.MoveTowards(local.collider.transform.position, new Vector3(hoveredCarta.GetComponent<Controller>().cardPos.transform.position.x,
                                                                                                                                       hoveredCarta.GetComponent<Controller>().cardPos.transform.position.y + 0.7f,
                                                                                                                                       hoveredCarta.GetComponent<Controller>().cardPos.transform.position.z), 0.4f);
                        }
                    }
                }
            if (local.collider.transform.tag == "Card2")
            {
                if (CamControl.isP1 == false)
                {
                    if (Input.GetButtonDown("Fire1"))
                    {
                        if (ultimaCarta == null)
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
                    if (hoveredCarta != null)
                    {
                        if (local.collider.GetComponent<Controller>().isHovered && local.collider.GetComponent<Controller>().canChange)
                        {
                            hoveredCarta.GetComponent<Controller>().canChange = false;
                            hoveredCarta.GetComponent<Controller>().isHovered = false;
                            hoveredCarta.transform.position = Vector3.MoveTowards(local.collider.transform.position, new Vector3(hoveredCarta.GetComponent<Controller>().cardPos.transform.position.x,
                                                                                                                                     hoveredCarta.GetComponent<Controller>().cardPos.transform.position.y + 0.7f,
                                                                                                                                     hoveredCarta.GetComponent<Controller>().cardPos.transform.position.z), 0.4f);
                        }
                        if (local.collider.gameObject != hoveredCarta)
                        {
                            hoveredCarta.GetComponent<Controller>().canChange = true;
                            hoveredCarta.GetComponent<Controller>().isHovered = false;
                            hoveredCarta.transform.position = Vector3.MoveTowards(hoveredCarta.transform.position, new Vector3(hoveredCarta.GetComponent<Controller>().cardPos.transform.position.x,
                                                                                                                                    hoveredCarta.GetComponent<Controller>().cardPos.transform.position.y - 0.7f,
                                                                                                                                    hoveredCarta.GetComponent<Controller>().cardPos.transform.position.z), 0.4f);
                            hoveredCarta = null;
                        }
                    }
                    local.collider.GetComponent<Controller>().isHovered = true;
                    hoveredCarta = local.collider.gameObject;
                    if (hoveredCarta == null && local.collider.GetComponent<Controller>().isHovered && local.collider.GetComponent<Controller>().canChange)
                    {
                        local.collider.GetComponent<Controller>().canChange = false;
                        local.collider.GetComponent<Controller>().isHovered = false;
                        local.collider.transform.position = Vector3.MoveTowards(local.collider.transform.position, new Vector3(hoveredCarta.GetComponent<Controller>().cardPos.transform.position.x,
                                                                                                                                   hoveredCarta.GetComponent<Controller>().cardPos.transform.position.y + 0.7f,
                                                                                                                                   hoveredCarta.GetComponent<Controller>().cardPos.transform.position.z), 0.4f);
                    }
                }
            }
            else if (hoveredCarta != null && local.collider.gameObject != hoveredCarta)
                {
                    hoveredCarta.GetComponent<Controller>().canChange = true;
                    hoveredCarta.GetComponent<Controller>().isHovered = false;
                    hoveredCarta.transform.position = Vector3.MoveTowards(hoveredCarta.transform.position, new Vector3(hoveredCarta.GetComponent<Controller>().cardPos.transform.position.x,
                                                                                                                                   hoveredCarta.GetComponent<Controller>().cardPos.transform.position.y - 0.7f,
                                                                                                                                   hoveredCarta.GetComponent<Controller>().cardPos.transform.position.z), 0.4f);
                    hoveredCarta = null;
                }
                else if (local.collider.transform.tag == "Rota")
                {
                    
                    if (Input.GetButtonDown("Fire1"))
                    {
                        ultimaCarta.GetComponent<Controller>().isHeld = false;
                        vaila = local.collider.transform.position;
                        canGo = true;
                    }
                }
                else if (local.collider.tag == "Compra1")
                {
                    if (CamControl.isP1)
                    {
                        if (Input.GetButtonDown("Fire1"))
                        {
                            GameObject.Find("GameManager").GetComponent<Manager>().Buy1();
                        }
                    }
                }
                else if (local.collider.tag == "Compra2")
                {
                    if (CamControl.isP1 == false)
                    {
                        if (Input.GetButtonDown("Fire1"))
                        {
                            GameObject.Find("GameManager").GetComponent<Manager>().Buy2();
                        }
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
                        GameObject.Find("GameManager").GetComponent<PointManager>().EncerrarRound();
                        StartCoroutine(GameObject.Find("GameManager").GetComponent<PointManager>().CalcularPts());
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

            if(hoveredCarta != null)
            {
                nameText.enabled = true;
                nameText.text = hoveredCarta.GetComponent<Controller>().cardName;
                if (hoveredCarta.GetComponent<Controller>().tipoCarta == 1)
                {
                    hpText.enabled = true;
                    hpText.text = "DEF: " + hoveredCarta.GetComponent<Controller>().hp;
                }
                else
                {
                    hpText.enabled = false;
                }
            }
            if (ultimaCarta != null)
            {
                if (ultimaCarta.GetComponent<Controller>().tipoCarta == 1)
                {
                    hpText.text = "DEF: " + ultimaCarta.GetComponent<Controller>().hp;
                }
            }

            if(hoveredCarta != null)
            {
                atkText.enabled = true;
                atkText.text = "ATK: " + hoveredCarta.GetComponent<Controller>().atk;
            }
            if (ultimaCarta != null)
                atkText.text = "ATK: " + ultimaCarta.GetComponent<Controller>().atk;
        }
    }
}
