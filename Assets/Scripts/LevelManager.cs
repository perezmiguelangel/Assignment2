using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{

    public GameObject enemy;
    public float spawnSpeed = 0.5f;
    public float waveCooldown = 1f;
    public float enemySpeed;
    public float amplitude;
    public float frequency;

    

    //Movement type: 0 = straight, 1 = sine
    
    
    void Update()
    {

    }
   
   
    void Start()
    {
        int levelNum = GameController.gcInstance.level;
        if (levelNum == 1)
        {
            StartCoroutine(Level1());
        }
        else if (levelNum == 2)
        {
            StartCoroutine(Level2());
        }
        else if (levelNum == 3)
        {
            StartCoroutine(Level3());
        }   
    }

    IEnumerator Level1()
    {
        GameController.gcInstance.level = 1;
      //  Debug.Log("level 1 start");
        enemySpeed = 6;
        amplitude = 4;
        frequency = 0.5f;
        yield return StartCoroutine(StEnemy(5, enemySpeed));

        yield return new WaitForSecondsRealtime(waveCooldown);

        yield return StartCoroutine(SineEnemy(5, amplitude, frequency, enemySpeed));

        yield return new WaitForSecondsRealtime(waveCooldown);

        yield return StartCoroutine(StEnemy(3, enemySpeed));

        yield return new WaitForSecondsRealtime(waveCooldown);

        yield return StartCoroutine(SineEnemy(10, amplitude, frequency, enemySpeed));

        yield return new WaitForSecondsRealtime(3);
      //  Debug.Log("level 1 finish");
        StartCoroutine(Level2());
    }
    IEnumerator Level2()
    {
        GameController.gcInstance.level = 2;
       // Debug.Log("level 2 start");
        enemySpeed = 8;
        amplitude = 5;
        frequency = 0.25f;
        yield return StartCoroutine(SineEnemy(5, amplitude, frequency, enemySpeed));

        yield return new WaitForSecondsRealtime(waveCooldown);



        yield return new WaitForSecondsRealtime(3);
       // Debug.Log("level 2 finish");
        StartCoroutine(Level3());
    }

    IEnumerator Level3()
    {
        GameController.gcInstance.level = 3;
        //Debug.Log("level 3 start");
        enemySpeed = 10;
        amplitude = 6;
        frequency = 0.2f;
        yield return StartCoroutine(SineEnemy(5, amplitude, frequency, enemySpeed));
        yield return new WaitForSecondsRealtime(waveCooldown);
        enemySpeed = 12;
        yield return StartCoroutine(SineEnemy(3, amplitude, frequency, enemySpeed));
        yield return new WaitForSecondsRealtime(waveCooldown);
        enemySpeed = 10;
        yield return StartCoroutine(StEnemy(5, enemySpeed));
        yield return new WaitForSecondsRealtime(waveCooldown);
        yield return StartCoroutine(SineEnemy(10, amplitude, frequency, enemySpeed));
        yield return new WaitForSecondsRealtime(waveCooldown);
        yield return StartCoroutine(SineEnemy(5, amplitude, frequency, enemySpeed));
        yield return StartCoroutine(StEnemy(5, enemySpeed));

        //Debug.Log("level 3 finish");
    }
    IEnumerator SineEnemy(int amt, float amp, float frq, float speed)
    {
        //Debug.Log("entered sineenemy");
        for (int i = 0; i < amt; i++)
        {
            GameObject enemyObject = Instantiate(enemy, transform.position, transform.rotation);
            enemyObject.GetComponent<EnemyController>().SetType(1);
            enemyObject.GetComponent<EnemyController>().SetAmpFrq(amp, frq);
            enemyObject.GetComponent<EnemyController>().SetSpeed(speed);

            yield return new WaitForSecondsRealtime(spawnSpeed);
        }
    }

    IEnumerator StEnemy(int amt, float speed)
    {
        //Debug.Log("entered STenemy");
        for (int i = 0; i < amt; i++)
        {
            GameObject enemyObject = Instantiate(enemy, transform.position, transform.rotation);
            enemyObject.GetComponent<EnemyController>().SetType(0);
            enemyObject.GetComponent<EnemyController>().SetSpeed(speed);

            yield return new WaitForSecondsRealtime(spawnSpeed);
        }
    }
    
   
}
