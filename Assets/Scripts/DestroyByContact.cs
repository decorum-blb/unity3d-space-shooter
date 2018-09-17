﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {
    public GameObject explosion;
    public GameObject playerExplosion;

    public int scoreValue;
    private GameController gameController;

    void Start() {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");

        if (gameControllerObject != null) {
            gameController = gameControllerObject.GetComponent<GameController>();
        } 
        if(gameController == null) {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Boundary") {
            return;
        }

        Transform transform = GetComponent<Transform>();

        if (other.tag == "Player") {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
        }

        Instantiate(explosion, transform.position, transform.rotation);

        gameController.AddScore(scoreValue);

        Destroy(other.gameObject); // Destroy Bolts as they collide with the Asteroid
        Destroy(this.gameObject); // Destroy the Asteroid itself
    }
}
