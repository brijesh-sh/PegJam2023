using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClawBehavior : MonoBehaviour
{
    public GameObject boat;

    public float speed, startWaitTime;
    private float waitTime;

    public Transform[] moveSpots;

    private bool clawMove = false;
    private bool intialMov = true;
    private bool nextMov = false;

    [SerializeField] public GameObject _scoreText;
    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (clawMove) {
            if (intialMov) {
                transform.position = Vector2.MoveTowards(transform.position, moveSpots[1].position, speed * Time.deltaTime);
                if (Vector2.Distance(transform.position, moveSpots[1].position) < 0.2f) {
                    if (waitTime <= 0) {
                        waitTime = startWaitTime;
                        intialMov = false;
                        nextMov = true;
                    }
                    else {
                        waitTime -= Time.deltaTime;
                    }
                }
            }
            if (nextMov) {
                transform.position = Vector2.MoveTowards(transform.position, moveSpots[0].position, speed * Time.deltaTime);
                if (Vector2.Distance(transform.position, moveSpots[0].position) < 0.2f) {
                    boat.GetComponent<PlayerMovement>().ToggleControl(true);
                    clawMove = false;
                    intialMov = true;
                    nextMov = false;
                }
            }
        }
    }

    public void Drop() {
        clawMove = true; 
    }

    void OnTriggerEnter(Collider coll) {
        if (coll.gameObject.tag == "Prawn")
        {
            Destroy(coll.gameObject);
            IncrementScore();
        }
    }

    void IncrementScore()
    {
       score++;
       _scoreText.GetComponent<TextMeshProUGUI>().text = "x " + score;
    }
}
