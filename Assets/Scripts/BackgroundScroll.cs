using UnityEngine;
using System.Collections;

public class BackgroundScroll : MonoBehaviour {

	public float speed;
	public float x;

	// Update is called once per frame
	void Update () {
		x = Mathf.Repeat(Time.time * speed, 1);
		renderer.sharedMaterial.SetTextureOffset("_MainTex", new Vector2(x, 0));
	}
}
