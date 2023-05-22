using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSound : MonoBehaviour
{
    public static bool BlockDestroyed;
    public AudioClip _AudioClip;
    void Update()
    {
        if (BlockDestroyed)
        {
            
            GetComponent<AudioSource>().clip = _AudioClip;
            GetComponent<AudioSource>().Play();
            BlockDestroyed = false;
        }
    }
}
