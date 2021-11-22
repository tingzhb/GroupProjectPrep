using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThreat : MonoBehaviour {

	GameObject enemy;
    public Vector3 enemyLocation;
    void Update() {

        enemy = GameObject.FindWithTag("Enemy");
        enemyLocation = enemy.transform.position;
        Debug.Log(Vector3.Distance(transform.position, enemyLocation));
    }
}
