using UnityEngine;
using System.Collections;

public class Click : MonoBehaviour {

    public int fila;
    public int columna;
    public bool isDisponible;
    public Mapa mapa;

    void OnMouseUp()
    {
        //Debug.Log("click en :fila->" + fila + "||columna->" + columna);
        //mapa.Pintar(fila,columna);
           mapa.moverReina(fila, columna);
    }
}
