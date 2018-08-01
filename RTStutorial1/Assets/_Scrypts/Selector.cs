using System;
using UnityEngine;
using UnityEngine.UI;


namespace RTS
{
	public class Selector : MonoBehaviour
	{
		[SerializeField] private Text nameText;

		public event Action<ObjectInfo> ObjectSelected;

		private void Update()
		{

			if (Input.GetMouseButtonDown(0))
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;

				if (Physics.Raycast(ray, out hit))
				{
					ObjectInfo info = hit.collider.GetComponent<ObjectInfo>();

					if(info != null && ObjectSelected != null)
					{
						ObjectSelected(info);
					}
				}
			}
		}
	}
}




//namespace RTS
//{
//	public class Selector : MonoBehaviour {
//
//		public delegate void MyDelegate(ObjectInfo info);
//
//		[SerializeField] private Text nameText;
//
//		public event MyDelegate ObjectSelected;
//
//		private void Update()
//		{
//			if (Input.GetMouseButton (0)) {
//				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
//				RaycastHit hit;
//
//				if (Physics.Raycast (ray, out hit)) {
//					ObjectInfo info = hit.collider.GetComponent<ObjectInfo> ();
//
//
//					if (info != null && ObjectSelected != null)
//						ObjectSelected.Invoke (info);
//				}
//			}
//		}
//	}
//}
