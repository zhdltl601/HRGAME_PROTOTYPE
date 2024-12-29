using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SingletonPreset", menuName = "SO/SingletonPresets/Preset")]
public class SingletonPresetSO : ScriptableObject
{
    [SerializeField] private GameObject preset;
}
