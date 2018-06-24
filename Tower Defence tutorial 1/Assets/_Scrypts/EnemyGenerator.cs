using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {


	[SerializeField] private float waveDelay = 10.0f;
	[SerializeField] private float spawnDelay = 1.5f;
	[SerializeField] private int count = 10;
	[SerializeField] private WaveInfo[] infos;

	[System.Serializable]
	private class WaveInfo
	{
		public UnityKeyValue[] pair;
		public float spawnDelay;

		private int currentPair;

		public GameObject GetNextEnemy()
		{
			for (int i = 0; i < pair.Length; i++) {
				if (pair [i].value == 0)
					continue;
				
				GameObject enemy = pair [currentPair].key;

				pair [currentPair].value--;
				currentPair = (currentPair + 1) % pair.Length;

				return enemy;
			}
			return null;
		}
	}

	[System.Serializable]
	private class UnityKeyValue
	{
		public GameObject key;
		public int value;
	}

	private float currentTime = 0f;
	private bool isWave = true;
	private int currentCount;
	private int currentWave;

	private void Start()
	{
		currentTime = spawnDelay;
	}

	private void Update()
	{
		currentTime += Time.deltaTime;

		if (isWave)
			ProcessWave ();
		else
			Wait ();
	}

	private void Wait()
	{
		if (currentTime >= infos[currentWave].spawnDelay) {
			currentTime = 0.0f;
			isWave = true;
		}
	}

	private void ProcessWave()
	{
		if (currentTime >= infos[currentWave].spawnDelay) {
			currentTime = 0.0f;

			GameObject enemy = infos [currentWave].GetNextEnemy ();

			if (enemy != null) {

			}



			GameObject newEnemy = Instantiate (enemy);
			newEnemy.SetActive (true);
			currentCount++;
		}

		if (currentCount > count) {
			currentTime = 0.0f;
			currentCount = 0;
			isWave = false;
		}
	}
}
