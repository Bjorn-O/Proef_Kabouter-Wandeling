using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Resource", menuName = "ScriptableObjects/ResourceManagement", order = 1)]
public class SO_Resource : ScriptableObject
{
       public GameObject[] collectables;

       [Header("collectibles")] 
       public int stone;
       [FormerlySerializedAs("mushrooms")] public int plank;
       public int wood;
       public int cloth;

       [Header("upgrades")] 
       public int currentLevel;
       public int maxLevel;

}