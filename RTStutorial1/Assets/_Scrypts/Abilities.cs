using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace RTS.UI
{
	public class Abilities : MonoBehaviour {

		//public Action 

		[SerializeField] private Selector selector;
		[SerializeField] private Abilities[] abilities;

		private ObjectInfo currentInfo;

		private void Start()
		{
			selector.ObjectSelected += Selector_ObjectSelected;
		}

		void Selector_ObjectSelected (ObjectInfo info)
		{
		}

		private void Update()
		{
			if (currentInfo == null) {
				Array.ForEach (abilities, a => a.gameObject.SetActive (false));
			} else {
				int count = currentInfo.Abilities.Length;
				for (int i = 0; i < abilities.Length; i++) {
					if (i < count) {
						abilities [i].gameObject.SetActive (true);

						Spawner spawner = currentInfo.GetComponent<Spawner> ();
					} else {
						abilities [i].gameObject.SetActive (false);
					}
				}
			}

		}
	}
}