using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public Sound[] sounds;

    //플레이 배경음 이름
    public string bgmName = "";

    public AudioMixer audioMixer;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        //DontDestroyOnLoad(gameObject);

        AudioMixerGroup[] audioMixerGroup = audioMixer.FindMatchingGroups("Master");

        foreach (Sound s in sounds)
        {
            s.source = this.gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume * 0.5f;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

            if (s.source.loop)
            {
                s.source.outputAudioMixerGroup = audioMixerGroup[1];//BGM
            }
            else
            {
                s.source.outputAudioMixerGroup = audioMixerGroup[2];//SFX
            }
        }
    }

    public void Play(string name)
    {
        Sound sound = null;

        foreach (Sound s in sounds)
        {
            if (s.name == name)
            {
                sound = s;
                break;
            }
        }

        if (sound == null)
        {
            Debug.Log("Sound : " + name + "File not found!!!");
            return;
        }

        sound.source.Play();
    }

    public void StopBgm()
    {
        Sound sound = null;

        foreach (Sound s in sounds)
        {
            if (s.name == bgmName)
            {
                sound = s;
                break;
            }
        }

        if (sound == null)
        {
            //Debug.Log("Stop Sound : " + name + "File not found!!!");
            return;
        }

        bgmName = "";
        sound.source.Stop();
    }

    public void PlayBgm(string name)
    {
        //기존에 플레이 되는 배경음과 새로운 배경음이 같을때
        if (bgmName == name)
        {
            return;
        }

        //기존 배경음 중단
        StopBgm();

        //새로운 배경음 플레이
        Sound sound = null;

        foreach (Sound s in sounds)
        {
            if (s.name == name)
            {
                sound = s;
                break;
            }
        }

        if (sound == null)
        {
            Debug.Log("Play Sound : " + name + "File not found!!!");
            return;
        }

        sound.volume = 0.7f;
        bgmName = sound.name;

        sound.source.Play();
    }

}
