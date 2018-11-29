using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
   [SerializeField] float screenWidthInUnits = 16f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(Input.mousePosition.x / Screen.width * screenWidthInUnits);
	}
}
