using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundSystem : PersistentSingleton<SoundSystem>
{
    [SerializeField] List<SoundClip> soundClips = new List<SoundClip>();
    [Header("Audio Sources")]
    [SerializeField] AudioSource singleAudioSource;
    [SerializeField] AudioSource loopAudioSource;
    private Dictionary<AudioType, SoundClip> AudioDict;

    override protected void Awake() {
        base.Awake();
        AudioDict = soundClips.ToDictionary(r => r.audioType, r => r);
    }

    public void Play(AudioType type){
        Debug.Log("Played "+type.ToString());
        if(AudioDict[type].loop){
            loopAudioSource.clip = AudioDict[type].audioClip;
            loopAudioSource.volume = AudioDict[type].volume;
            loopAudioSource.Play();
        }else {
            singleAudioSource.PlayOneShot(AudioDict[type].audioClip, AudioDict[type].volume);
        }
    }

    public void Mute(bool value){
        loopAudioSource.mute = value;
        singleAudioSource.mute = value;
    }
}

[Serializable]
public struct SoundClip{
    public AudioClip audioClip;
    public AudioType audioType;
    public float volume;
    public bool loop;
}

[Serializable]
public enum AudioType{
    ButtonClick,
    TabOpened,
    Victory,
    Lose,
    CollectEXP,
    Arrow,
    Sword,
    WoodenDoor,
    LevelUp,
    Treasure,
    SlotSpin,
    Success
}
