using UnityEngine;

namespace RTS
{
	public class GameCamera : MonoBehaviour
	{
		[Header("Settings"), SerializeField] private float speed = 5f;
		[SerializeField] private float rotationSpeed = 120f;
		[SerializeField] private float scrollSpeed = 100f;
		[Header("References"), SerializeField] private Transform xRig;
		[SerializeField] private Transform yRig;

		private Vector3 movement;
		private Vector2 rotation;
		private float scroll = 0.0f;

		private void Update()
		{
			movement = Vector3.zero;
			rotation = Vector2.zero;
			scroll = 0.0f;

			CheckKeyboard ();
			CheckMouse ();

			Move ();
			Rotate ();
			Zoom ();
		}

		private void CheckKeyboard()
		{
			movement.x += Input.GetAxisRaw ("Horizontal");
			movement.z += Input.GetAxisRaw ("Vertical");
		}

		private void CheckMouse()
		{
			if (Input.GetKey (KeyCode.LeftAlt)) {
				//mouse rotate
				rotation = new Vector2 (Input.GetAxis ("Mouse X"), Input.GetAxis ("Mouse Y"));
				return;
			}

			//scroll input
			scroll += Input.GetAxis ("Mouse ScrollWheel");

			//0 to 1
			Vector3 viewportPoint = Camera.main.ScreenToViewportPoint (Input.mousePosition) - new Vector3(0.5f, 0.5f);

			movement.x += Mathf.Abs (viewportPoint.x) >= 0.5f ? Mathf.Sign (viewportPoint.x) : 0.0f;
			movement.z += Mathf.Abs (viewportPoint.y) >= 0.5f ? Mathf.Sign (viewportPoint.y) : 0.0f;

		}

		private void Move()
		{
			movement = movement.magnitude > 1 ? movement.normalized : movement;
			yRig.Translate(movement * speed * Time.deltaTime);
		}

		private void Rotate()
		{
			xRig.rotation *= Quaternion.Euler (-rotation.y * rotationSpeed * Time.deltaTime, 0.0f, 0.0f);
			yRig.rotation *= Quaternion.Euler (0.0f, rotation.x * rotationSpeed * Time.deltaTime, 0.0f);
		}

		private void Zoom()
		{
			yRig.position += xRig.forward * scroll * scrollSpeed * Time.deltaTime;
		}

	}
}
