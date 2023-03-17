using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectsCollection : MonoBehaviour
{
    [SerializeField] private ObjectSpawner objectSpawner;
    private Touch touch;
    [SerializeField] private SO_Resource Resource;
    public Text testtext;


    // Update is called once per frame
    void Update()
    {
        Collection();
        testtext.text = Resource.plank.ToString() + "\n" + Resource.cloth.ToString() + "\n" + Resource.wood.ToString() + "\n" + Resource.stone.ToString();
    }

    private void Collection()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                // Construct a ray from the current touch coordinates
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    switch (hit.collider.gameObject.name)
                    {
                        case "Mushroom":
                            Destroy(hit.collider.gameObject);
                            Resource.plank++;
                            break;
                        case "Woodlog":
                            Resource.wood++;
                            Destroy(hit.collider.gameObject);
                            break;
                        case "Cloth":
                            Resource.cloth++;
                            Destroy(hit.collider.gameObject);
                            break;
                        case "Stone":
                            Resource.stone++;
                            Destroy(hit.collider.gameObject);
                            break;
                        
                    }
                }
            }
        }
    }

}
