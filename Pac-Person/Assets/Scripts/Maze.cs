using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour {
	public Vector2 PacDotOrigin = new Vector2(2, 2);
	public float PacDotStep = 1.0f;
	public int PacDotRows = 29;
	public int PacDotCols = 26;
	public GameObject PacDotPrefab;
	public int PacDotsPlaced;

	// Use this for initialization
	void Start() {
		// Begin in lower left-hand corner
		// Instatantiate (place) PacDot.
		Vector2 oldLocation = PacDotOrigin;

		for (int i = 0; i < PacDotRows; i++) {
			for (int j = 0; j < PacDotCols; j++) {
				float PacDotX = j * PacDotStep;
				float PacDotY = i * PacDotStep;
				var newLocation = PacDotOrigin + new Vector2(PacDotX, PacDotY);
				GameObject LastPacDot;
				if (inMaze(newLocation)) {
					GameObject pd = Instantiate(PacDotPrefab, newLocation, Quaternion.identity);
					pd.name = PacDotPrefab.name + " " + newLocation;
					LastPacDot = pd;
					PacDotsPlaced++;
				}
			}
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
