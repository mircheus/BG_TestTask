using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsView : MonoBehaviour
{
    [SerializeField] private TMP_Text _pointsText;
    
    public void SetPoints(int points)
    {
        _pointsText.text = points.ToString();
    }
}
