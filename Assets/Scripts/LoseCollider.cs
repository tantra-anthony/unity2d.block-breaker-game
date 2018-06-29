﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour {
    
    private void OnTriggerEnter2D(Collider2D collision) {
        print("trigger");
        SceneManager.LoadScene(5);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        print("collison");
    }
}
