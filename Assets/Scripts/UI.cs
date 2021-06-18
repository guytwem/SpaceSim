using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UI : MonoBehaviour
{
    public TMP_Text asteroidsDestroyedText;
    public int asteroidsDestroyed;
    
    private void Update()
    {
        asteroidsDestroyedText.text = "Asteroids Destroyed: " + asteroidsDestroyed.ToString();
    }
}
