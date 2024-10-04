using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public Vector3 posP1;
    public Vector3 posP2;
    public GameObject viewDir1;
    public GameObject viewDir2;
    public bool isP1 = true;
    void Start()
    {
        transform.position = posP1;
        transform.LookAt(viewDir1.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (isP1)
            {
                isP1 = false;
                transform.position = posP2;
                transform.LookAt(viewDir2.transform.position);
            }
            else
            {
                isP1 = true;
                transform.position = posP1;
                transform.LookAt(viewDir1.transform.position);
            }
        }
    }
}
