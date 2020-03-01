using UnityEngine;

public class MouseController : MonoBehaviour, InputController
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

		if (Input.GetMouseButton(0))
		{
			Vector2 mousePosition = Input.mousePosition;
			_inputDirection = new Vector2(mousePosition.x - _centerOfScreen.x, 0);
		}

		return _inputDirection;
	}
}

