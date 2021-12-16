using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAudio : MonoBehaviour
{
    public AudioClip hover;
    public AudioClip click;

    AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = AudioManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayHover() {
        audioManager.PlayUISFX(hover);
    }

    public void PlayClick() {
        audioManager.PlayUISFX(click);
    }
}
