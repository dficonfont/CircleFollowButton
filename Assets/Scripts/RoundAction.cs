using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class RoundAction : MonoBehaviour, IPointerDownHandler,IPointerUpHandler{
	public Camera eventCamera;
	public Canvas canvas;
	public Transform obj;
	private float radius_length;
	private Vector3 circlePos;
	bool isPressed = false;
	private IList<Graphic> graphics;
	void Start(){
		radius_length = 114;
		graphics = GraphicRegistry.GetGraphicsForCanvas(canvas);
		Debug.Log (graphics.Count);
	}

	void Update(){
		if (isPressed) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			var screenCenterPoint = new Vector2 (Screen.width / 2.0f, Screen.height / 2.0f);
			for (int i = 0; i < graphics.Count; ++i) {
				var graphic = graphics [i];
				// -1 means it hasn't been processed by the canvas, which means it isn't actually drawn
				if (graphic.depth == -1 || !graphic.raycastTarget) {
					continue;
				}
				if (!graphic.Raycast (screenCenterPoint, eventCamera)) {
					continue;
				}
				//var dist = Vector3.Dot(transForward, trans.position - ray.origin) / Vector3.Dot(transForward, ray.direction);
				float dist;
				if (new Plane (graphic.transform.forward, graphic.transform.position).Raycast (ray, out dist)) {
					var m = ray.GetPoint (dist);
					Debug.DrawLine (ray.origin, ray.GetPoint (dist), Color.red);
					OnBtnDrag (m);
				}
			}
		}
	}

	public void OnPointerDown(PointerEventData eventtData){
		isPressed = true;
	}
	public void OnPointerUp(PointerEventData eventtData){
		isPressed = false;
	}

	public void OnBtnDrag(Vector3 dist){
		float angle = Mathf.Atan2 (dist.y - obj.position.y, dist.x - obj.position.x);
		circlePos.x = obj.position.x + radius_length * Mathf.Cos(angle);
		circlePos.y = obj.position.y + radius_length * Mathf.Sin(angle);
		circlePos.z = dist.z;
		transform.position = circlePos;
		GameObject.Find ("Canvas/RadioProgressBar/LoadingBar").GetComponent<Image> ().fillAmount = (Mathf.PI - angle) / (2 * Mathf.PI);
		GameObject.Find ("Canvas/RadioProgressBar/Center/TextIndicator").GetComponent<Text>().text = (int)(((Mathf.PI - angle) / (2 * Mathf.PI)) * 100) + "%";
	}
}
