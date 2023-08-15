using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMe : MonoBehaviour {

	public float lifeTime = 5f;
	void Awake()
    {
        Destroy(gameObject, lifeTime);
    }

}
