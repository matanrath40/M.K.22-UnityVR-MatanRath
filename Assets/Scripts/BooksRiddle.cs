using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BooksRiddle : MonoBehaviour
{
    public static BooksRiddle Instance;

    private TVStand m_TVStand;

    private int[] booksAtSockets = new int[5] { -1, -1, -1, -1, -1 };


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        m_TVStand = GameObject.Find("TVStand").GetComponent<TVStand>();
    }

    public void AddBookToSocketArray(int i_SocketNumber, int i_BookNumber)
    {

        booksAtSockets[i_SocketNumber] = i_BookNumber;
        if (isAllSocketsMatchedCorrectly())
        {
            onBookRiddleSolved();
        }
    }

    private void onBookRiddleSolved()
    {
        Debug.Log("Books Riddle Solved!");
        m_TVStand.OpenDoor();
    }


    public void ClearSocket(int i_SocketNumber)
    {
        booksAtSockets[i_SocketNumber] = -1;
    }

    private bool isAllSocketsMatchedCorrectly()
    {
        bool returnValue = false;

        if (booksAtSockets[0] == 16 && booksAtSockets[1] == 4 && booksAtSockets[2] == 13 &&
            booksAtSockets[3] == 22 && booksAtSockets[4] == 10)
        {
            returnValue = true;
        }

        return returnValue;
    }



}
