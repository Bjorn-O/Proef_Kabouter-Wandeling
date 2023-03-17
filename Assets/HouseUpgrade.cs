using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HouseUpgrade : MonoBehaviour
{
    public SO_Resource resources;
    public TextMeshProUGUI[] texts;
    public GameObject[] objects;
    private int index = 0;
    

    private void Awake()
    {
        texts[0].text = resources.wood.ToString();
        texts[1].text = resources.stone.ToString();
        texts[2].text = resources.plank.ToString();
        texts[3].text = resources.cloth.ToString();
    }

    public void onButtonPress()
    {
        if (index < objects.Length)
        {
            objects[index].SetActive(true);
            index++;
        }
    }
}
