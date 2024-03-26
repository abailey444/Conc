using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;

public class ButtonScript : MonoBehaviour//
{
    public AudioSource audioSource;
    private string sceneName;
    public Animator transition;
    public float transitionTime = 1f;
    private bool pauseLoaded = false;



    public Button startButton;
    public Button quitButton;
    public Button creditsButton;
    public Button helpButton;


    IEnumerator PlayAudioAndLoadScene()
    {
        // Play AudioSource
        audioSource.Play();
        // Set trigger
        transition.SetTrigger("Start");
        // Wait for half a second
        yield return new WaitForSeconds(transitionTime);

        // Load your scene
        LoadScene(sceneName);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && pauseLoaded == false)
        {
            Pause();
        }

        
    }
    
    public void Pause()
    {
        Time.timeScale = 0f;
        pauseLoaded = true;
        SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive);
        
        
    }
    public void Resume()
    {
        SceneManager.UnloadSceneAsync("PauseMenu");
        Time.timeScale = 1f;
        pauseLoaded = false;
    }
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void LoadStart()
    {
        sceneName = "Level1";
        //LoadScene(sceneName);
        StartCoroutine(PlayAudioAndLoadScene());
    }

    public void Load2()
    {
        sceneName = "Level2";
        //LoadScene(sceneName);
        StartCoroutine(PlayAudioAndLoadScene());
    }

    public void LoadHelp()
    {
        sceneName = "Help";
        //LoadScene(sceneName);
        StartCoroutine(PlayAudioAndLoadScene());
    }

    public void LoadCredits()
    {
        sceneName = "Credits";
        //LoadScene(sceneName);
        StartCoroutine(PlayAudioAndLoadScene());
    }

    public void LoadMainMenu()
    {
        sceneName = "TitleScreen";
        //LoadScene(sceneName);
        StartCoroutine(PlayAudioAndLoadScene());
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }
}

