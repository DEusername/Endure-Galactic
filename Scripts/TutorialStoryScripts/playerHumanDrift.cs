using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHumanDrift : MonoBehaviour
{
    public scene1EjectMaster scene1MasterScript;

    public float driftSpeed = 0.5f;

    private bool keepMoving = true;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(keepMoving)
        {
            transform.Translate(Vector3.up * driftSpeed * Time.deltaTime);
        }
    }
}
