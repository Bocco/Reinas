using UnityEngine;
using System.Collections;

public class ControlladorGlobal : MonoBehaviour {

    public int dimension;
    int ingreso;

    public GameObject camaraManager;

    public GameObject mapa;

    void Start()
    {
        Reset();
        Debug.Log((int)0.9 + "");
        //dimension = ingreso;

        mapa = (GameObject)Instantiate(mapa, Vector3.zero, Quaternion.identity);
        mapa.GetComponent<Mapa>().dimension = dimension;
        // mapa.GetComponent<Mapa>().perderSecuence

        mapa.GetComponent<Mapa>().setStart();

        camaraManager.GetComponent<Camara>().dimension = dimension;
        camaraManager.GetComponent<Camara>().setStart();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) Reset();
        if (Input.GetKeyDown(KeyCode.S)) mapa.GetComponent<Mapa>().soluciones();
    }


    public void Reset()
    {
        GameObject[] destructor = GameObject.FindGameObjectsWithTag("Mecanica");
        foreach (GameObject game in destructor) Destroy(game);
        mapa.GetComponent<Mapa>().setStart();
        //camaraManager.transform.position = Vector3.zero;
    }

   


}
