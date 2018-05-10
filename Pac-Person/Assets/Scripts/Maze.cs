using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour {
	public Texture2D mazeImage;
	public int PixelsPerUnit = 8;		// Image pixels per Unity unit.
	public Vector2 MazeScanStart = Vector2.zero;
	public int CollidersPlaced;

	public Vector2 PacDotOrigin = new Vector2(2, 2);
	public float PacDotStep = 1.0f;
	public int PacDotRows = 29;
	public int PacDotCols = 26;
	public GameObject PacDotPrefab;
	public int PacDotsPlaced;

	// Use this for initialization
	void Start() {
		// Origin is the lower left-hand corner
		placeMazeColliders();
		instantiatePacDots();
	}

	private void placeMazeColliders() {
		// Scan the maze sprite placing Colliders on lines.
		int mazePixelWidth = mazeImage.width;
		int mazePixelHeight = mazeImage.height;

		Color32[] pixels = mazeImage.GetPixels32();
		Debug.Log(pixels.Length);
		Debug.Log(pixels[0]);
		Color32 pixel00 = pixels[0];
		for (int h = (int) (MazeScanStart.y * PixelsPerUnit); h < mazePixelHeight; h++) {
			for (int w = (int) (MazeScanStart.x * PixelsPerUnit); w < mazePixelWidth; w++) {
				int index = h * (mazePixelWidth) + w;
				if (!pixels[index].Equals(pixel00)) {
					int xLeft = w;
					while (pixels[++w].Equals(pixel00))
						;
					int colliderWidth = (w - xLeft) / PixelsPerUnit;
					int colliderOffsetX = (w - colliderWidth / 2) / PixelsPerUnit;
//					string msg = "pixels[" + w + ", " + h + "] (" + index + ") = " + pixels[index];
//					Debug.Log(msg);
					addCollider2D(colliderOffsetX, h / PixelsPerUnit, colliderWidth, 1f);
					CollidersPlaced++;
					return;
				}
			}
		}
	}

	private BoxCollider2D addCollider2D(float x, float y, float w, float h) {
		BoxCollider2D bc = gameObject.AddComponent<BoxCollider2D>() as BoxCollider2D;
		bc.offset = new Vector2(x, y);
		bc.size = new Vector2(w, h);

		return bc;
	}

	private void instantiatePacDots() {
		for (int i = 0; i < PacDotRows; i++) {
			for (int j = 0; j < PacDotCols; j++) {
				float PacDotX = j * PacDotStep;
				float PacDotY = i * PacDotStep;
				instantiatePacDot(PacDotX, PacDotY);
			}
		}
	}

	private void instantiatePacDot(float x, float y) {
		var newLocation = PacDotOrigin + new Vector2(x, y);
		if (inMaze(newLocation)) {
			GameObject pd = Instantiate(PacDotPrefab);
			pd.transform.parent = transform;
			pd.transform.position = newLocation;
			pd.name = PacDotPrefab.name + " " + newLocation;
			PacDotsPlaced++;
		}
	}

	private Collider2D[] mazeColliders;

	bool inMaze(Vector2 loc) {
		mazeColliders = GetComponents<Collider2D>();
		foreach (var c in mazeColliders) {
			var upperLeftX = c.offset.x - c.bounds.size.x/2;
			var upperLeftY = c.offset.y + c.bounds.size.y/2;
			var lowerRightX = c.offset.x + c.bounds.size.x/2;
			var lowerRightY = c.offset.y - c.bounds.size.y/2;
			if ((loc.x >= upperLeftX && loc.x <= lowerRightX) &&
			    (loc.y <= upperLeftY && loc.y >= lowerRightY)) {
				return false;
			}
		}
		return true;
	}

	// Update is called once per frame
	void Update() {

	}
}
