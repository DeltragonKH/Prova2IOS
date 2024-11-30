using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TouchController : MonoBehaviour
{
    public GameObject Player;
    public float accelerometerSensitivity = 1.0f;
    public TMP_Text Label;

    // Start is called before the first frame update
    void Start()
    {
        Label.text = PlayerPrefs.GetString("Label");
     if (Player == null)
        {
            Player = this.gameObject;
        }   
    }


    // Update is called once per frame
    void Update()
    {
#if PLATFORM_ANDROID
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
            Player.transform.position = touchPosition;
            Handheld.Vibrate();

        }
        Vector3 acceleration = Input.acceleration;
        Vector3 movement = new Vector3(acceleration.x, 0, 10) * accelerometerSensitivity;
        Player.transform.Translate(movement * Time.deltaTime);
#endif
#if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
            Player.transform.position = touchPosition;

        }
#endif
    }
}
