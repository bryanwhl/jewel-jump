using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public bool muted = false;

    public AudioSource gameSource;
    public AudioSource uiSource;
    public AudioSource musicSource;

    public List<AudioSource> playerSources;

    void Awake() {
        DontDestroyOnLoad(gameObject);
        if(instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleAudio() {
        if(muted) {
            gameSource.Play();
            uiSource.Play();
            musicSource.Play();
            muted = false;
        } else {
            gameSource.Pause();
            uiSource.Pause();
            musicSource.Pause();
            muted = true;
        }
    }

    private void PlayIfUnmuted(AudioSource source) {
        if(!muted) {
            source.Play();
        }
    }

    public void PlayUISFX(AudioClip clip) {
        uiSource.clip = clip;
        PlayIfUnmuted(uiSource);
    }

    public void PlayGameSFX(AudioClip clip) {
        gameSource.clip = clip;
        PlayIfUnmuted(gameSource);
    }

    public void PlayMusic(AudioClip clip) {
        musicSource.clip = clip;
        PlayIfUnmuted(musicSource);
    }

    public void PlayPlayerSFX(AudioClip clip, int player) {
        AudioSource playerSource = playerSources[player - 1];
        playerSource.clip = clip;
        PlayIfUnmuted(playerSource);
    }
}
