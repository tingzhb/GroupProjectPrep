using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private Ray ray;
	RaycastHit hit;
	Vector3 newCorods;
	Vector3 newDestination;
	private Quaternion targetRotation;
	
	void Update() {

 		if (Input.GetMouseButton(0)) {
	        GetPlayerDestination();
        }
        RotatePlayerToDestination();
        MovePlayerToDestination();
	}

	void RotatePlayerToDestination() {
		targetRotation = Quaternion.FromToRotation(Vector3.forward, newDestination);
		transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 45 * Time.fixedDeltaTime);
		
	}

	void MovePlayerToDestination() {
		
		transform.position = Vector3.MoveTowards(transform.position, newDestination, 0.5f * Time.fixedDeltaTime);
	}

	void GetPlayerDestination() {
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Physics.Raycast(ray, out hit, 100);
		newCorods = hit.point;
		newDestination = new Vector3(newCorods.x, 0, newCorods.z);
	}
}
