using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour {

    public enum SpawnState {Spawning, Waiting, Coutning};

    [System.Serializable]
    public class Wave
    {
       public string name;
       public Transform [] enemytype;
       public int [] count;
       public float rate;   
    }
    
    public bool completed; 
    public Wave[] waves;
    private int nextWave = 0;
    public Transform[] spawnPoints;
         
    public float TimeBetweenWaves = 5f;
    public float waveCountDown;
    private SpawnState state = SpawnState.Coutning;

    private float SearchCountDown = 1f;
    public GameObject[] enemies;
    int lastnumber;
    public bool Won;
    void Start()
    {
        waveCountDown = TimeBetweenWaves;
        completed = false;
        Won = false; 
    }

    void Update()
    {

        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (state == SpawnState.Waiting)
        {
            //if enemies are still alive
            if(EnemyIsAlive() != true)
            {
                //Begin a new Wave
                waveCompleted();
                completed = true;
                SoundManager.PlaySound("PowerUp");
                Debug.Log("Wave Completed");
            }
            else
            {
                return;
            }
        }
        if(state == SpawnState.Spawning)
        {
            completed = false;
        }

        if(waveCountDown <= 0)
        {
            if(state != SpawnState.Spawning)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountDown -= Time.deltaTime;//coutns down till next wave
        }
    }

    void waveCompleted()
    {
        state = SpawnState.Coutning;//counting down to next wave
        waveCountDown = TimeBetweenWaves;

        if(nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            Debug.Log("Compelted all Waves");//END GAME or stat multiplyer
            Won = true;
        }
        else
        {
         nextWave += 1;
         GameObject.Find("Player").GetComponent<PlayerController>().skillPoints += 1;
        }
    }

    bool EnemyIsAlive() {
        SearchCountDown -= Time.deltaTime;

        if (SearchCountDown <= 0f)
        {
            SearchCountDown = 1;
            if (enemies.Length == 0)
            {
                return false;
            }
        }

        return true;
    }

    IEnumerator SpawnWave (Wave _wave)
    {
        state = SpawnState.Spawning;

        //Spawn
        for(int k = 0; k < _wave.count.Length; k++)
        {
            int amountOfEnemeies = _wave.count[k];
            for(int i = 0; i < amountOfEnemeies; i++)
            {
                spawnEnemyType(_wave.enemytype, k);
                yield return new WaitForSeconds(1f / _wave.rate);
            }

        }

        state = SpawnState.Waiting;
        yield break;
    }

    public void spawnEnemyType(Transform [] _enemyType, int i)
    {
                Transform sp = spawnPoints[RandomNum(1)];
                //Debug.Log(spawnPoints[RandomNum(1)]);
                //Debug.Log(lastnumber);
                Instantiate(_enemyType[i], sp.position, sp.rotation);
    }

    private int RandomNum(int index)
    {
        index = Random.Range(0, spawnPoints.Length);
        if (index == lastnumber)
        {
            return RandomNum(index);
        }
        else
        {
            lastnumber = index;
            return index;
        }
    }
}
