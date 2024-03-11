using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    public AudioClip menuMusic;
    public AudioClip bgm;
    public AudioClip ambient;
    private List<AudioSource> _sources;

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this;
        DontDestroyOnLoad(gameObject);
        _sources = GetComponents<AudioSource>().ToList();
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("scene loaded " + scene.name);
        _sources[0].Stop();
        if (scene.name == "MainMenu")
        {
            _sources[0].loop = true;
            _sources[0].clip = menuMusic;
            _sources[0].volume = 0.7f;
            _sources[0].Play();
        }
        if (scene.name == "PoolFinal")
        {
            _sources[0].loop = true;
            _sources[0].clip = bgm;
            _sources[0].volume = 0.7f;
            _sources[0].Play();
        }
    }

    void Start()
    {
        _sources[1].loop = true;
        _sources[1].clip = ambient;
        _sources[1].volume = 0.7f;
        _sources[1].Play();
    }

    public void PlayAudio(AudioClip clip)
    {
        GameObject obj = new GameObject("Temp Audio Object");
        AudioSource src = obj.AddComponent<AudioSource>();
        src.clip = clip;
        src.PlayOneShot(src.clip);
        Destroy(obj, clip.length + 1);
    }
}
