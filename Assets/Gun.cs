using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public Transform gunTip;
    public Light muzzleFlash;

    private void Update() {
        if (GvrControllerInput.ClickButtonDown) {
            AudioManager.am.PlaySound(0);
            StartCoroutine(MuzzleFlash());
            RaycastHit hit;
            Ray ray = new Ray(gunTip.position,gunTip.forward);
            if (Physics.Raycast(ray, out hit, 100.0f)) {
                BaseHandler bh = hit.transform.GetComponent<BaseHandler>();
                if (bh != null) bh.ImpactHandler(hit.point, ray.direction.normalized, hit.normal);
            }
        }
    }

    IEnumerator MuzzleFlash() {
        muzzleFlash.enabled = true;
        yield return new WaitForSeconds(.1f);
        muzzleFlash.enabled = false;
    }

}
