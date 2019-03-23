using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class AudioVolume : MonoBehaviour {

    private float m_AudioVolume = 0;
    private AudioSource m_audioSource;
	// Use this for initialization
	void Start () {
        m_AudioVolume = PlayerPrefs.GetFloat("AudioVolume", 1);
        m_audioSource = GetComponent<AudioSource>();
        m_audioSource.volume = m_AudioVolume;
        m_audioSource.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
