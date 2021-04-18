using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StyleSwitch : MonoBehaviour
{
    public int selectedStyle = 0;

    void Start()
    {
        SelectStyle();
    }


    void Update()
    {
        int previousSelectedStyle = selectedStyle;

        //Switch Style
        if(Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedStyle >= transform.childCount - 1)
                selectedStyle = 0;
            else
                selectedStyle++;
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedStyle <= 0)
                selectedStyle = transform.childCount - 1;
            else
                selectedStyle--;
        }

        if (previousSelectedStyle != selectedStyle)
        {
            SelectStyle();
        }

    }

    void SelectStyle()
    {
        int i = 0;
        foreach(Transform style in transform)
        {
            if (i == selectedStyle)
                style.gameObject.SetActive(true);
            else
                style.gameObject.SetActive(false);
            i++;
        }
    }
}
