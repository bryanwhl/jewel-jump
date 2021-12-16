using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAudio : MonoBehaviour
{
    public AudioClip hover;
    public AudioClip click;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = AudioManager.instance.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayHover() {
        if(!AudioManager.instance.muted) {
            audioSource.clip = hover;
            audioSource.Play();
        }
    }

    public void PlayClick() {
        if(!AudioManager.instance.muted) {
            audioSource.clip = click;
            audioSource.Play();
        }
    }
}
