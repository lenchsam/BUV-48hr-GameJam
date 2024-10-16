using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource AS;
    [SerializeField] private GameObject GO;
    private void Awake()
    {
        GO = GameObject.Find("----AudioManager----");
        if (GO == null)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        AS = gameObject.GetComponent<AudioSource>();
    }

    public void SetVolume(float value)
    {
        //Debug.Log(value);
        AS.volume = value;
    }
    public void playSound(AudioClip audioToPlay)
    {
        AS.PlayOneShot(audioToPlay);
    }
}
