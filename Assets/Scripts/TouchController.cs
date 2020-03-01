using UnityEngine;

public class TouchController : MonoBehaviour, InputController
{
	private Vector2 _centerOfScreen;
	private Vector2? _inputDirection;

	private void Start()
	{
		_centerOfScreen = new Vector2(Screen.width / 2, Screen.height / 2);
	}

	public Vector2? GetInputDirection()
	{
		_inputDirection = null;

		if (Input.touchCount > 0)
		{
			Vector2 touchPosition = Input.touches[0].position;
			_inputDirection = new Vector2(touchPosition.x - _centerOfScreen.x, 0);
		}

		return _inputDirection;
	}

	public bool GetButtonBack()
	{
		return Input.GetButtonDown("Cancel");
	}
}
