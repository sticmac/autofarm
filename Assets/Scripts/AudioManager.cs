using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AudioManager : MonoBehaviour
{
    #region Singleton
    public static AudioManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Load();
        } else
        {
            Destroy(this);
        }
    }
    #endregion

    [SerializeField] private List<Sound> Musics = new List<Sound>();
    [SerializeField] private List<Sound> Sounds = new List<Sound>();

    private void Load()
    {
        foreach (Sound music in Musics)
        {
            music.source = gameObject.AddComponent<AudioSource>();
            music.source.clip = music.Clip;
            music.source.volume = music.Volume;
            music.source.pitch = music.Pitch;
        }
        StartCoroutine(PlayMusic());

        foreach (Sound sound in Sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.Clip;
            sound.source.volume = sound.Volume;
            sound.source.pitch = sound.Pitch;
        }
    }

    public void Play(string name)
    {
        Sound s = Sounds.Find(sound => sound.Name == name);
        s.source.Play();
    }

    public IEnumerator PlayMusic()
    {
        int i = UnityEngine.Random.Range(0, Musics.Count);
        Musics[i].source.Play();
        Debug.Log("Play");
        while(Musics[i].source.isPlaying)
        {
            yield return null;
        }
        StartCoroutine(PlayMusic());
    }
}
