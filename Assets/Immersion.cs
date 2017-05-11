using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Immersion : MonoBehaviour {
	[SerializeField]
	public Texture backgroundTexture;
	public Texture albumTexture;
	public Texture fengjingTexture1;
	public Texture fengjingTexture2;
	public Texture fengjingTexture3;
	public Texture fengjingTexture4;
	public Texture fengjingTexture5;
	//public Texture fengjingTexture6;
	public Texture[] fengjing;
	public Texture leftArrow;
	public Texture rightArrow;
	public Texture ackTexture;
	public Texture returnTexture;
	public int i = 0;
	public GUIStyle Mystyle;
	public float rationScaleTempH;
	public float rationScaleTemp;

	// Use this for initialization
	void Start () {
		rationScaleTempH = Screen.height / 960.0f; //屏幕自适应纵向缩放比
		rationScaleTemp = Screen.width / 540.0f;
	}
	
	// Update is called once per frame
	void Update () {
//		Debug.Log (i);
	}

	void OnGUI(){
		
		Rect windowRect = new Rect (20 * rationScaleTemp, 250 * rationScaleTempH, 500 * rationScaleTemp, 550 * rationScaleTempH);
		GUI.DrawTexture (new Rect (0, 0, 540 * rationScaleTemp, 960 * rationScaleTempH), backgroundTexture, ScaleMode.ScaleToFit, true, 540.0f / 960.0f);
		GUI.DrawTexture (new Rect (170 * rationScaleTemp, 20 * rationScaleTempH, 200 * rationScaleTemp, 100 * rationScaleTempH), albumTexture, ScaleMode.ScaleToFit, true, 200.0f / 100.0f);
		if (GUI.Button (new Rect (20 * rationScaleTemp, 145 * rationScaleTempH, 50 * rationScaleTemp, 50 * rationScaleTempH), leftArrow, Mystyle)) {
			i--;
			if (i < 0) {
				i = 4;
			}
		}
		if(GUI.Button(new Rect(470 * rationScaleTemp, 145 * rationScaleTempH, 50 * rationScaleTemp, 50 * rationScaleTempH), rightArrow, Mystyle)){
			i = i + 1;
			if (i > 4) {
				i = 0;
			}
		}

		if (GUI.Button (new Rect (70 * rationScaleTemp, 130 * rationScaleTempH, 100 * rationScaleTemp, 100 * rationScaleTempH), fengjingTexture1, Mystyle)) {
			i = 0;
		}
		if (GUI.Button (new Rect (150 * rationScaleTemp, 130 * rationScaleTempH, 100 * rationScaleTemp, 100 * rationScaleTempH), fengjingTexture2, Mystyle)) {
			i = 1;
		}
		if (GUI.Button (new Rect (230 * rationScaleTemp, 130 * rationScaleTempH, 100 * rationScaleTemp, 100 * rationScaleTempH), fengjingTexture3, Mystyle)) {
			i = 2;
		}
		if (GUI.Button (new Rect (310 * rationScaleTemp, 130 * rationScaleTempH, 100 * rationScaleTemp, 100 * rationScaleTempH), fengjingTexture4, Mystyle)) {
			i = 3;
		}
		if (GUI.Button (new Rect (390 * rationScaleTemp, 130 * rationScaleTempH, 100 * rationScaleTemp, 100 * rationScaleTempH), fengjingTexture5, Mystyle)) {
			i = 4;
		}
//		if (GUI.Button (new Rect (470 * rationScaleTemp, 130 * rationScaleTempH, 100 * rationScaleTemp, 100 * rationScaleTempH), fengjingTexture6, Mystyle)) {
//			i = 5;
//		}


		windowRect = GUI.Window (0, windowRect, DoMyWindow, "相 册");

		if (GUI.Button (new Rect (70 * rationScaleTemp, 830 * rationScaleTempH, 100 * rationScaleTemp, 50 * rationScaleTempH), ackTexture, Mystyle)) {
			Debug.Log ("显示的风景图片");
		}

		if (GUI.Button (new Rect (370 * rationScaleTemp, 830 * rationScaleTempH, 100 * rationScaleTemp, 50 * rationScaleTempH), returnTexture, Mystyle)) {
			Application.Quit ();
		}
			
	}
	public void DoMyWindow(int windowID){
		GUI.DrawTexture (new Rect (10 * rationScaleTemp, 30 * rationScaleTempH, 480 * rationScaleTemp, 480 * rationScaleTempH), fengjing [i], ScaleMode.ScaleToFit, true, 500.0f / 500.0f);
	}

}
