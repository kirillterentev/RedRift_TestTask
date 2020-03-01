using UnityEngine;

public class UIController : MonoBehaviour
{
	[SerializeField]
	private GameObject _switchPlanetWindow;

	public void SetActiveSwitchPlanetWindow()
	{
		_switchPlanetWindow.SetActive(!_switchPlanetWindow.activeSelf);
	}
}
