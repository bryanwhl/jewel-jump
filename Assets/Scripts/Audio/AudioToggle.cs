using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioToggle : MonoBehaviour
{
    public GameObject OnSprite;
    public GameObject OffSprite;
    public AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = AudioManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleAudio() {
        audioManager.ToggleAudio();

        OffSprite.SetActive(audioManager.muted);
        OnSprite.SetActive(!audioManager.muted);
    }
}
