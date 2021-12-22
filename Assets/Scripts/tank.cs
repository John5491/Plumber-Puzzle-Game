using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tank : MonoBehaviour
{
    private void OnMouseUp()
    {
        SoundManager.PlaySound("tank");
    }
}
