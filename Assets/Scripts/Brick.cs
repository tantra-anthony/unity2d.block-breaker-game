using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    private int hitCount;
    private SceneLoader sceneLoader;
    private bool isBreakable;

    public Sprite[] hitSprite;
    public static int breakableCount = 0;
    public GameObject smoke;

	// Use this for initialization
	void Start () {
        isBreakable = (this.tag == "Breakable");
        //keep track of breakable bricks

        if (isBreakable) {
            breakableCount++;
        }

        hitCount = 0;
        sceneLoader = GameObject.FindObjectOfType<SceneLoader>();
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void OnCollisionEnter2D(Collision2D collision) {

        if (isBreakable) {
            handleHits();
        }
    }

    private void handleHits() {
        hitCount++;
        int maxHits = hitSprite.Length + 1;
        //>= because we need to make it such that superpowers in the future dealing more hits isn't excluded
        if (hitCount >= maxHits) {
            breakableCount--;
            PuffSmoke();
            Destroy(gameObject);
        } else {
            LoadSprites();
        }
    }

    private void PuffSmoke() {
            sceneLoader.BrickDestroyed();
            GameObject smokePuff = Instantiate(smoke, gameObject.transform.position, Quaternion.identity) as GameObject;
            ParticleSystem ps = smokePuff.GetComponent<ParticleSystem>();
            ParticleSystem.MainModule psmain = ps.main;
            psmain.startColor = gameObject.GetComponent<SpriteRenderer>().color;
    }

    private void LoadSprites() {
        int spriteIndex = hitCount - 1;

        if (hitSprite[spriteIndex] != null) {
            this.GetComponent<SpriteRenderer>().sprite = hitSprite[spriteIndex];
        } else {
            Debug.LogError("Brick sprite missing");
        }
    }
}
