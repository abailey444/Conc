
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;
    public string keypadCode;
    public bool keyEnabled;
    public bool keyPickedUp;

    public string sceneName;
    
    private void OnEnable() => SceneManager.sceneLoaded += OnSceneLoaded;
    private void OnDisable() => SceneManager.sceneLoaded -= OnSceneLoaded;
    private void Awake() {
        if(Instance == null) {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        } else if(Instance != this) {
            Destroy(gameObject);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        Debug.Log("Scene loaded: " + scene.name);
        Debug.Log("Mode: " + mode);

        sceneName = scene.name;

        switch(scene.name) {
            case("TitleScreen"):
            case("PauseMenu"):
            case("Credits"):
            case("Help"):
                keypadCode = "";
                break;
            case("Level1"):
                keypadCode = "9642";
                keyEnabled = false;
                break;
            case("Level2"):
                keypadCode = "0002";
                keyEnabled = false;
                break;
            case("Level3"):
                keypadCode = "0003";
                keyEnabled = false;
                break;
            case("Basic"):
            case("LevelTemplate"):
                keypadCode = "1234";
                keyEnabled = false;
                break;
            default:
                Debug.Log("Case not in switch, doing nothing.");
                break;
        }
    }

    // You should call this function because 
    // most scripts should already have a 
    // GameManager on them and you shouldn't 
    // unnecessarily import UnityEngine.SceneManagement.
    public void GoToNextLevel() {        
        switch(sceneName) {
            case("Level1"):
                SceneManager.LoadScene("Level2");
                break;
            case("Level2"):
                SceneManager.LoadScene("Level3");
                break;
            case("Level3"):
                SceneManager.LoadScene("TitleScreen");
                break;
            default:
                Debug.Log("Errrrmmmmm......");
                break;
        }
    }
}
