using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TenantNameCanvas : MonoBehaviour {

    private void OnEnable()
    {
        EventManager.StartListening("OnHideTenantName", Hide);
    }

    public void Hide ()
    {
        this.gameObject.SetActive(false);
    }
}
