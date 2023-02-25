using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class BookSocketsScript : MonoBehaviour
{
    private BooksRiddle m_BooksRiddle;
    XRSocketInteractor m_Socket;

    void Start()
    {
        m_BooksRiddle = BooksRiddle.Instance;

        m_Socket = GetComponent<XRSocketInteractor>();

        //m_Socket.
    }

    public void OnSelectSocket()
    {

        IXRSelectInteractable objName = m_Socket.GetOldestInteractableSelected();

        Debug.Log(objName.transform.name + " in socket of " + transform.name);

        int socketIndex = extractNumber(transform.name);
        int bookNumber = extractNumber(objName.transform.name);

        m_BooksRiddle.AddBookToSocketArray(socketIndex, bookNumber);

    }

    public void OnDeselectSocket()
    {
        int socketIndex = extractNumber(transform.name);
        m_BooksRiddle.ClearSocket(socketIndex);
    }

    private int extractNumber(string i_InputString)
    {
        int number;
        int underscoreIndex = i_InputString.IndexOf('_');

        if (underscoreIndex != -1 && int.TryParse(i_InputString.Substring(underscoreIndex + 1), out number))
        {
            return number;
        }
        else
        {
            // Return -1 to indicate that the input string did not contain an underscore followed by a number
            return -1;
        }
    }

    private int ExtractBookNumber(string i_BookGameObjectName)
    {
        if (!i_BookGameObjectName.StartsWith("Book_"))
        {
            Debug.LogWarning("Failed to extract number from game object name: " + i_BookGameObjectName);
            return -1;

        }

        string numberString = i_BookGameObjectName.Substring(5);
        int number;
        if (int.TryParse(numberString, out number))
        {
            return number;
        }
        else
        {
            Debug.LogWarning("Failed to extract number from game object name: " + i_BookGameObjectName);
            return -1;
        }


    }
}
