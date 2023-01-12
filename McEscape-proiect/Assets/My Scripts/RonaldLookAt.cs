using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RonaldLookAt : MonoBehaviour
{
    public Transform player;
    private float x;
    private float y;
    private float z;
    public Light redLight;

    // Start is called before the first frame update
    void Start()
    {
        x = 17.21f;
        y = 8.49f;
        z = 16.81f;
        redLight.intensity = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            transform.position = new Vector3(x, y, z);
            transform.LookAt(player);
        }
    }

    public void setNewPosition(float newX, float newY, float newZ)
    {
        x = newX;
        y = newY;
        z = newZ;
    }

    public void turnOnLight()
    {
        redLight.intensity = 3;
    }
}
