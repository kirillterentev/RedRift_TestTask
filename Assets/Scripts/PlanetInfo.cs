using UnityEngine;

[CreateAssetMenu(menuName = "PlanetInfo", fileName = "new PlanetInfo")]
public class PlanetInfo : ScriptableObject
{
	public string Name;
	public Vector2 Gravity;
	public Color BackgroundColor;
}
