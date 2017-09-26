using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {

    [SerializeField]
    private AudioClip musicClip;

    [SerializeField]
    private AudioSource musicSource;

	// Use this for initialization
	void Start () {
        musicSource = GetComponent<AudioSource>();
        musicClip = Resources.Load("music", typeof(AudioClip)) as AudioClip;
        musicSource.clip = musicClip;
        musicSource.Play();
        musicSource.loop = true;
	}
}
