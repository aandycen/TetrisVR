using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour {

    public TextMeshProUGUI lvl;
    public TextMeshProUGUI score;

    public GameObject q1;
    public GameObject q2;
    public GameObject q3;
    public GameObject q4;
    public GameObject q5;

    public Sprite I;
    public Sprite O;
    public Sprite T;
    public Sprite S;
    public Sprite Z;
    public Sprite J;
    public Sprite L;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        object[] arr = Tetris.C.tetrominoQueue.ToArray();
		switch((int) arr[0]) {
            case 1:
                q1.GetComponent<Image>().sprite = I;
                break;
            case 2:
                q1.GetComponent<Image>().sprite = J;
                break;
            case 3:
                q1.GetComponent<Image>().sprite = L;
                break;
            case 4:
                q1.GetComponent<Image>().sprite = O;
                break;
            case 5:
                q1.GetComponent<Image>().sprite = S;
                break;
            case 6:
                q1.GetComponent<Image>().sprite = T;
                break;
            case 7:
                q1.GetComponent<Image>().sprite = Z;
                break;
        }
        switch ((int)arr[1]) {
            case 1:
                q2.GetComponent<Image>().sprite = I;
                break;
            case 2:
                q2.GetComponent<Image>().sprite = J;
                break;
            case 3:
                q2.GetComponent<Image>().sprite = L;
                break;
            case 4:
                q2.GetComponent<Image>().sprite = O;
                break;
            case 5:
                q2.GetComponent<Image>().sprite = S;
                break;
            case 6:
                q2.GetComponent<Image>().sprite = T;
                break;
            case 7:
                q2.GetComponent<Image>().sprite = Z;
                break;
        }
        switch ((int)arr[2]) {
            case 1:
                q3.GetComponent<Image>().sprite = I;
                break;
            case 2:
                q3.GetComponent<Image>().sprite = J;
                break;
            case 3:
                q3.GetComponent<Image>().sprite = L;
                break;
            case 4:
                q3.GetComponent<Image>().sprite = O;
                break;
            case 5:
                q3.GetComponent<Image>().sprite = S;
                break;
            case 6:
                q3.GetComponent<Image>().sprite = T;
                break;
            case 7:
                q3.GetComponent<Image>().sprite = Z;
                break;
        }
        switch ((int)arr[3]) {
            case 1:
                q4.GetComponent<Image>().sprite = I;
                break;
            case 2:
                q4.GetComponent<Image>().sprite = J;
                break;
            case 3:
                q4.GetComponent<Image>().sprite = L;
                break;
            case 4:
                q4.GetComponent<Image>().sprite = O;
                break;
            case 5:
                q4.GetComponent<Image>().sprite = S;
                break;
            case 6:
                q4.GetComponent<Image>().sprite = T;
                break;
            case 7:
                q4.GetComponent<Image>().sprite = Z;
                break;
        }
        switch ((int)arr[4]) {
            case 1:
                q5.GetComponent<Image>().sprite = I;
                break;
            case 2:
                q5.GetComponent<Image>().sprite = J;
                break;
            case 3:
                q5.GetComponent<Image>().sprite = L;
                break;
            case 4:
                q5.GetComponent<Image>().sprite = O;
                break;
            case 5:
                q5.GetComponent<Image>().sprite = S;
                break;
            case 6:
                q5.GetComponent<Image>().sprite = T;
                break;
            case 7:
                q5.GetComponent<Image>().sprite = Z;
                break;
        }
        score.SetText(""+Tetris.C.score);
        lvl.SetText(""+Tetris.C.level);
    }
}
