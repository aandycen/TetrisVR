using System.Collections;
using UnityEngine;

public class Tetris : MonoBehaviour {

    [HideInInspector] public static Tetris C;
    [HideInInspector] public bool debugMode;

    public BoardVisualizer visualizer;
    public Game game;

    public int[,] board;
    public int currentPiece;
    public long score;
    public int level;
    public Queue tetrominoQueue = new Queue();

    [HideInInspector] public const int BOARD_WIDTH   = 10;
    [HideInInspector] public const int BOARD_HEIGHT  = 22;
    [HideInInspector] public const int BOARD_VISIBLE = 20;
    [HideInInspector] public enum BLOCK { EMPTY, I, O, T, S, Z, J, L };
    [HideInInspector] public enum STATE { MENU, PLAYING, GAMEOVER };
    public STATE state;

    void Awake() {
        if (C != null)
            GameObject.Destroy(C);
        else
            C = this;
        DontDestroyOnLoad(this);

        Tetris.C.board = new int[Tetris.BOARD_WIDTH, Tetris.BOARD_HEIGHT];

        for (int i = 0; i < 6; i++) {
            Tetris.C.tetrominoQueue.Enqueue((int)(Random.value * 7 + 1));
        }
    }

    void Start () {
	}
	
	void Update () {
	}

    public void debug() {
        //use this method for any debug actions that need to happen
        //int x = (int)(Random.value * 10);
        //int y = (int)(Random.value * 22);
        //int t = (int)(Random.value * 7) + 1;
        //Debug.Log(x + ", " + y + ", " + t);
        //board[x, y] = t;
        game.SpawnTetromino();
    }

    public void log(string s) {
        if (debugMode)
            Debug.Log(s);
    }

    public void clearBoard() {
        visualizer.updateBoard();
    }

    public void updateBoard(Vector2[] points, Vector2 origin) {
        /*int minY = (int)points[0].y;
        int maxY = (int)points[0].y;

        for (int i = 1; i < points.Length; i++) {
            Vector2 p = points[i];
            if (p.y < minY)
                minY = (int)p.y;
            if (p.y > maxY)
                maxY = (int)p.y;
        }

        minY += -1;
        maxY += 2;

        if (minY < BOARD_HEIGHT- BOARD_VISIBLE)
            minY = 2;
        if (maxY > BOARD_HEIGHT)
            maxY = BOARD_HEIGHT;

        log(minY + ", " + maxY);*/
        //visualizer.updateLine(minY, maxY);
        visualizer.updateBoard();
        visualizer.drawPiece(points, origin);
    }

    public void move(int i) {
        game.Move(i);
    }

    public void rotate() {
        game.Rotate();
    }

    public void moveDown() {
        game.Drop();
    }

	public void clap(){
		if (state == STATE.MENU) {
			state = STATE.PLAYING;
			game.SpawnTetromino();
		}
		else
			game.Rotate ();
	}
}
