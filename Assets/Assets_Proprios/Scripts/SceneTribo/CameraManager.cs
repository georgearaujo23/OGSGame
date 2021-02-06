
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    [SerializeField] private GameObject Limite1, Limite2;
    private Touch toque;
    private Vector2 positionInit, positionEnd;
    [SerializeField]  private float aspect = 1.66f;
    [SerializeField] private float forcaToke = 15;
    public bool estaAtivaMovimentacao = true;
    [SerializeField] private AudioClip ButtonClick;
    // Use this for initialization
    void Start () {
        transform.position = new Vector3(0, 0, 0);
        //Camera.main.projectionMatrix = Matrix4x4.Ortho(-Camera.main.orthographicSize * aspect, Camera.main.orthographicSize * aspect, -Camera.main.orthographicSize, Camera.main.orthographicSize, Camera.main.nearClipPlane, Camera.main.farClipPlane);
	}

    private void FixedUpdate()
    {
        if (Input.touchCount > 0 && estaAtivaMovimentacao)
        {
            toque = Input.GetTouch(0);
            if (Input.GetTouch(0).phase == TouchPhase.Moved )
            {
                float z = transform.localPosition.z - forcaToke * ((Mathf.Cos(45) * Input.GetTouch(0).deltaPosition.y) / Screen.height - (Mathf.Sin(45) * Input.GetTouch(0).deltaPosition.x) / Screen.width);
                float x = transform.localPosition.x - forcaToke * ((Mathf.Cos(45) * Input.GetTouch(0).deltaPosition.x) / Screen.width + (Mathf.Sin(45) * Input.GetTouch(0).deltaPosition.y) / Screen.height);
                transform.localPosition = new Vector3(Mathf.Clamp(x, Limite1.transform.position.x, Limite2.transform.position.x), transform.position.y, Mathf.Clamp(z, Limite1.transform.position.z, Limite2.transform.position.z));
            }

        }

    }

}
