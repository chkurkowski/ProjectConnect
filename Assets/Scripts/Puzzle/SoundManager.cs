using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public Sound[] music;

    public Sound[] sounds;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if(instance == null)
        {
            instance = this;
        }

        foreach(Sound s in sounds)
        {
           s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.clip;

            s.source.volume = s.volume;

            s.source.pitch = s.pitch;
        }

        foreach(Sound s in music)
        {
           s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.clip;

            s.source.volume = s.volume;

            s.source.pitch = s.pitch;
        }

        

    }

    private void OnEnable()
    {
        Sound wanderer = Array.Find(sounds, Sound => Sound.name == "HeadlessWanderer");

        if(SceneManager.GetActiveScene().name == "Main Menu")
        {
            StopAllMusic();
            PlayMusic("Menu");
        }
        else if(wanderer.source.isPlaying && SceneManager.GetActiveScene().name != "Main Menu")
        {
            StopAllMusic();
            PlayMusic("Game");
        }
    }

    public void PlaySound(string soundName)
    {
        Sound s = Array.Find(sounds, Sound => Sound.name == soundName);
        s.source.Play();
    }

    public void StopSound(string soundName)
    {
        Sound s = Array.Find(sounds, Sound => Sound.name == soundName);
        s.source.Stop();
    }

    public void StopAllSounds()
    {
        foreach(Sound s in sounds)
        {
            StopSound(s.name);
        }
    }

    public void PlayMusic(string soundName)
    {
        Sound m = Array.Find(music, Sound => Sound.name == soundName);
        m.source.Play();
    }

    public void StopMusic(string soundName)
    {
        Sound m = Array.Find(music, Sound => Sound.name == soundName);
        m.source.Stop();
    }

    public void StopAllMusic()
    {
        foreach(Sound s in music)
        {
            StopMusic(s.name);
        }
    }
}
