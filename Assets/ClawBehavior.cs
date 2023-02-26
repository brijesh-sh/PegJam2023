using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawBehavior : MonoBehaviour
{
    public GameObject claw;
    public KeyCode dropClaw = KeyCode.S;

    public Vector3 dropPos;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(dropClaw)) {
            Instantiate(claw, transform.position, Quaternion.identity);
        }
    }
}
