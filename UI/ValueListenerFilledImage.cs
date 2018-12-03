using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueListenerFilledImage : MonoBehaviour {

    Image _image;
    Image Image
    {
        get {
            if(_image == null)
                _image = GetComponent<Image>();
            return _image;
        }
    }
    [SerializeField]
    string monitoredValue;

    private void Awake()
    {
        if (monitoredValue != "")
            EventBroadcaster.AddActionToEvent(monitoredValue, (x) => Image.fillAmount = (float)x);
    }
}
