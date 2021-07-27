using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyPathing : MonoBehaviour {

    WaveConfig waveConfig;
    int waypointIdx = 0;
    List<Transform> waypoints;

    // Start is called before the first frame update
    void Start() {
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointIdx].transform.position;
    }

    // Update is called once per frame
    void Update() {
        Move();
    }

    public void SetWaveConfig(WaveConfig waveConfig) {
        this.waveConfig = waveConfig;
    }

    private void Move() {
        if(waypointIdx <= waypoints.Count - 1) {
            var targetPos = waypoints[waypointIdx].transform.position;
            var movementThisFrame = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position,
                                                     targetPos,
                                                     movementThisFrame);
            if (transform.position == targetPos) {
                waypointIdx++;
            }
        } else {
            Destroy(gameObject);
        }
    }
}
