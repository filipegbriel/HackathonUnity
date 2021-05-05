using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class UnityEventBoardLimits: UnityEvent<int, int> { }

public class CreateChessBoard : MonoBehaviour
{
    [Range(0, 100)]
    public int totalNumberOfRows;
    [Range(0, 100)]
    public int totalNumberOfColumns;

    public GameObject whitePrefab;
    public GameObject blackPrefab;

    public Transform positionToCreate;

    public UnityEventBoardLimits onChessCreationBoardRowColumn;


    private void Awake()
    {
        CreateBoard();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Button Clicked");
            CreateBoard();
        }
    }

    public void CreateBoard()
    {
        ClearBoard();
     
        for (int row = 0; row < this.totalNumberOfRows; row++)
        {
            bool oddRow = (row % 2 == 1);
            for (int column = 0; column < this.totalNumberOfColumns; column++)
            {
                bool oddColumn = (column % 2 == 1);
                GameObject prefabToInstantiate = blackPrefab;

                if (oddRow != oddColumn)
                {
                    prefabToInstantiate = whitePrefab;
                } 
               

                GameObject blockCopy = Instantiate(prefabToInstantiate, positionToCreate);
                blockCopy.transform.localPosition = new Vector3(row, 0, column);
            }
        }
        onChessCreationBoardRowColumn.Invoke(totalNumberOfRows, totalNumberOfColumns);
        Debug.Log("Chess Board created");
    }

    public void ClearBoard()
    {
        foreach (Transform child in positionToCreate)
        {
            Destroy(child.gameObject);
        }
        Debug.Log("Chess Board cleared");
    }
}
