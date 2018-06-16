using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
	[SerializeField] private float scrollSpeed;
	[SerializeField] private  Material mat;

	private void Update()
	{
		float _offset = Time.time * scrollSpeed;
		mat.SetTextureOffset("_MainTex", new Vector2(0, _offset));
	}
}