using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveCreater : MonoBehaviour
{
    public GameObject[] enemyPFs;
    public GameObject[] wavePoints;
    public int scoreThreshold = 1000; // 设置分数阈值
    public int fasterSpawnRate = 2;
    float nxtWave;
    bool a = true;
    // Start is called before the first frame update
    void Start()
    {
        //Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (Text123.isCreate && a)
        {
            
            Spawn();
            Text123.isCreate = false;
            a = false;
        }
        if(GameManager.isStart&&nxtWave < Time.time) {
            
            nxtWave = Time.time + Random.Range(1f, 2f)/ fasterSpawnRate;
            Spawn();
        }
        if (GameManager.score >= 50&& GameManager.score<=100)
        {
            fasterSpawnRate = 2;
        }
        else if (GameManager.score >= 100)
        {
            fasterSpawnRate = 3;
        }
    }

    private void Spawn()
    {
        var enemyPF = enemyPFs[Random.Range(0, enemyPFs.Length)];
        var wavePoint = wavePoints[Random.Range(0, wavePoints.Length)];

        var spawnNum = Random.Range(2, 4);

        StartCoroutine(SpawnContiously(enemyPF, wavePoint, spawnNum));
    }

    IEnumerator SpawnContiously(GameObject enemyPf, GameObject wavePoint, int spawnNum) { 
        while(spawnNum > 0) {
            spawnNum--;

            Transform[] paths = wavePoint.GetComponentsInChildren<Transform>();

            if(paths.Length > 1) {
                var enemy = Instantiate(enemyPf, paths[1].position, Quaternion.identity);
                enemy.GetComponent<Enemy>().SetPaths(paths);
            }
            yield return new WaitForSeconds(Random.Range(2f, 4f));
        }
    }
}
