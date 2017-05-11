using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosTest : MonoBehaviour {

	private GameObject obj;

	void Start(){
		obj = GameObject.Find ("Plane");
	}
	// Update is called once per frame

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			print ("世界坐标 " + obj.transform.position);
			print ("本地坐标 " + obj.transform.localPosition);   // 获得Inspector中的坐标
			print ("世界坐标→屏幕坐标 " + Camera.main.WorldToScreenPoint (obj.transform.position));
			print ("世界坐标→视口坐标 " + Camera.main.WorldToViewportPoint (obj.transform.position));
			print ("鼠标点击的屏幕坐标  " + Input.mousePosition);
			print ("鼠标点击的屏幕坐标  " + Camera.main.ScreenToViewportPoint(Input.mousePosition));

		}
	}
}
