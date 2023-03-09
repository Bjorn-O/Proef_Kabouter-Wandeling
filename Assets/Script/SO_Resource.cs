using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Resource", menuName = "ScriptableObjects/ResourceManagement", order = 1)]
public class SO_Resource : ScriptableObject
{
        [SerializeField] public GameObject item;
        
        [SerializeField] public int currentItems;
        [SerializeField] public int mushrooms;
        [SerializeField] public int wood;
        [SerializeField] public int bricks;

        
}