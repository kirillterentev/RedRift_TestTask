using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SwitchPlanetButton : MonoBehaviour, IButton
{
	[SerializeField]
	private Text _text;

	public void SetAction(UnityAction action)
	{
		GetComponent<Button>().onClick.AddListener(action);
	}

	public void SetText(string text)
	{
		_text.text = text;
	}
}
