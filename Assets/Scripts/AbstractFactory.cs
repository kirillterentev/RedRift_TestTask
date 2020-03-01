using UnityEngine;

public abstract class AbstractFactory : MonoBehaviour
{
	public virtual T CreateProduct<T>()
	{
		throw new System.NotImplementedException();
	}
}
