using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWindowToFront : MonoBehaviour {

	private Rect windowRect = new Rect (20, 20, 120, 50);
	private Rect windowRect2 = new Rect (80, 20, 120, 50);
	private Rect windowRect3 = new Rect (100, 20, 120, 50);
	private bool flag = true;
	void Start(){
		
	}
	void OnGUI(){
		flag = GUI.Toggle (new Rect (20, 100, 120, 50), flag, "Window0 display");   //绘制toggle用来控制窗口的显示
		if (flag) {

			// windowRect  窗口大小， intIndex为func获取一个ID标识.
			windowRect = GUI.Window (0, windowRect, DoMyFirstWindow, "My Window");   
			windowRect2 = GUI.Window (1, windowRect2, DoMySecondWindow, "Second Window");
			windowRect3 = GUI.Window (2, windowRect3, DoMyThirdWindow, "Third Wondow");
		}
	}

	void DoMyFirstWindow(int windowId){
		if (GUI.Button (new Rect (10, 20, 100, 20), "Bring to Front"))
			GUI.BringWindowToFront (0);

		GUI.DragWindow (new Rect (0, 0, 10000, 20));
	}

	void DoMySecondWindow(int windowId){
		if (GUI.Button (new Rect (10, 20, 100, 20), "Bring to front"))
			GUI.BringWindowToFront (1);

		GUI.DragWindow ();
	}
	void DoMyThirdWindow(int windowId){
		if (GUI.Button (new Rect (10, 20, 100, 20), "Bring to front"))  //相对窗口绘制button
			GUI.BringWindowToFront (2);  //如果响应，则将当前窗口显示至最上

		GUI.DragWindow ();  //当前窗口可拖拽
	}
}
