using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rotate : MonoBehaviour
{
    private void OnMouseUp()
    {
        if(SceneManager.GetActiveScene().buildIndex != 4)
        {
            if (!FindObjectOfType<GameManager>().pause)
            {
                transform.Rotate(0, 90, 0);
                SoundManager.PlaySound("rotate");
                FindObjectOfType<GameManager>().pause = true;
            }
        }
        else
        {
            if (!FindObjectOfType<SurvivalManager>().pause)
            {
                transform.Rotate(0, 90, 0);
                SoundManager.PlaySound("rotate");
                FindObjectOfType<SurvivalManager>().pause = true;
            }
        }

    }
}
