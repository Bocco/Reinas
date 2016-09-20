using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Dialog : MonoBehaviour {


	private Text _textComponent;
	public string[] stringarray;
	public float secondsbetween = 0.5f;
	// Use this for initialization
	void Start () {
		_textComponent = GetComponent<Text>();
		_textComponent.text = "";
	}
	// Update is called once per frame
	void Update () {
			if(Input.GetMouseButtonDown(0)){
				StartCoroutine(displayString("Hola esto es una pequeña prueba"));
			}
	
	}

		private IEnumerator displayString(string todisplay){
			int stringlenght = todisplay.Length;
			int index = 0;
			_textComponent.text = "0";


			while(index < stringlenght){
				_textComponent.text += todisplay[index];
				index++;
				if(index < stringlenght){
					yield return new WaitForSeconds(secondsbetween);

				}
			}

		}
}
