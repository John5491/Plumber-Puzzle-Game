using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip rotateSound;
    public static AudioClip treeSound;
    public static AudioClip generatorSound;
    public static AudioClip barrelSound;
    public static AudioClip tankSound;
    public static AudioClip truckSound;
    static AudioSource audioSrc;
    void Start()
    {
        rotateSound = Resources.Load<AudioClip>("rotatesfx");
        treeSound = Resources.Load<AudioClip>("tree");
        generatorSound = Resources.Load<AudioClip>("generator");
        tankSound = Resources.Load<AudioClip>("tank");
        barrelSound = Resources.Load<AudioClip>("barrel");
        truckSound = Resources.Load<AudioClip>("truck");
        audioSrc = GetComponent<AudioSource>();

    }

    public static void PlaySound(string clip)
    {
        switch(clip)
        {
            case "rotate":
                audioSrc.PlayOneShot(rotateSound);
                break;

            case "tree":
                audioSrc.PlayOneShot(treeSound);
                break;

            case "generator":
                audioSrc.PlayOneShot(generatorSound);
                break;

            case "tank":
                audioSrc.PlayOneShot(tankSound);
                break;

            case "barrel":
                audioSrc.PlayOneShot(barrelSound);
                break;

            case "truck":
                audioSrc.PlayOneShot(truckSound);
                break;
        }
    }
}
