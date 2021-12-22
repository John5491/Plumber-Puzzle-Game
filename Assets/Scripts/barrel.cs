using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrel : MonoBehaviour
{
    private void OnMouseUp()
    {
        SoundManager.PlaySound("barrel");
    }
}
