using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource audioSource;

    // List of bgm
    [SerializeField]
    List<AudioClip> sound;

    public enum TrackID
    {
        CLICK,
        MATCH,
        WIN,
        LOSE
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(TrackID id)
    {
        audioSource.clip = sound[(int)id];
        audioSource.Play();
    }
}
