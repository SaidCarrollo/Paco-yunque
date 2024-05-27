using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "CustomMaterialSettings", menuName = "ScriptableObjects/CustomMaterialSettings", order = 1)]
public class CustomMaterialSettings : ScriptableObject
{
    public Color color = Color.white;
    public Color mainColor;
    public Color emissionColor;
}