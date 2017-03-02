using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class GUICrosshair : MonoBehaviour {

    public Texture2D crosshair;
    Rect pos;
    static bool originalOn = true;

	void Start () {
        pos = new Rect((Screen.width - crosshair.width) / 2, (Screen.height - crosshair.height) / 2, crosshair.width, crosshair.height);
    }
	

	void OnGUI () {
        if (originalOn == true && !MyManager.isPause)
        {
            GUI.DrawTexture(pos, crosshair);
        }
    }
}
