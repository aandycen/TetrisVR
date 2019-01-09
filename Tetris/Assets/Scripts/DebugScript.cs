using UnityEngine;

public class DebugScript : MonoBehaviour {

	void Start () {
        Tetris.C.debugMode = true;
	}

    void Update() {
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            Tetris.C.moveDown();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            Tetris.C.move(-1);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            Tetris.C.move(+1);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            Tetris.C.rotate();
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            Tetris.C.state = Tetris.STATE.PLAYING;
            Tetris.C.debug();
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            Tetris.C.moveDown();
        }
    }
}
