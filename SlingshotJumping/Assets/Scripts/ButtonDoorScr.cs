using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ButtonDoorScr : MonoBehaviour
{

    //making array variable to store the door objects
    public GameObject[] doors;

    //making array to store their distances
    public List<float> distances;

    //button's distance and closest door variable
    public float buttonDistance;

    public GameObject closestDoor;

    //find smallest distance in distance list
    float minDistance;
    int minDistanceIndex;

    public GameObject closedDoor;
    public GameObject openedDoor;

    public GameObject roomBlinds;
    
    // Start is called before the first frame update
    void Start()
    {
        buttonDistance = transform.position.x;

        doors = GameObject.FindGameObjectsWithTag("Door");

        foreach (GameObject door in doors)
        {
            distances.Add(Mathf.Abs( buttonDistance-door.transform.position.x));
        }

        //find minimum
        minDistance = distances.Min();
        minDistanceIndex = distances.IndexOf(minDistance);

        closestDoor = doors[minDistanceIndex];
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
