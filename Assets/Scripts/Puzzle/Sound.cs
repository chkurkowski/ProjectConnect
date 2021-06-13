using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound
{
    public AudioClip clip;

    public string name;

    [Range(0f, 1f)]
    public float volume;

    [Range(0.1f, 3f)]
    public float pitch;

    [HideInInspector]
    public AudioSource source;
}
