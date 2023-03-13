using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Map", menuName = "ScriptableObjects/GameAssets/Map", order = 1)]
public class SO_Map : ScriptableObject
{
    public float northPos;
    public float southPos;
   
    public float westPos;
    public float eastPos;
}
