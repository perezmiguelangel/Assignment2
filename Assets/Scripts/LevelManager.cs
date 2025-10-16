using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{

    public GameObject enemy;
    public float spawnSpeed = 0.25f;

    //Movement type: 0 = straight, 1 = sine
    
   
   
    void Start()
    {
        StartCoroutine(Create());
    }

    void Update()
    {

    }

    IEnumerator Create()
    {

        for (int i = 0; i < 10; i++)
        {
            GameObject enemyObject = Instantiate(enemy, transform.position, transform.rotation);
            enemyObject.GetComponent<EnemyController>().SetType(1);

            yield return new WaitForSecondsRealtime(spawnSpeed);
        }
    }
    
   
}
