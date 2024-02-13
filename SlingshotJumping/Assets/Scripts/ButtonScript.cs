using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public AudioSource audioSource;
    private string sceneName;
    public Animator transition;
    public float transitionTime = 0.5f;


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

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void OnClickStart()
    {
        sceneName = "Basic";
        //LoadScene(sceneName);
        StartCoroutine(PlayAudioAndLoadScene());
    }

    public void OnClickHelp()
    {
        sceneName = "Help";
        //LoadScene(sceneName);
        StartCoroutine(PlayAudioAndLoadScene());
    }

    public void OnClickCredits()
    {
        sceneName = "Credits";
        //LoadScene(sceneName);
        StartCoroutine(PlayAudioAndLoadScene());
    }

    public void OnClickMainMenu()
    {
        sceneName = "TitleScreen";
        //LoadScene(sceneName);
        StartCoroutine(PlayAudioAndLoadScene());
    }

    public void OnClickQuit()
    {
        Debug.Log("QuitPressed");
        Application.Quit();
    }
}

