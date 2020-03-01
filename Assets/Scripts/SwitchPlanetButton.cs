using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SwitchPlanetButton : MonoBehaviour, IButton
{
	[SerializeField]
	private Text _text;

	private UnityEvent _onClickEvent;

	private void OnDestroy()
	{
		_onClickEvent?.RemoveAllListeners();
	}

	public void SetAction(UnityAction action)
	{
		if (_onClickEvent == null)
		{
			_onClickEvent = new UnityEvent();
		}

		_onClickEvent.AddListener(action);
	}

	public void SetText(string text)
	{
		_text.text = text;
	}
}
