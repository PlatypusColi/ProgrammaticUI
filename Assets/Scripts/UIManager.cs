using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	public static UIManager instance;
	Canvas base_canvas;
	public float image_size = 50;
	// Use this for initialization
	void Start ()
	{
		if (UIManager.instance != null)
		{
			Debug.Log ("Only one instance of UIManager allowed !");
			this.enabled = false;
			return;
		}

		UIManager.instance = this;

		GameObject canvas = new GameObject ("Canvas");
		base_canvas = canvas.AddComponent<Canvas> ();
		base_canvas.renderMode = RenderMode.ScreenSpaceOverlay;

		canvas.AddComponent<CanvasScaler> ();

		canvas.AddComponent<GraphicRaycaster> ();

		GameObject event_system = new GameObject ("EventSystem");
		event_system.AddComponent<UnityEngine.EventSystems.EventSystem> ();
		event_system.AddComponent<UnityEngine.EventSystems.StandaloneInputModule> ();

		CreateSprite (new Vector3 (0, 0, 0), "Star");
	}

	public GameObject CreateSprite(Vector3 position, string sprite_name)
	{
		GameObject sprite = new GameObject (sprite_name);
		Sprite my_sprite = Resources.Load<Sprite> (sprite_name);

		Image sprite_image = sprite.AddComponent<Image> ();

		sprite_image.sprite = my_sprite;

		sprite.transform.SetParent (base_canvas.transform);

		RectTransform rect_transf = sprite.GetComponent<RectTransform> ();

		rect_transf.SetInsetAndSizeFromParentEdge (RectTransform.Edge.Right,
			position.x, image_size);

		rect_transf.SetInsetAndSizeFromParentEdge (RectTransform.Edge.Bottom,
			position.y, image_size);

		sprite.AddComponent<SpriteBehavior> ();

		return (sprite);
	}
}
