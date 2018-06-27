using UnityEngine;

public class Selector : MonoBehaviour {

	private void Update()
	{
		if (Input.GetMouseButton (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit)) {
				Debug.Log (hit);
			}
		}
	}

}
