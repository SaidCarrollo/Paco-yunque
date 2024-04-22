using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioSettings", menuName = "ScriptableObject/AudioSettings", order = 1)]
public class AudioSettings : ScriptableObject
{
    public float volume;
}