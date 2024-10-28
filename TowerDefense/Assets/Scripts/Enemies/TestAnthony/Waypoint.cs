using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public static Transform[] waypoints;

    void Awake()
    {
        waypoints = new Transform[transform.childCount]; //Create Waypoint Array
        for (int i = 0; i < waypoints.Length; i++) 
        {
            waypoints[i] = transform.GetChild(i); //Asign serial number "Waypoint1, Waypoint2..."
        }
    }
}
