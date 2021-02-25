using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapPsReturnToPool : MonoBehaviour
{
	void OnEnable()
	{
		StartCoroutine("CheckIfAlive");
	}

	IEnumerator CheckIfAlive()
	{
		ParticleSystem ps = this.GetComponent<ParticleSystem>();

		while (true && ps != null)
		{
			yield return new WaitForSeconds(0.2f);
			if (!ps.IsAlive(true))
			{
					this.gameObject.SetActive(false);
					TapParticleSystem.Instance.ReturnToPool(this.gameObject);
			}
		}
	}
}
