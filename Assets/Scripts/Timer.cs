using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    [SerializeField] GameObject timerText;
    
    [SerializeField] float time;

    [SerializeField] KeyCode exitGame = KeyCode.S;
    
    void Start()
    {
        
    }

    
    void Update()
    {   
        if (Input.GetKeyDown(exitGame)) {
            GameOver();
        }
        if (time > 0) {
            timerText.GetComponent<TextMeshProUGUI>().text = "" + time;
            time -= Time.deltaTime;
        }
        else {
            GameOver();
        }
    }

    public void GameOver() {
        Application.Quit();
    }
}
