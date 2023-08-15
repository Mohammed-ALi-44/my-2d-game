using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoseCollider : MonoBehaviour {
    [SerializeField] int index;
	// Use this for initialization
	void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene(index);
    }
}
