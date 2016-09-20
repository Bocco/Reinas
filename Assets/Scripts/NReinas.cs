using UnityEngine;
public class NReinas : MonoBehaviour{

    public GameObject reina;
    public int dimension;

    public void setData(GameObject modeloReina, int dimensionLlegada)
    {
        reina = modeloReina;
        dimension= dimensionLlegada;
    }

    public void iniciar()
    {
        int[] solucion = new int[dimension];
        generarRespuesta(solucion, 0);
    }

    void generarRespuesta(int[] ingreso, int ubicadas)
    {
        int total_reinas = ingreso.Length;
        if (ubicadas == total_reinas)
        {
            string aux = "";
            foreach (int i in ingreso)
            {
                aux += i + " ";
            }
           Debug.Log(aux);
            DesplegarReina(ingreso);
        }
        else
        {
            for (int i = 0; i < total_reinas; i++)
            {
                ingreso[ubicadas] = i;
                if (isConsistente(ingreso, ubicadas))
                    generarRespuesta(ingreso, ubicadas + 1);
            }
        }
    }

    public bool isConsistente(int[] ingreso, int n)
    {
        for (int i = 0; i < n; i++)
        {
            if (ingreso[i] == ingreso[n]) { return false; }// misma columna
            if ((ingreso[i] - ingreso[n]) == (n - i)) { return false; }  // diagonal superior
            if ((ingreso[n] - ingreso[i]) == (n - i)) { return false; }   // diagonal inferior

        }
        return true;
    }

    void DesplegarReina(int [] q)
    {
        for (int filas = 0; filas < dimension; filas++)
        {
            for (int columnas = 0; columnas < dimension; columnas++)
            {
                if (q[filas] == columnas)
                {
                    Instantiate(reina, new Vector3(columnas - dimension / 2, 1, -filas + dimension / 2 + 0), Quaternion.Euler(new Vector3(-90, 0, 0)));
                }
            }
        }
    }
}
