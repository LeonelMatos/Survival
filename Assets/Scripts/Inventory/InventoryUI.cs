using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [Required]
    public GameObject gridcell;

    private GameObject inventoryGrid;

    [Title("Grid Settings")]
    public int gridRow;
    public int gridCol;

    private void Start () {
        inventoryGrid = gameObject;

        buildGrid();
    }

    private void buildGrid() {

        GameObject cell;

        for (int i = 0; i < gridRow; i++)
        {
            for (int j = 0;j < gridCol; j++)
            {
                cell = Instantiate(gridcell, Camera.main.WorldToScreenPoint(new Vector3(2 * i, 2 * j)), Quaternion.identity);
                cell.transform.parent = gameObject.transform;
                Debug.Log("Created cell i=" + i + " j=" + j);
            }

        }
    }
}
