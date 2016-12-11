using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

    void Start ()
	{
		GetComponent<Rigidbody2D>().gravityScale += Time.timeSinceLevelLoad / 50f;
	}

	// Update is called once per frame
	void Update () {
		if (transform.position.y < -2f)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<ScoreManager>().AddScore();
            Destroy(gameObject);
		}
	}

}
