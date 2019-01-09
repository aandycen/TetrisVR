using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {
    readonly Vector2[,,] Tetrominos = new Vector2[,,] {
            {
            // Empty-Piece
                { new Vector2(0, 0), new Vector2(0, 0), new Vector2(0, 0), new Vector2(0, 0) },
                { new Vector2(0, 0), new Vector2(0, 0), new Vector2(0, 0), new Vector2(0, 0) },
                { new Vector2(0, 0), new Vector2(0, 0), new Vector2(0, 0), new Vector2(0, 0) },
                { new Vector2(0, 0), new Vector2(0, 0), new Vector2(0, 0), new Vector2(0, 0) }
            },
			// I-Piece
			{
                { new Vector2(0, 1), new Vector2(1, 1), new Vector2(2, 1), new Vector2(3, 1) },
                { new Vector2(1, 0), new Vector2(1, 1), new Vector2(1, 2), new Vector2(1, 3) },
                { new Vector2(0, 1), new Vector2(1, 1), new Vector2(2, 1), new Vector2(3, 1) },
                { new Vector2(1, 0), new Vector2(1, 1), new Vector2(1, 2), new Vector2(1, 3) }
            },
			
			// J-Piece
			{
                { new Vector2(0, 1), new Vector2(1, 1), new Vector2(2, 1), new Vector2(2, 0) },
                { new Vector2(1, 0), new Vector2(1, 1), new Vector2(1, 2), new Vector2(2, 2) },
                { new Vector2(0, 1), new Vector2(1, 1), new Vector2(2, 1), new Vector2(0, 2) },
                { new Vector2(1, 0), new Vector2(1, 1), new Vector2(1, 2), new Vector2(0, 0) }
            },
			
			// L-Piece
			{
                { new Vector2(0, 1), new Vector2(1, 1), new Vector2(2, 1), new Vector2(2, 2) },
                { new Vector2(1, 0), new Vector2(1, 1), new Vector2(1, 2), new Vector2(0, 2) },
                { new Vector2(0, 1), new Vector2(1, 1), new Vector2(2, 1), new Vector2(0, 0) },
                { new Vector2(1, 0), new Vector2(1, 1), new Vector2(1, 2), new Vector2(2, 0) }
            },
			
			// O-Piece
			{
                { new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 0), new Vector2(1, 1) },
                { new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 0), new Vector2(1, 1) },
                { new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 0), new Vector2(1, 1) },
                { new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 0), new Vector2(1, 1) }
            },
			
			// S-Piece
			{
                { new Vector2(1, 0), new Vector2(2, 0), new Vector2(0, 1), new Vector2(1, 1) },
                { new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1), new Vector2(1, 2) },
                { new Vector2(1, 0), new Vector2(2, 0), new Vector2(0, 1), new Vector2(1, 1) },
                { new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1), new Vector2(1, 2) }
            },
			
			// T-Piece
			{
                { new Vector2(1, 0), new Vector2(0, 1), new Vector2(1, 1), new Vector2(2, 1) },
                { new Vector2(1, 0), new Vector2(0, 1), new Vector2(1, 1), new Vector2(1, 2) },
                { new Vector2(0, 1), new Vector2(1, 1), new Vector2(2, 1), new Vector2(1, 2) },
                { new Vector2(1, 0), new Vector2(1, 1), new Vector2(2, 1), new Vector2(1, 2) }
            },
			
			// Z-Piece
			{
                { new Vector2(0, 0), new Vector2(1, 0), new Vector2(1, 1), new Vector2(2, 1) },
                { new Vector2(1, 0), new Vector2(0, 1), new Vector2(1, 1), new Vector2(0, 2) },
                { new Vector2(0, 0), new Vector2(1, 0), new Vector2(1, 1), new Vector2(2, 1) },
                { new Vector2(1, 0), new Vector2(0, 1), new Vector2(1, 1), new Vector2(0, 2) }
            }
    };

    Vector2 TetrominoOrigin;
    int CurrentPiece;
    int Rotation;

    int time = 40; // Decrease per level

    public void SpawnTetromino() {
        TetrominoOrigin = new Vector2(4, 0);
        Rotation = 0;
        CurrentPiece = (int)Tetris.C.tetrominoQueue.Dequeue();
        Tetris.C.tetrominoQueue.Enqueue((int)(Random.value * 7 + 1));
        Tetris.C.updateBoard(currentPieceAsArray(), TetrominoOrigin);
        Tetris.C.currentPiece = CurrentPiece;
    }

    public bool CollidesAt(int x, int y, int rotation) {
        for (int i = 0; i < 4; i++) {
            Vector2 v = Tetrominos[CurrentPiece, rotation, i];
            int boardX = (int)(v.x + x);
            int boardY = (int)(v.y + y);
            if (boardY >= Tetris.BOARD_HEIGHT || boardX < 0 || boardX >= Tetris.BOARD_WIDTH) {
                return true;
            }
            if (Tetris.C.board[boardX, boardY] != 0) {
                if (boardY == Tetris.BOARD_HEIGHT - Tetris.BOARD_VISIBLE) // COLLIDED AT THE TOP OF VISIBLE LINE
                {
                    Tetris.C.state = Tetris.STATE.GAMEOVER; // GAME OVER
                }
                return true;
            }
        }
        return false;
    }

    public void Rotate() {
        int RotateNew = (Rotation + 1) % 4;
        if (!CollidesAt((int)TetrominoOrigin.x, (int)TetrominoOrigin.y, RotateNew)) {
            Rotation = RotateNew;
            Tetris.C.updateBoard(currentPieceAsArray(), TetrominoOrigin);
        }
    }

    public void Move(int i) {
        if (!CollidesAt((int)TetrominoOrigin.x + i, (int)TetrominoOrigin.y, Rotation)) {
            TetrominoOrigin.x += i;
            Tetris.C.updateBoard(currentPieceAsArray(), TetrominoOrigin);
        }
    }

    Vector2[] currentPieceAsArray() {
        Vector2[] points = new Vector2[] { Tetrominos[CurrentPiece, Rotation, 0],
                    Tetrominos[CurrentPiece, Rotation, 1],
                    Tetrominos[CurrentPiece, Rotation, 2],
                    Tetrominos[CurrentPiece, Rotation, 3]};
        return points;
    }

    public void Drop() {
        if (Tetris.C.state == Tetris.STATE.PLAYING) {
            if (!CollidesAt((int)TetrominoOrigin.x, (int)TetrominoOrigin.y + 1, Rotation)) {
                TetrominoOrigin.y += 1;
                Tetris.C.updateBoard(currentPieceAsArray(), TetrominoOrigin);
            } else {
                FixTetrominoToGrid();
            }
        }
    }

    public void FixTetrominoToGrid() {
        for (int i = 0; i < 4; i++) {
            Vector2 v = Tetrominos[CurrentPiece, Rotation, i];
            Tetris.C.board[(int)(TetrominoOrigin.x + v.x), (int)(TetrominoOrigin.y + v.y)] = CurrentPiece;
            // Tetris.C.updateBoard(currentPieceAsArray(), TetrominoOrigin); I think
        }
        clearRows();
        SpawnTetromino();
    }

    public void deleteRow(int row) {
        for (int j = row; j > 0; j--) {
            for (int i = 0; i < Tetris.BOARD_WIDTH; i++) {
                Tetris.C.board[i, j+1] = Tetris.C.board[i, j];
            }
        }
    }

    public void clearRows() {
        bool emptySpace;
        int clearCount = 0;

        for (int j = Tetris.BOARD_HEIGHT - 1; j > 0; j--) {
            emptySpace = false;
            for (int i = 0; i < Tetris.BOARD_WIDTH; i++) {
                if (Tetris.C.board[i, j] == 0) {
                    emptySpace = true;
                    break;
                }
            }
            if (!emptySpace) {
                Debug.Log(j);
                deleteRow(j-1);
                j += 1;
                clearCount += 1;
            }
        }

        switch (clearCount) {
            case 1:
                Tetris.C.score += 100;
                break;
            case 2:
                Tetris.C.score += 300;
                break;
            case 3:
                Tetris.C.score += 500;
                break;
            case 4:
                Tetris.C.score += 800;
                break;
        }
        if (Tetris.C.score >= (Tetris.C.level * 600)) // points needed to advance level increases by 800 every level
        {
            Tetris.C.level += 1;
        }
        Tetris.C.clearBoard();
    }



    // Use this for initialization
    void Awake() {
        //Tetris.C.board = new int[Tetris.BOARD_WIDTH, Tetris.BOARD_HEIGHT];
        //Tetris.C.Level = 1;
    }

    void Start() {
        //SpawnTetromino();
    }

    // Update is called once per frame
    void Update() {
        if (Tetris.C.state == Tetris.STATE.PLAYING) {
            if (Time.frameCount % (time - ((Tetris.C.level - 1) * 10)) == 0) {
                Drop();
            }
        }
    }
}
