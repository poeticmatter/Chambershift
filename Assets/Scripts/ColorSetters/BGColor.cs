using UnityEngine;
using System.Collections;

public class BGColor : MonoBehaviour {
	public Camera cameraC;
	
	void Start () {
		cameraC.backgroundColor = Colors.inst.Bg();
	}
}
