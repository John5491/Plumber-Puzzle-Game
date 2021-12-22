using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class truck : MonoBehaviour
{
    private void OnMouseUp()
    {
        SoundManager.PlaySound("truck");
    }
}
