using System;
using UnityEngine;

public class GridAlign : MonoBehaviour
{
    [SerializeField] private RectTransform board;
    [SerializeField] private Transform gridRect;

    private float normalGridVertical = 317.3f;
    private float normalGridHorizontal = 323.1f;
    
    private void Start()
    {
        var newGridVertical = board.rect.height / 12;
        if (Math.Abs(Mathf.Floor(newGridVertical) - normalGridVertical) > 1 && Math.Abs(Mathf.Ceil(newGridVertical) - normalGridVertical) > 1)
        {
            var perc = newGridVertical / normalGridVertical;
            gridRect.localScale = new Vector3(gridRect.localScale.x, gridRect.localScale.y * perc, gridRect.localScale.z);
        }
        
        var newGridHorizontal = board.rect.width / 8;
        if (Math.Abs(Mathf.Floor(newGridHorizontal) - normalGridHorizontal) > 1 && Math.Abs(Mathf.Ceil(newGridHorizontal) - normalGridHorizontal) > 1)
        {
            var perc = newGridHorizontal / normalGridHorizontal;
            gridRect.localScale = new Vector3(gridRect.localScale.x * perc, gridRect.localScale.y, gridRect.localScale.z);
        }
    }
}