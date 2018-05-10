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
		Color32[,] pixels = getMazePixels();
		int MazePixelsX = mazeImage.width;
		int MazePixelsY = mazeImage.height;
		int ppu = PixelsPerUnit;

		Color32 pixel00 = pixels[0, 0];
		for (int y = (int) (MazeScanStart.y * ppu); y < MazePixelsY; y += ppu) {
			for (int x = (int) (MazeScanStart.x * ppu); x < MazePixelsX; x++) {
				if (!pixels[x, y].Equals(pixel00)) {
					int xLeft = x;
					while (pixels[++x, y].Equals(pixel00))
						;
					float colliderWidth = (x + 1) - xLeft;
					float colliderOffsetX = (x + 1) - (colliderWidth / 2.0f);
					addCollider2D(colliderOffsetX / ppu, (float) y / ppu, colliderWidth / ppu, 1.0f);
					CollidersPlaced++;
				}
			}
		}
	}

	/**
	 * Get a 2D array of pixels representing the maze image.
	 */
	Color32[,] getMazePixels() {
		var pixels = new Color32[mazeImage.width, mazeImage.height];
		var tmp = mazeImage.GetPixels32();
		for (int y = 0; y < mazeImage.height; y++) {
			for (int x = 0; x < mazeImage.width; x++) {
				pixels[x, y] = tmp[y * mazeImage.width + x];
			}
		}

		return pixels;
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
