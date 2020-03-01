using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	private const float ForceSensitivity = 0.5f;

	[SerializeField]
	private Rigidbody2D _ball;

	private InputController _inputController;
	private Vector2? _forceDirection;

	private void Awake()
	{
#if UNITY_EDITOR
		_inputController = gameObject.AddComponent<MouseController>();
#endif


	}

    private void Update()
    {
	    _forceDirection = _inputController.GetInputDirection();
	    if (_forceDirection != null)
	    {
			_ball.AddForce((Vector2)_forceDirection * ForceSensitivity, ForceMode2D.Force);
	    }
    }
}
