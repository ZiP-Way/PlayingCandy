using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private GameController gameController;
    [SerializeField] private LayerMask layerMask;

    private Camera camera;

    private Vector3 startPosition;
    private Vector3 posToMove;

    private bool isMoving;
    private bool isFoundedMainPos;

    private void Awake()
    {
        // Initialization
        camera = Camera.main;

        startPosition = transform.position;
        posToMove = startPosition;
    }

    private void FixedUpdate()
    {
        if (transform.position != posToMove && (!isMoving || isFoundedMainPos))
        {
            MoveToPosition();
        }
    }

    private void OnMouseDrag()
    {
        if (!isFoundedMainPos)
        {
            DraggingObject();
        }
    }

    private void OnMouseDown()
    {
        isMoving = true;
    }
    private void OnMouseUp()
    {
        isMoving = false;

        if (!isFoundedMainPos)
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                if (hit.collider.gameObject.name == gameObject.name)
                {
                    posToMove = hit.collider.gameObject.transform.position;
                    gameController.UpdateCountOfSweets();
                    isFoundedMainPos = true;
                }
            }
        }
    }

    private void MoveToPosition()
    {
        transform.position = Vector3.Lerp(transform.position, posToMove, movementSpeed);
    }

    private void DraggingObject()
    {
        Vector3 objPosition = camera.ScreenToWorldPoint(Input.mousePosition);
        transform.position = objPosition;
    }
}
