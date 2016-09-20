using UnityEngine;
using System.Collections;

public class Camara : MonoBehaviour
{

    public GameObject mainCamera;
   

    [HideInInspector]
    public int longitud;
    [HideInInspector]
    public int dimension;

    public void setStart()
    {

        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        if (dimension > 10)
        {
            dimension *= 2;
        }
        mainCamera.transform.Translate(new Vector3((3 / 2) * (dimension / 2), dimension / 2 + 3, (3 / 2) * (dimension / 2)));
        mainCamera.transform.Rotate(Vector3.up, -90 - 45);
        mainCamera.transform.Rotate(Vector3.left, -45);
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            this.transform.Rotate(Vector3.up, 45);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            this.transform.Rotate(Vector3.up, -45);
        }



    }


}

