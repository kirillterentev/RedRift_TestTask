using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlatformController : MonoBehaviour
{
	[HideInInspector]
	public UnityEvent CollisionEvent;

	private Image _image;

	private void Awake()
	{
		_image = GetComponent<Image>();
		CollisionEvent = new UnityEvent();
	}

	private void SetRandomColor()
	{
		Color color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1);
		_image.color = color;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		SetRandomColor();
		CollisionEvent?.Invoke();
	}
}
