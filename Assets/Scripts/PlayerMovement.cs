using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private Ray ray;
	RaycastHit targetDestinaton;
	private Quaternion targetRotation;

	void Update() {

 		if (Input.GetMouseButton(0)) {
	        GetPlayerDestination();
        }
        RotatePlayerToDestination();
        MovePlayerToDestination();
	}

	void RotatePlayerToDestination() {
		targetRotation = Quaternion.FromToRotation(Vector3.forward, targetDestinaton.point);
		transform.rotation = Quaternion.RotateTowards(this.transform.rotation, targetRotation, 360 * Time.deltaTime);
		
	}

	void MovePlayerToDestination() {
		Physics.Raycast(ray, out targetDestinaton, 100);
		transform.position = Vector3.MoveTowards(transform.position, targetDestinaton.point, 5 * Time.deltaTime);
	}

	void GetPlayerDestination() {
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
	}
}
