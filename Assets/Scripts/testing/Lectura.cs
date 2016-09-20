using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System.Text;

public class Lectura : MonoBehaviour {

    // Use this for initialization
    public Text salida;
	void Start()
    {
        //salida.text = "Jugadores ganadores";
        //salida.text += "\nHiola";
        salida.text = System.IO.File.ReadAllText("Scores.txt");
       /* try
        {
            Debug.Log("Hola");
            StreamReader sr = new StreamReader("Scores", Encoding.Default);
              Debug.Log("Hola2");
            using (sr)
            {

                Debug.Log("dweefe");
                salida.text += sr.ReadToEnd();
            }
        }
        catch 
        {
            Debug.Log("Error de lectura ");
        }*/
    
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
