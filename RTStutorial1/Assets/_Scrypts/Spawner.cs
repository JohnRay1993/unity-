using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTS.UI;

namespace RTS
{
	public class Spawner : MonoBehaviour
	{
		[SerializeField] private Transform spawnPoint;
		[SerializeField] private Abilities abilities;

		public void SpawnUnit(GameObject unit)
		{
			GameObject instance = Instantiate(unit);
			instance.transform.position = spawnPoint.position;
		}
	}
}