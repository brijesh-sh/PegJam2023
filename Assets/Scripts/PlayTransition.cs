using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;

public class PlayTransition : MonoBehaviour
{
    Camera _camera;
    Button _play;
    Button _exit;

    [SerializeField] float _cameraSpeed = 2f;
    
    private void Awake()
    {
        _camera = Camera.main; // Retrieves camera with tag "MainCamera"
        _play = GameObject.Find("Play").GetComponent<Button>();
        _play.onClick.AddListener(showMainGame);

        _exit = GameObject.Find("Exit").GetComponent<Button>();
        _exit.onClick.AddListener(exitGame);
    }

    void showMainGame() 
    {
        SceneManager.LoadScene("Main Scene");
    }

    void exitGame()
    {
        EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
