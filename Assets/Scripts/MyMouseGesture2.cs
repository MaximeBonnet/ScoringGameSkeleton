using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class MyMouseGesture2 : MonoBehaviour {
	
	Camera[] cameras;
	
	Dictionary<int,GameObject> selectedObjects=new Dictionary<int,GameObject>();
	
	const int NOMBRETOUCHES=10;
	
	void Start(){
		this.cameras = Camera.allCameras;
		List<Camera> cameraList=new List<Camera>(this.cameras);
		cameraList.Sort(CameraCompare.Compare);
		cameras=cameraList.ToArray();
	}

	// Update is called once per frame
	void Update () {
        this.cameras = Camera.allCameras;
        List<Camera> cameraList = new List<Camera>(this.cameras);
        cameraList.Sort(CameraCompare.Compare);
        cameras = cameraList.ToArray();
		//pc
		if(Application.platform==RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor) {
			for(int i=0; i<cameras.Length;i++){
				Ray ray = cameras[i].ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast(ray, out hit, cameras[i].far, cameras[i].cullingMask)){
					if(Input.GetButtonDown("Fire1")){
						//Debug.Log(hit.collider.name);
						hit.collider.gameObject.SendMessage("OnMyMouseDown",SendMessageOptions.DontRequireReceiver);
						selectedObjects.Add(0, hit.collider.gameObject);
					}
				}
				if(selectedObjects.Count>0){
					if( selectedObjects[0]==null){
						selectedObjects.Remove(0);
					}else if(Input.GetButtonUp("Fire1")){
						selectedObjects[0].gameObject.SendMessage("OnMyMouseUp",SendMessageOptions.DontRequireReceiver);
						selectedObjects.Remove(0);
					}else{
						
						selectedObjects[0].gameObject.SendMessage("OnMyMouseMove", (Vector2)Input.mousePosition,SendMessageOptions.DontRequireReceiver);
					}
				}
			}
			
		//intelligenttelephone
		}else{
			if(Input.touches.Length<=NOMBRETOUCHES){
				foreach (Touch touch in Input.touches) {
					int fingerId=touch.fingerId;
					for(int i=0; i<cameras.Length;i++){
						Ray ray = cameras[i].ScreenPointToRay(touch.position);
						RaycastHit hit;
						if (Physics.Raycast(ray, out hit, cameras[i].far, cameras[i].cullingMask)){
							if(touch.phase == TouchPhase.Began) {
								hit.collider.gameObject.SendMessage("OnMyMouseDown",SendMessageOptions.DontRequireReceiver);
								selectedObjects.Add(fingerId, hit.collider.gameObject);
							}
						}
						if(selectedObjects.ContainsKey(fingerId)){
						    GameObject selectedObject = selectedObjects[fingerId];
						    if(selectedObject==null){
							    selectedObjects.Remove(fingerId);
						    }else {
							    selectedObject.gameObject.SendMessage("OnMyMouseMove", touch.position,SendMessageOptions.DontRequireReceiver);
							    if(touch.phase == TouchPhase.Ended) {
								    selectedObjects.Remove(fingerId);
								    selectedObject.gameObject.SendMessage("OnMyMouseUp",SendMessageOptions.DontRequireReceiver);
							    }
						    }
					    }
                    }
				}
			}else{
				selectedObjects.Clear();
			}
		}
	}
	/*void OnGUI(){
		GUI.Label(new Rect(0,0,100,100), selectedObjects.Count.ToString());	
	}*/
}
