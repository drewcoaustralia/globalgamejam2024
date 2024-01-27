using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    public AudioClip bgm;
    public AudioClip ambient;
    private List<AudioSource> _sources;

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this;
    }

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
        GameObject obj = GameObject.Instantiate(new GameObject());
        AudioSource src = obj.AddComponent<AudioSource>();
        src.clip = clip;
        src.PlayOneShot(src.clip);
        Destroy(obj, clip.length + 1);
    }
}
