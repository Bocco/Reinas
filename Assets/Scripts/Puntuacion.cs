using UnityEngine;

using System.Diagnostics;
using System;
using UnityEngine.UI;

public class Puntuacion : MonoBehaviour {
    int score = 300;
    int zero = 0;
    Stopwatch reloj;
    public Text texto;
	// Use this for initialization
	void Start () {
        reloj = new Stopwatch();
        reloj.Start();
        texto.text = score + "";
    }
	
	// Update is called once per frame
	void Update () {
        TimeSpan aux = reloj.Elapsed;
        if(zero< (int)aux.TotalSeconds)
        {
            zero= (int)aux.TotalSeconds;
            score = score - 1;
        }
         
        texto.text = score + "";
	}
}
