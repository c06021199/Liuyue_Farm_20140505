using UnityEngine;
using System.Collections;
using System;


public class moving : MonoBehaviour {
	
	private Vector3 BeginPosition;
	private Vector3 EndPosition;
	private float touchdistance;
	private NavMeshAgent cha_bass2TestCQ;

	void Start(){
		cha_bass2TestCQ = gameObject.GetComponent<NavMeshAgent> ();
		cha_bass2TestCQ.transform.position = new Vector3 (-50,0,10);
	}
	void Update(){
		if (Input.GetMouseButtonDown(0))  
		{  
			//摄像机到点击位置的的射线  
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);  
			RaycastHit hit;  
			if (Physics.Raycast(ray, out hit,Mathf.Infinity))  
			{  
				//判断点击的是否地形  
				if (hit.transform.gameObject.name == "pPlane1")  
				{  
				//点击位置坐标  
				Vector3 point = hit.point;  
				//转向  
				transform.LookAt(new Vector3(point.x, transform.position.y, point.z));  
				//设置寻路的目标点  
				cha_bass2TestCQ.SetDestination(point);  
				}
			}  
			//		if (Input.touchCount == 1) {
			//			Touch touch = Input.GetTouch (0);
			//			if (touch.phase == TouchPhase.Began) {
			//					Ray ray = Camera.main.ScreenPointToRay (touch.position);
			//					RaycastHit hit;
			//					if (Physics.Raycast (ray, out hit)) {
			//						GameObject obj = hit.transform.gameObject; 
			//						if (obj.name == "Terrain") {
			//							man.SetDestination (hit.point);
			//						}
			//					}		
			//				}
			//			}	
		}
		
	}
}

