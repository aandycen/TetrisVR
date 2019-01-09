using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardVisualizer : MonoBehaviour {

    public int[,] board;
    public GameObject cell;

    //I, O, T, S, Z, J, and L.
    const int BLOCK_SIZE = 20;
    Dictionary<int, Color> colorDict; 

    void Awake() {
        colorDict = new Dictionary<int, Color>();
        colorDict.Add((int)Tetris.BLOCK.EMPTY, Color.black);
        colorDict.Add((int)Tetris.BLOCK.I, Color.red);
        colorDict.Add((int)Tetris.BLOCK.O, Color.yellow);
        colorDict.Add((int)Tetris.BLOCK.T, Color.green);
        colorDict.Add((int)Tetris.BLOCK.S, Color.blue);
        colorDict.Add((int)Tetris.BLOCK.Z, Color.cyan);
        colorDict.Add((int)Tetris.BLOCK.J, Color.magenta);
        colorDict.Add((int)Tetris.BLOCK.L, Color.gray);
    }
    
    void Start () {
        board = Tetris.C.board;
        for (int r = 0; r < Tetris.BOARD_VISIBLE; r++) {
            for (int c = 0; c < Tetris.BOARD_WIDTH; c++) {
                GameObject currCell = Instantiate(cell, transform);
                currCell.transform.position = new Vector3(0.5f * c - transform.localScale.x, 0.5f * -r + transform.localScale.y / 1.75f);
                currCell.GetComponent<SpriteRenderer>().color = colorDict[(int)Tetris.BLOCK.EMPTY];
                currCell.name = r + ":" + c;
                Tetris.C.log(r + ":" + c);
            }
        }
    }
    
    void Update() {

    }

    public void updateLine(int startY, int endY) {
        //Debug.Log(startY + ":" + endY);
        for (int r = startY; r < endY; r++) {
            for (int c = 0; c < Tetris.BOARD_WIDTH; c++) {
                //Debug.Log(r + ":" + c);
                if (r >= 2) {
                    SpriteRenderer currCell = transform.Find((r-2) + ":" + c).gameObject.GetComponent<SpriteRenderer>();
                    if (colorDict[board[c, r]] != currCell.color)
                        currCell.color = colorDict[board[c, r]];
                }
            }
        }


    }

    public void drawPiece(Vector2[] points, Vector2 origin) {
        for (int i = 0; i < points.Length; i++) {
            int c = (int)points[i].x + (int)origin.x;
            int r = (int)points[i].y + (int)origin.y;

            //Debug.Log("piece " + i + ": " + c + ", " + r);
            if (r > 1) {
                SpriteRenderer currCell = transform.Find((r-2) + ":" + c).gameObject.GetComponent<SpriteRenderer>();
                // if (colorDict[board[c, r]] != currCell.color)
                //Debug.Log(Tetris.C.currentPiece);
                    currCell.color = colorDict[Tetris.C.currentPiece];
            }
        }
    }

    public void updateBoard() {
        updateLine(2, Tetris.BOARD_HEIGHT);
    }
}
