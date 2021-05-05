using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    public List<Vector2> directions;

    private int maxNumberOfRows = 0;
    private int maxNumberOfColumns = 0;

    // Update is called once per frame
    void Update()
    {
        // Left key
        if (Input.GetKeyDown(KeyCode.A))
        {
            directions.Add(new Vector2(-1, 0));
        }
        // Down key
        else if (Input.GetKeyDown(KeyCode.S))
        {
            directions.Add(new Vector2(0, -1));
        }
        // Right key
        else if (Input.GetKeyDown(KeyCode.D))
        {
            directions.Add(new Vector2(1, 0));
        }
        // Up key
        else if (Input.GetKeyDown(KeyCode.W))
        {
            directions.Add(new Vector2(0, 1));
        }

        // Move
        if (Input.GetKeyDown(KeyCode.R))
        {
            MovePlayerDirectionList(directions);
        }
    }

    public void InitializePlayer(int totalNumberOfRows, int totalNumberOfColumns)
    {
        transform.localPosition = new Vector3((int) totalNumberOfRows / 2, transform.localPosition.y, (int) totalNumberOfColumns / 2);
        maxNumberOfRows = totalNumberOfRows;
        maxNumberOfColumns = totalNumberOfColumns;
    }

    public void MovePlayerDirectionList(List<Vector2> directions)
    {
        StartCoroutine(MovePlayer(directions));
    }

    private IEnumerator MovePlayer(List<Vector2> directions)
    {
        foreach (Vector2 direction in directions)
        {
            Vector3 newPos = transform.localPosition + new Vector3(direction.x, 0, direction.y);
            if (IsPlayerInBoundaries(newPos))
            {
                transform.localPosition = newPos;
            }
            yield return new WaitForSeconds(0.5f);
        }

        directions.Clear();
        yield return null;
    }

    public bool IsPlayerInBoundaries(Vector3 pos)
    {
        return (pos.x >= 0 && pos.z >= 0 && pos.x < maxNumberOfRows && pos.z < maxNumberOfColumns);
    }
}
