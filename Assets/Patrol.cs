using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed, startWaitTime, finishTime;
    private float waitTime;

    public Transform[] moveSpots;

    public Transform[] finalSpots
    ;

    private int randomSpot;
    private int randomFinalSpot;

    void Start()
    {
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
        randomFinalSpot = Random.Range(0, finalSpots.Length);

        for (int i = 0; i < moveSpots.Length; i++) {
            moveSpots[i] = GameObject.Find("MoveSpot" + i).transform;
        }

        for (int i = 0; i < finalSpots.Length; i++) {
            finalSpots[i] = GameObject.Find("FinalSpot" + i).transform;
        }
    }

    void Update()
    {
        if (finishTime > 0) {
            transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
            finishTime -= Time.deltaTime;
        }
        else {
            transform.position = Vector2.MoveTowards(transform.position, finalSpots[randomFinalSpot].position, speed * Time.deltaTime);
        }

        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f) {
            if (waitTime <= 0) {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            }
            else {
                waitTime -= Time.deltaTime;
            }
        }

        if (Vector2.Distance(transform.position, finalSpots[randomFinalSpot].position) < 0.2f) {
            Destroy(gameObject);
        }
    }
}
