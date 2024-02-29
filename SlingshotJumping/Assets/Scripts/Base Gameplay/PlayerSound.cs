using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Import this class on the player to play sounds.
public class PlayerSound : MonoBehaviour {
    private AudioSource source;
    [SerializeField] public AudioClip[] clips;

    private void Start() => source = GetComponent<AudioSource>();

    public void PlaySFX(string str) { //
        foreach(AudioClip selection in clips) {
            if(str == selection.name) {
                source.clip = selection;
                source.Play();
                break;
        }
            }
               
    }
}
