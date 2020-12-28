using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItens : MonoBehaviour {

    [SerializeField] private GameObject content;
    
    private float x = 17.0f;
    void Start () {
        RectTransform rect = content.GetComponent<RectTransform>();
        if(8.0f < x && x <= 12.0f)
        {
            rect.anchorMin = new Vector2(0,-0.3f);
        }else if(x > 12.0f)
        {
            rect.anchorMin = new Vector2(0, -0.4f * Mathf.Ceil(x/4.0f - 3.0f) + -0.3f);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
