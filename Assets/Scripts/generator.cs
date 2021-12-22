using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generator : MonoBehaviour
{
    private void OnMouseUp()
    {
        SoundManager.PlaySound("generator");
    }
}
