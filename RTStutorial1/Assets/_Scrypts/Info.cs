using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RTS.UI
{
	public class Info : MonoBehaviour {

		[SerializeField] private Text nameText;
		[SerializeField] private Slider healthBar;
		[SerializeField] private Selector selector;
		[SerializeField] private Text healthText;

		private ObjectInfo currentInfo;

		private void Start()
		{
			selector.ObjectSelected += HandleObjectSelected;

			nameText.text = "info.text1";
			healthBar.maxValue = 100;
			healthBar.value = 50;
		}

		private void HandleObjectSelected(ObjectInfo info)
		{
			currentInfo = info;

			nameText.text = info.Name;
			healthBar.maxValue = info.MaxHealth;
			healthBar.value = info.CurrentHealth;
			healthText.text = info.healthText;
		}

		private void Update()
		{
			if (currentInfo != null) {
				healthBar.gameObject.SetActive (true);
				nameText.text = currentInfo.Name;
				healthBar.maxValue = currentInfo.MaxHealth;
				healthBar.value = currentInfo.CurrentHealth;
				healthText.text = currentInfo.healthText;
			} else {
				nameText.text = string.Empty;
				healthBar.gameObject.SetActive (false);
			}
		}
	}
}
