using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	private const float ForceSensitivity = 0.5f;

	[SerializeField]
	private Rigidbody2D _ball;
	[SerializeField]
	private PlatformController[] _platforms;

	private InputController _inputController;
	private Vector2? _forceDirection;
	private int _bounceCount = 0;

	private void Awake()
	{
#if UNITY_EDITOR
		_inputController = gameObject.AddComponent<MouseController>();
#endif

#if UNITY_ANDROID && !UNITY_EDITOR
		_inputController = gameObject.AddComponent<TouchController>();
#endif
	}

	private void Start()
	{
		foreach (var platform in _platforms)
		{
			platform.CollisionEvent.AddListener(IncrementBounceCount);
		}
	}

	private void Update()
    {
	    _forceDirection = _inputController.GetInputDirection();
	    if (_forceDirection != null)
	    {
			_ball.AddForce((Vector2)_forceDirection * ForceSensitivity, ForceMode2D.Force);
	    }
    }

	private void IncrementBounceCount()
	{
		_bounceCount++;
	}
}
