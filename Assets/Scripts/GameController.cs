using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private ISelectable selectedEntity;

    private void Update()
    {
        // Left click to select an entity (Unit or Building)
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                GameEntity entity = hit.transform.GetComponent<GameEntity>();
                if (entity != null && !entity.IsDead)
                {
                    // Deselect the previously selected entity
                    if (selectedEntity != null)
                    {
                        selectedEntity.Deselect();
                    }

                    // Select the new entity
                    selectedEntity = entity as ISelectable;
                    if (selectedEntity != null)
                    {
                        selectedEntity.Select();
                    }
                }
                else if (selectedEntity != null)
                {
                    // Deselect the selected entity if we clicked on empty space
                    selectedEntity.Deselect();
                    selectedEntity = null;
                }
            }
        }

        // Right click to set a target or move to a position
        if (Input.GetMouseButtonDown(1) && selectedEntity is Unit selectedUnit)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                GameEntity entity = hit.transform.GetComponent<GameEntity>();

                if (entity != null && !entity.IsDead)
                {
                    // Set the target
                    selectedUnit.SetTarget(entity);
                }
                else
                {
                    // Deselect the target (stop attacking)
                    selectedUnit.SetTarget(null);
                    
                    // Move to position
                    selectedUnit.Move(hit.point);
                }
            }
        }
    }
}
