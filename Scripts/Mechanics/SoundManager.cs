using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public List<AudioClip> attackClips = new List<AudioClip>();
    public List<AudioClip> animalClips = new List<AudioClip>();
    public List<AudioClip> doodadClips = new List<AudioClip>();
    public List<AudioClip> itemClips = new List<AudioClip>();
    public List<AudioClip> monsterClips = new List<AudioClip>();
    public List<AudioClip> peopleClips = new List<AudioClip>();
    public List<AudioClip> uiClips = new List<AudioClip>();

    public AudioClip GetAttackClip(int i)
    {
        if (i < attackClips.Count)
        {
            return attackClips[i];
        }
        else return attackClips[0];
    }
    public AudioClip GetPeopleClip(int i)
    {
        if (i < peopleClips.Count)
        {
            return peopleClips[i];
        }
        else return peopleClips[0];
    }
    public AudioClip GetMonsterClip(int i)
    {
        if (i < monsterClips.Count)
        {
            return monsterClips[i];
        }
        else return monsterClips[0];
    }


}
