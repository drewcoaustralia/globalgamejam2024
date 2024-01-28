using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    public AudioClip bgm;
    public AudioClip ambient;

    public AudioSource drowningSFXSource;

    private List<AudioSource> _sources;

    void Start()
    {
        _sources = GetComponents<AudioSource>().ToList();
        _sources[0].loop = true;
        _sources[0].clip = bgm;
        _sources[0].volume = 0.7f;
        _sources[0].Play();

        _sources[1].loop = true;
        _sources[1].clip = ambient;
        _sources[1].volume = 0.7f;
        _sources[1].Play();
    }

    public void PlayAudio(AudioClip clip)
    {
        foreach (var source in _sources)
        {
            if (source.clip == clip && source.isPlaying)
            {
                return;
            }
        }

        GameObject obj = new GameObject("Temp Audio Object");
        AudioSource src = obj.AddComponent<AudioSource>();
        src.clip = clip;
        src.PlayOneShot(src.clip);
        Destroy(obj, clip.length + 1);
    }

    public void PlayDrowningSFX()
    {
        if (drowningSFXSource.isPlaying)
        {
            drowningSFXSource.Stop();
        }

        drowningSFXSource.Play();
    }
}
