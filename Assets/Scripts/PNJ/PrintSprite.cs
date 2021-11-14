using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrintSprite : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Image>().sprite =
            Resources.Load<Sprite>("Sprites/Characters/" + PNJManagement.GetCurrentPNJ());
    }
}
