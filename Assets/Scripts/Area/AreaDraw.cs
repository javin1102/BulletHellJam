using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDraw : MonoBehaviour
{
    public float width;
    public float height;
    public int X;
    public int Y;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 0));
    }

    public Vector3 GetRoomCenter()
    {
        return new Vector3(X * width, Y * height);
    }
}
