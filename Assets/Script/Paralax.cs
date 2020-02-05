using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour {

	public float paralaxSpeedX;
	public float paralaxSpeedY;

	private Transform cameraTransformX;
	private Transform cameraTransformY;
	private float lastCameraX;
	private float lastCameraY;

    public bool invertX;
    public bool invertY;

	// Use this for initialization
	void Start () {
		cameraTransformX = Camera.main.transform;
        cameraTransformY = Camera.main.transform;

		lastCameraX = cameraTransformX.position.x;
        lastCameraY = cameraTransformX.position.y;

	}
	
	// Update is called once per frame
	void Update () {

        if (invertX == true) {

            float deltaX = cameraTransformX.position.x - lastCameraX;
            transform.position += Vector3.left * (deltaX * paralaxSpeedX);
            lastCameraX = cameraTransformX.position.x;

        }
        else if (invertX == false) {

            float deltaX = cameraTransformX.position.x - lastCameraX;
            transform.position += Vector3.right * (deltaX * paralaxSpeedX);
            lastCameraX = cameraTransformX.position.x;

        }

        if (invertY == true) {

            float deltaY = cameraTransformY.position.y - lastCameraY;
            transform.position += Vector3.down * (deltaY * paralaxSpeedY);
            lastCameraY = cameraTransformY.position.y;

        }
        else if (invertY == false) {

            float deltaY = cameraTransformY.position.y - lastCameraY;
            transform.position += Vector3.up * (deltaY * paralaxSpeedY);
            lastCameraY = cameraTransformY.position.y;

        }




	}
}
