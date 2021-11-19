using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField][Range(1f, 20f)]float moveSpeed = 10f;
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
		transform.rotation = Quaternion.RotateTowards(this.transform.rotation, targetRotation, 1f);
	}

	void MovePlayerToDestination() {
		Physics.Raycast(ray, out targetDestinaton, 100);
		transform.position = Vector3.MoveTowards(transform.position, targetDestinaton.point, 0.01f);
	}

	void GetPlayerDestination() {
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
	}
}
