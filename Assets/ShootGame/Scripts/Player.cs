using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float minX, maxX, minY, maxY;
    public float moveSpeed = 10f;

    public GameObject laserPF;
    public float fireRate = 100f;
    float nextFire;

    public float yOffset = 0.2f;
    public GameObject explosionPF;
    private bool a = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Pause.isPaused||GameManager.isgameover)
        {

        }
        else
        {

            
            Move();
        }
        if (GameManager.score >= 50 && GameManager.score <= 100)
        {
            fireRate = 6;
        }
        else if (GameManager.score >= 100)
        {
            fireRate = 8;
        }
    }

    private void Fire()
    {
        if (nextFire < Time.time)
        {
            AudioManager.instance.Play("Shoot");
            nextFire = Time.time + 1 / fireRate;
            Vector2 spawnPosition = new Vector2(transform.position.x, transform.position.y + yOffset);
            Instantiate(laserPF, spawnPosition, Quaternion.identity);
        }
    }

    private void Move()
    {


        var dx = Input.GetKey(KeyCode.LeftArrow) ? -1f : Input.GetKey(KeyCode.RightArrow) ? 1f : 0f;
        var dy = Input.GetKey(KeyCode.DownArrow) ? -1f : Input.GetKey(KeyCode.UpArrow) ? 1f : 0f;

        dx *= Time.deltaTime * moveSpeed;
        dy *= Time.deltaTime * moveSpeed;
        if (dx != 0 || dy != 0)
        {
            if (!a)
            {
                Fire();
            }
            
        }
        if(dy == 0&&dx!= 0)
        {
            if (a)
            {
                Fire();
            }

        }
        var x = Mathf.Clamp(transform.position.x, minX, maxX);
        var y = Mathf.Clamp(transform.position.y, minY, maxY);

        var nx = x + dx;
        var ny = y + dy;

        transform.position = new Vector3(nx, ny);
    }

    private void MoveWithMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        var clampedX = Mathf.Clamp(mousePosition.x, minX, maxX);
        var clampedY = Mathf.Clamp(mousePosition.y, minY, maxY);

        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MyBullet")) // 替换 "BulletTag" 为你的子弹标签
        {
            // 子弹碰撞时的处理（这里什么都不做）
        }
        else if (collision.CompareTag("Start"))
        {
            GameManager.isStart = true;
            GameManager.isFirst = false;
        }
        else if (collision.CompareTag("Wall"))
        {
            a = true;
            Debug.Log("4");
        }
        else
        {
            GameManager.isgameover = true;
            AudioManager.instance.Play("Bomb");
            GameManager.instance.GameOver();
            var explosion = Instantiate(explosionPF, transform.position, Quaternion.identity);
            Destroy(explosion, 0.4f);
            Destroy(gameObject);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            a = false;
        }
        a = false;
    }
}
