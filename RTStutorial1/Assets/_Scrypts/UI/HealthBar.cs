using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
	[SerializeField] private Slider bar;
	[SerializeField] private Text count;

	public void Update()
	{
		count.text = bar.value + "/" + bar.maxValue;
	}
}