
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public string keypadCode;
    
    private void OnEnable() => SceneManager.sceneLoaded += OnSceneLoaded;
    private void OnDisable() => SceneManager.sceneLoaded -= OnSceneLoaded;
    private void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        Debug.Log("Scene loaded: " + scene.name);
        Debug.Log("Mode: " + mode);

        switch(scene.name) {
            case("TitleScreen"):
            case("PauseMenu"):
            case("Credits"):
            case("Help"):
                break;
            case("Level1"):
                // do stuff here
                break;
            case("Level2"):
                // etc
                break;
            case("Basic"):
            case("LevelTemplate"):
                keypadCode = "TESTCODE";
                break;
            default:
                Debug.Log("Case not in switch, doing nothing.");
                break;
        }
    }
}
