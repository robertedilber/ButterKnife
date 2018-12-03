using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public class ValueListenerText : MonoBehaviour {

    Text _itemtext;
    Text ItemText
    {
        get {
            if (_itemtext == null)
                _itemtext = GetComponent<Text>();
            return _itemtext;
        }
    }
    [SerializeField]
    string monitoredValue;

    private void Awake()
    {
        if (monitoredValue != "")
            EventBroadcaster.AddActionToEvent(monitoredValue, (x) => ItemText.text = x.ToString());
    }

}
