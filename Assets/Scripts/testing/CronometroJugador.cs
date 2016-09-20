using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Diagnostics;
using System;

public class CronometroJugador : MonoBehaviour {
    Stopwatch tempo;
    string elapsedTime;
    public Text stringTempo;
    public InputField ingreso;
   

	// Use this for initialization
	void Start () {
        tempo = new Stopwatch();
        tempo.Start();
        
    }
	
	// Update is called once per frame
	void Update () {
        TimeSpan ts = tempo.Elapsed;
        // Format and display the TimeSpan value.
         elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
       // UnityEngine.Debug.Log(elapsedTime);
       // stringTempo.text = elapsedTime;
        
     
	}
     public void jugador()
    {
        // UnityEngine.Debug.Log("Jugador: " + ingreso.text + " Tiempo: " + elapsedTime);
        stringTempo.text = "Timpo: "+elapsedTime;
        UnityEngine.Debug.Log("Jugador: " + ingreso.text + " Tiempo: "+elapsedTime);
    }

    
}
