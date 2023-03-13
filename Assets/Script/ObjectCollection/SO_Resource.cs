using System.Collections;
using System.Collections.Generic;
using UnityEditor.XR.Management;
using UnityEngine;

[CreateAssetMenu(fileName = "Resource", menuName = "ScriptableObjects/ResourceManagement", order = 1)]
public class SO_Resource : ScriptableObject
{
       public GameObject[] collectables;
       
       [Header("collectibles")]
       public int currentItems;
       public int mushrooms;
       public int wood;
       public int cloth;

       [Header("upgrades")] 
       public int currentLevel;
       public int maxLevel;

}