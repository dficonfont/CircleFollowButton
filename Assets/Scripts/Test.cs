using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour {
	Image bg;
	Image bg1;
	Image bg2;
	Image bg3;
	float i = 0.0f;
	Color bluk;
	void Start(){
		bluk = new Color32(0,0,0,255);
		bg = GameObject.Find ("Canvas/Background").GetComponent<Image>();
		bg.color = bluk;
		bg1 = GameObject.Find ("Canvas/Background1").GetComponent<Image>();
		bg1.color = bluk;
		bg2 = GameObject.Find ("Canvas/Background2").GetComponent<Image>();
		bg2.color = bluk;
		bg3 = GameObject.Find ("Canvas/Background3").GetComponent<Image>();
		bg3.color = bluk;
	}

	void FixedUpdate(){
		
		if (i > 1/16.0f) {
			if (bg.color == bluk)
				bg.color = Color.white;
			else
				bg.color = bluk;
		}
		if (i > 1/12.0f) {
			if (bg1.color == bluk)
				bg1.color = Color.white;
			else
				bg1.color = bluk;
		}
		if (i > 1/10.0f) {
			if (bg2.color == bluk)
				bg2.color = Color.white;
			else
				bg2.color = bluk;
		}
		if (i > 1/8.0f) {
			i = 0;
			if (bg3.color == bluk)
				bg3.color = Color.white;
			else
				bg3.color = bluk;
		}

		i += Time.deltaTime;
	}
}
