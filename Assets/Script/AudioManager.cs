using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    //Массив всех аудио которые будут проигрываться не в 3D пространнстве
    [SerializeField]
    Sound[] _sounds;
    
    void Awake()
    {
        //Передача настроек аудио
        foreach (Sound sound in _sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.outputAudioMixerGroup = sound.output;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }
    }

    /// <summary>
    /// Проигрывание аудио
    /// </summary>
    /// <param name="name">Имя аудио</param>
    public void Play(string name)
    {
        Sound soundClip = Array.Find(_sounds, sound => sound.name == name);
        if (soundClip == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        soundClip.source.Play();
    }

}
