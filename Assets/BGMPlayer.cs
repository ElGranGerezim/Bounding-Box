using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class BGMPlayer : MonoBehaviour
{
    static BGMPlayer instance;

    [SerializeField] AudioClip[] music;
    private int musicIndex;
    private AudioSource myAudioSource;

    public BGMPlayer getInstance () { return instance; }

    private void Awake () {
        myAudioSource = GetComponent<AudioSource>();
        ManageSingleton();
        SceneManager.sceneLoaded += LevelLoaded;
    }

    private void Start () {
        musicIndex = 0;
        myAudioSource.clip = music[musicIndex];
        myAudioSource.Play();
    }

    private void ManageSingleton () {
        if(instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        } else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void LevelLoaded (Scene level, LoadSceneMode loadSceneMode) {
        if(level.buildIndex == 0)
        {
            if(musicIndex != 0)
            {
                myAudioSource.Stop();
                myAudioSource.clip = music[0];
                myAudioSource.Play();
            } else
            {
                myAudioSource.Play();
            }
        } else
        {
            int randIndex = Random.Range(1, music.Length);
            if(musicIndex != randIndex)
            {
                musicIndex = randIndex;
                myAudioSource.Stop();
                myAudioSource.clip = music[musicIndex];
                myAudioSource.Play();
            } else
            {
                myAudioSource.Play();
            }
            BBEventManager em = FindObjectOfType<BBEventManager>();
            em.onVictory += Pause;
            em.onBoxEscaped += Pause;
        }
    }

    private void Pause () {
        myAudioSource.Pause();
    }
}
