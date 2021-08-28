using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBounce : MonoBehaviour
{

    [SerializeField] List<Enemy> enemies;

    // private System.Random random;

    IEnumerator Start()
    {
        // random = new System.Random();
        do {
            yield return StartCoroutine(SpawnAllEnemiesInWave());
        } while (true);
    }

    private IEnumerator SpawnAllEnemiesInWave () {
        for (int enemyCnt = 0; enemyCnt < 5; enemyCnt++) {
            Enemy newEnemy = Instantiate(
                enemies[Random.Range(0, enemies.Count)],
                CalculateRandomStartPos(),
                Quaternion.identity
            );
            Rigidbody2D rb = newEnemy.GetComponent<Rigidbody2D>();
            // Debug.Log(rb);
            newEnemy.GetComponent<Rigidbody2D>().velocity = CreateRandomVector2D();
            yield return new WaitForSeconds(2);
        }
    }


    private Vector3 CalculateRandomStartPos() {
        float randomY = Random.Range(-5f, 10f);
        float randomX = Random.Range(4.5f, 6f);
        int randomSide = Random.Range(-1, 1);
        if (randomSide < 0) {
            randomX *= -1;
        }
        return new Vector3(randomX, randomY, 0);
    }

    private Vector2 CreateRandomVector2D() {
        float randomY = Random.Range(-1f, 2f);
        float randomX = Random.Range(-1f, 2f);
        float randomMultiplyY = Random.Range(5f, 10f);
        float randomMultiplyX = Random.Range(5f, 10f);
        Vector2 randomVector = new Vector2(randomX*randomMultiplyX, randomY*randomMultiplyY);
        // Debug.Log(randomVector);
        return randomVector;
    }
}
