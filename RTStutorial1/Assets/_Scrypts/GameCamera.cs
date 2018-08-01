using UnityEngine;

namespace RTS
{
	public class GameCamera : MonoBehaviour
	{
		[Header("Settings"), SerializeField] private float speed = 5f;
		[SerializeField] private float rotationSpeed = 120f;
		[SerializeField] private float scrollSpeed = 100f;
		[SerializeField] private float xRigMin = 0f, xRigMax = 0.6f, yRigMin = 0f, yRigMax = 0.8f, xRigScrollMin = 5f, xRigScrollMax = 20;
		[Header("References"), SerializeField] private Transform xRig;
		[SerializeField] private Transform yRig;

		private Vector3 movement;
		private float rotation;
		private float rotationX;
		private float scroll = 0.0f;

		private void Update()
		{
			movement = Vector3.zero;
			rotation = 0.0f;
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
				rotation = Input.GetAxis ("Mouse X");//new Vector2 (Input.GetAxis ("Mouse X"), Input.GetAxis ("Mouse Y"));
				rotationX = Input.GetAxis("Mouse Y");
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
			if ((xRig.rotation.x > xRigMin && xRig.rotation.x < xRigMax) || (rotationX < 0 && xRig.rotation.x < xRigMax) || (xRig.rotation.x > xRigMin && rotationX > 0))
				xRig.rotation *= Quaternion.Euler (-rotationX * rotationSpeed * Time.deltaTime, 0.0f, 0.0f);

			if ((yRig.rotation.y > yRigMin && yRig.rotation.y < yRigMax) || (rotation > 0 && yRig.rotation.y < yRigMax) || (yRig.rotation.y > yRigMin && rotation < 0))
				yRig.rotation *= Quaternion.Euler (0.0f, rotation * rotationSpeed * Time.deltaTime, 0.0f);
		}

		private void Zoom()
		{
			if (xRig.position.y > xRigScrollMin && xRig.position.y < xRigScrollMax)
				yRig.position += xRig.forward * scroll * scrollSpeed * Time.deltaTime;
			else
			{
				if (xRig.position.y <= xRigScrollMin && scroll < 0)
					yRig.position += xRig.forward * scroll * scrollSpeed * Time.deltaTime;
				if (xRig.position.y >= xRigScrollMax && scroll > 0)
					yRig.position += xRig.forward * scroll * scrollSpeed * Time.deltaTime;
			}


		}

	}
}
