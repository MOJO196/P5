using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

   public void Play (String name) 
   {
       Sound s = Array.Find(sounds, sound => sound.name == name);
       s.source.Play();
   }

   void Start ()
   {
       StartCoroutine(SongSelect());
   }

   IEnumerator SongSelect ()
   {
       yield return new WaitForEndOfFrame();

        switch (GameStats.currentLevel)
        {
            case 0: Play("MainMenu");
            break;
            case 1: Play("MusicL1");
            break;
            case 2: Play("MusicL1B");
            break;
            case 3: Play("MusicL2");
            break;
            case 4: Play("MusicL2B");
            break;
            case 5: Play("MusicL3");
            break;
            case 6: Play("MusicL3B");
            break;
            case 7: Play("MusicL4");
            break;
            case 8: Play("MusicL4B");
            break;
            case 9: Play("MusicL5");
            break;
            case 10: Play("MusicL5B");
            break;
            case 11: Play("MusicEndScreen");
            break;
            case 12: Play("GameOver");
            break;
       }
   }
}
