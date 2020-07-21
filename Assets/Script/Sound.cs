using UnityEngine.Audio;
using UnityEngine;

/// <summary>
/// Класс для хранения настроек аудио
/// </summary>
[System.Serializable]
public class Sound 
{
    public string name;

    public AudioClip clip;
    public AudioMixerGroup output;

    [Range(0f,1f)]
    public float volume = 0.7f;
    [Range(.1f, 3f)]
    public float pitch = 1.0f;

    public bool loop;

    [HideInInspector]
    public AudioSource source;

}
