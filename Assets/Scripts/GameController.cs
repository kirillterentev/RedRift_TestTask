using UnityEngine;

public class GameController : MonoBehaviour
{
	private const float ForceSensitivity = 0.5f;

	[SerializeField]
	private Rigidbody2D _ball;
	[SerializeField]
	private UIController _uiController;
	[SerializeField]
	private PlatformController[] _platforms;
	[SerializeField]
	private GameObject _buttonsParent;

	private InputController _inputController;
	private AbstractFactory _buttonFactory;
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

		_buttonFactory = _buttonsParent.AddComponent<ButtonsFactory>();
	}

	private void Start()
	{
		foreach (var platform in _platforms)
		{
			platform.CollisionEvent.AddListener(IncrementBounceCount);
		}

		_buttonFactory.CreateProduct<IButton>();
		_buttonFactory.CreateProduct<IButton>();
		_buttonFactory.CreateProduct<IButton>();
	}

	private void Update()
    {
	    _forceDirection = _inputController.GetInputDirection();
	    if (_forceDirection != null)
	    {
			_ball.AddForce((Vector2)_forceDirection * ForceSensitivity, ForceMode2D.Force);
	    }

	    if (_inputController.GetButtonBack())
	    {
			_uiController.SetActiveSwitchPlanetWindow();
	    }
    }

	private void IncrementBounceCount()
	{
		_bounceCount++;
	}
}
