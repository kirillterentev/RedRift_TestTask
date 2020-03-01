using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
	[SerializeField]
	private GameObject _switchPlanetWindow;
	[SerializeField]
	private Text _countBounce;

	public void SetActiveSwitchPlanetWindow()
	{
		_switchPlanetWindow.SetActive(!_switchPlanetWindow.activeSelf);
	}

	public void SetCountBounce(int count)
	{
		_countBounce.text = count.ToString();
	}
}
