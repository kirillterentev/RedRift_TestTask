using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	private const float ForceSensitivity = 0.5f;

	[SerializeField]
	private Rigidbody2D _ball;

	private Vector2 _centerOfScreen;

    // Start is called before the first frame update
    void Start()
    {
        _centerOfScreen = new Vector2(Screen.width / 2, Screen.height / 2);
    }

    // Update is called once per frame
    void Update()
    {
	    if (Input.GetMouseButton(0))
	    {
		    Vector2 mousePosition = Input.mousePosition;
			Vector2 forceDirection = new Vector2(mousePosition.x - _centerOfScreen.x, 0);

			_ball.AddForce(forceDirection * ForceSensitivity, ForceMode2D.Force);
	    }
    }
}
