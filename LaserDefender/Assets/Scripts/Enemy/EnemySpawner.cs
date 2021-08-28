using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    // [SerializeField] List<WaveConfig> waveConfigs;
    // [SerializeField] int startingWaveIdx = 0;
    // [SerializeField] bool looping = false;

    // // Start is called before the first frame update
    // IEnumerator Start()
    // {
    //     do {
    //         yield return StartCoroutine(SpawnAllWaves());
    //     } while (looping);
    // }

    // private IEnumerator SpawnAllEnemiesInWave (WaveConfig waveConfig) {
    //     for (int enemyCnt = 0; enemyCnt < waveConfig.GetNumberOfEnemies(); enemyCnt++) {
    //         var newEnemy = Instantiate(
    //             waveConfig.GetEnemyPrefab(),
    //             waveConfig.GetWaypoints()[enemyCnt].transform.position,
    //             Quaternion.identity
    //         );
    //         newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);
    //         yield return new WaitForSeconds(waveConfig.GetTimeBetwweenSpawns());
    //     }
    // }

    // private IEnumerator SpawnAllWaves () {
    //     for (int waveIdx = startingWaveIdx; waveIdx < waveConfigs.Count; waveIdx++)
    //     {
    //         var currWave = waveConfigs[waveIdx];
    //         yield return StartCoroutine(SpawnAllEnemiesInWave(currWave));
    //     }
    // }
}
