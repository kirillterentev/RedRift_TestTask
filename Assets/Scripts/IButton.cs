using UnityEngine.Events;

public interface IButton
{
	void SetAction(UnityAction action);
	void SetText(string text);
}
