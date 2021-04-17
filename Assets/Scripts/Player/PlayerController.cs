using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float xMov = 0;
    private float zMov = 0;
    private Vector3 mousePos;
    PlayerTank actionScript;

    // Start is called before the first frame update
    void Start()
    {
        actionScript = GetComponent<PlayerTank>();
    }

    // Update is called once per frame
    void Update()
    {
        GetPlayerInput();
        actionScript.RotateTankTurret(mousePos);
        actionScript.RotateTankBody(xMov);
    }

    private void FixedUpdate()
    {
        actionScript.MovePlayer(zMov);
    }

    private void GetPlayerInput()
    {
        xMov = Input.GetAxisRaw("Horizontal");
        zMov = Input.GetAxisRaw("Vertical");
        Vector3 mousePos3d = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        mousePos = new Vector3(mousePos3d.x, mousePos3d.y, 0);
    }
}
