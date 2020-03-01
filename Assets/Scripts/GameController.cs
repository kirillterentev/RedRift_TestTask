using System.Linq;
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
	[SerializeField]
	private PlanetInfo[] _planets;

	private InputController _inputController;
	private AbstractFactory _buttonFactory;
	private PlanetInfo _currentPlanet;
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

		foreach (var planet in _planets)
		{
			var button = _buttonFactory.CreateProduct<IButton>();
			button.SetText(planet.Name);
			button.SetAction(() => SetPlanet(planet));
		}

		SetPlanet(_planets.First(x => x.Name == "Earth"));
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

	private void SetPlanet(PlanetInfo info)
	{
		_currentPlanet = info;

		Physics2D.gravity = info.Gravity;
		Camera.main.backgroundColor = info.BackgroundColor;

		_uiController.SetActiveSwitchPlanetWindow();
	}
}
