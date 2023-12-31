﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform[] paths;
    int nxtIndex = 2;

    float moveSpeed;

    public GameObject laserPF;
    float nxtFire;

    public GameObject explosionPF;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = Random.Range(4f, 8f);
    }

    // Update is called once per frame
    void Update()
    {
        if (paths == null) return;

        // Move
        if(nxtIndex >= paths.Length) {
            Destroy(gameObject);
            return;
        }

        var nxtPos = paths[nxtIndex].position;

        if(transform.position != nxtPos) {
            transform.position = Vector3.MoveTowards(transform.position, nxtPos, Time.deltaTime * moveSpeed);
        }
        else {
            nxtIndex++;
        }

        // Fire
        if(nxtFire < Time.time) {
            nxtFire = Time.time + Random.Range(0.3f, 1f);
            Vector2 spawnPosition = new Vector2(transform.position.x, transform.position.y + 0.5f);
            var laser = Instantiate(laserPF, spawnPosition, Quaternion.identity);
            laser.transform.Rotate(0, 0, 180);
        }
    }

    public void SetPaths(Transform[] paths_) {
        paths = paths_;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBullet")) // 替换 "BulletTag" 为你的子弹标签
        {
            // 子弹碰撞时的处理（这里什么都不做）
        }
        else if (collision.CompareTag("Wall"))
        {
            Destroy(gameObject);

        }
        else
        {
            GameManager.score++;
            AudioManager.instance.Play("Bomb");
            var explosion = Instantiate(explosionPF, transform.position, Quaternion.identity);
            Destroy(explosion, 0.4f);
            Destroy(gameObject);
        }
       
    }
}
