using UnityEngine;

public class ButtonsFactory : AbstractFactory
{
	private const float ButtonOffset = 200f;

	[SerializeField]
	private GameObject _butonPrefab;

	private float curPosY = 0;

	public override IButton CreateProduct<IButton>()
	{
		var go = Instantiate(_butonPrefab, transform);
		go.transform.localPosition = Vector3.down * curPosY;
		curPosY += ButtonOffset;
		return go.GetComponent<IButton>();
	}
}
