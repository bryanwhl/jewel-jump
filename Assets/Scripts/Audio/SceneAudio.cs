using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneAudio : MonoBehaviour
{
    public AudioClip sceneMusic;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.PlayMusic(sceneMusic);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
