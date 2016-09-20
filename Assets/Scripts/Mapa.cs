using UnityEngine;
using System.Collections;

public class Mapa : MonoBehaviour {

    [HideInInspector]public int dimension;
    int num_reina;

    public GameObject celdaPrefab;
    public GameObject reina;

    NReinas solucionario;

    GameObject[,] cuadricula;

     public void setStart()
    {
        num_reina = dimension;
        cuadricula = new GameObject[dimension,dimension];

        GenerarVisual();
    }

    void GenerarVisual()
    {
        for (int filas = 0; filas < dimension; filas++)
        {
            for (int columnas = 0; columnas < dimension; columnas++)
            {
                cuadricula[filas, columnas] = (GameObject)Instantiate(celdaPrefab, new Vector3(columnas - dimension / 2, 0, -filas + dimension / 2), Quaternion.Euler(new Vector3(0, 0, 0)));
                Click ck = cuadricula[filas, columnas].GetComponent<Click>();
                ck.fila = filas;
                ck.columna = columnas;
                ck.mapa = this;
                ck.isDisponible = true;

            }
        }
    }

    public void Pintar(int ejex, int ejey)
    {
        
        if (num_reina > 0)
        {
           
            PintarDiagonalSup(ejex, ejey);
            PintarDiagonalInf(ejex, ejey);
            PintarRectas(ejex, ejey);
        }

    }
    void PintarDiagonalSup(int fila, int columna)
    {
        for (int i = -dimension; i < dimension; i++)
        {
            if (fila + i > -1 && fila + i < dimension && columna + i > -1 && columna + i < dimension)
            {
               
                cuadricula[fila + i, columna + i].GetComponent<Renderer>().material.color = Color.blue;
                cuadricula[fila + i, columna + i].GetComponent<Click>().isDisponible = false;
            }
        }
    }
    void PintarDiagonalInf(int fila, int columna)
    {
        for (int i = -dimension; i < dimension; i++)
        {
            if (columna + i > -1 && columna + i < dimension && fila - i > -1 && fila - i < dimension)
            {
                cuadricula[fila - i, columna + i].GetComponent<Renderer>().material.color = Color.blue;
                cuadricula[fila - i, columna + i].GetComponent<Click>().isDisponible = false;

            }
        }
    }
    void PintarRectas(int fila, int columna)
    {
        for (int i = 0; i < dimension; i++)
        {
            cuadricula[fila, i].GetComponent<Renderer>().material.color = Color.blue;
            cuadricula[i, columna].GetComponent<Renderer>().material.color = Color.blue;
            cuadricula[fila, i].GetComponent<Click>().isDisponible = false;
            cuadricula[i, columna].GetComponent<Click>().isDisponible = false;
            

        }
    }
    

    public void moverReina(int fila, int columna)
    {

        //Debug.Log(continuar(fila, columna));

        //Debug.Log("reinas antes de mover" + num_reina);
        //Debug.Log("Fin juego" + (num_reina == 0 && todosBloqueados()) + "numreinas" + num_reina + "todos bloqueados" + todosBloqueados());
        if ((num_reina > 0) && continuar(fila, columna))
        {

            Instantiate(reina, new Vector3(columna - dimension / 2, 1, -fila + dimension / 2), Quaternion.Euler(new Vector3(-90, 0, 0)));

            Pintar(fila, columna);
            num_reina--;
            Debug.Log("Reinas restantes: " + num_reina);
            if (num_reina > 0 && todosBloqueados())
            {
                Debug.Log("Perdiste");
                perderSecuence();

            }



        }
        if (num_reina == 0 && todosBloqueados())
        {
            Debug.Log("Sin reinas\nGanaste");
            ganarSecuence();

        }

    }

    bool todosBloqueados()
    {
        int bloqueados = 0;
        for (int filas = 0; filas < dimension; filas++)
        {
            for (int columnas = 0; columnas < dimension; columnas++)
            {
                if (cuadricula[filas, columnas].GetComponent<Click>().isDisponible == false)
                {

                    bloqueados++;
                }

            }
        }
        if (bloqueados == dimension * dimension) { Debug.Log("Bloqueados" + bloqueados); return true; }
        else { Debug.Log("Bloqueados" + bloqueados); return false; }
    }
    bool continuar(int fila, int columna)
    {
        bool salida = false;

        if (cuadricula[fila, columna].GetComponent<Click>().isDisponible == true)
        {
            salida = true;

        }
        return salida;
    }

    public void soluciones()
    {
        solucionario = new NReinas();
        solucionario.setData(reina, dimension);
        solucionario.iniciar();
    }


    public void perderSecuence()
    {
        //Debug.Log("Saludo Reina");
       // this.perder.SetActive(true);
    }
    public void ganarSecuence()
    {
        //this.ganar.SetActive(true);
    }

}
