﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : MonoBehaviour {

    public float moveSpeed = 20f;
    private Animator anim;
    private Rigidbody rb;
    private bool death = false;
    public AudioClip duckDeath;
    private AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        if (this.transform.parent.name == "RightSpawn")
        {
            moveSpeed = -moveSpeed;
        }
    }

    // Update is called once per frame
    void Update () {
        if (!death)
        {
            rb.AddForce(Vector3.right * Time.deltaTime * moveSpeed);
        }
        else {
            rb.velocity = Vector3.zero;
        }

	}

    public void Death()
    {
        anim.SetBool("Death", true);
        source.PlayOneShot(duckDeath, 1f);
        death = true;
        StartCoroutine(DestroyTemp());
    }

    IEnumerator DestroyTemp()
    {
        yield return new WaitForSeconds(0.5f);
        DuckDestroy();
    }

    private void DuckDestroy()
    {
        Destroy(gameObject);
    }
}
