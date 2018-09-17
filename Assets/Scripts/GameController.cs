using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float startWait;
    public float spawnWait;
	public float waveWait;

    void Start() {
        StartCoroutine(SpawnWaves());
    }
    IEnumerator SpawnWaves() {
        yield return new WaitForSeconds(startWait);

        while (true) {
            for (int i = 0; i < hazardCount; i++) {
                createHazard();
                yield return new WaitForSeconds(spawnWait);
            }
        }

		yield return new WaitForSeconds(waveWait);
    }

    private GameObject createHazard() {
        float value = Random.Range(-spawnValues.x, spawnValues.x);

        Vector3 spawnPosition = new Vector3(value, spawnValues.y, spawnValues.z);
        Quaternion spawnRotation = Quaternion.identity;

        return Instantiate(hazard, spawnPosition, spawnRotation) as GameObject;
    }
}
