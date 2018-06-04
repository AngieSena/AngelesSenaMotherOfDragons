using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;


public class BotonDragoncitos : MonoBehaviour {

	public bool ButtonOn = false;
    public GameObject globo;
    public GameObject ticks;
    public static int SeleccionDragoncito = 0;

	[SerializeField] public int cualSoy;

	[SerializeField] public Image[] botonesD;
    [SerializeField] public Image[] Ticss;

    public void Pintar(int D) {
		//botonesD[D].color = new Color32 (45, 255, 255, 255);
        ticks.SetActive(true);
	}

	public void Despintar(int D) {

        //botonesD[D].color = new Color32 (255,255,255,255);
        //Ticss[D].SetActive(false);
        ticks.SetActive(true);
    }
		
	void Awake(){


		if (Controlador.HijosGanados [cualSoy])
        {
            Activar (cualSoy);
            globo.SetActive(true);
        }
    }

	public void OnClick (int d){
		Seleccion (d);
        

	}

	public void Activar(int D){
		botonesD[D].enabled = true;
	}
		
	void Seleccion(int D){

		string[] dragoncitos = new string[] { "", "ARENA", "TIERRA" , "ELECTRICO" , "METAL" , "AGUA" , "AIRE" , "LODO" , "LAVA" , "NORMAL" , "HIELO" , "FUEGO" };

		SeleccionDragoncito++;

		Analytics.CustomEvent("SeleccionarHijo", new Dictionary<string, object>
			{
				{ "cual",  dragoncitos[D]},
				{ "cantidad", SeleccionDragoncito }
			});
		
		if(Controlador.HijosGanados[D]){
			if(Controlador.dragoncito1 == -1){
				Controlador.dragoncito1 = D;
				Pintar (D);
				Debug.Log ("d1 es " + Controlador.dragoncito1);
			}
			if (Controlador.dragoncito2 == -1 && Controlador.dragoncito1 != -1 && D != Controlador.dragoncito1) {
				Controlador.dragoncito2 = D;
				Pintar (D);
				Debug.Log ("d2 es " + Controlador.dragoncito2);
			} else {
				if(Controlador.dragoncito1 != -1 && Controlador.dragoncito2 != -1){
					Despintar(Controlador.dragoncito1);
					Controlador.dragoncito1 = Controlador.dragoncito2;
					Pintar (D);
					Controlador.dragoncito2 = D;
					Debug.Log ("d1 es:" + Controlador.dragoncito1 + ", y d2 es:" + Controlador.dragoncito2);	
				}

			}
		}
	}
		
}
