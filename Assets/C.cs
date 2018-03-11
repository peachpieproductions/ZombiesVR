using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C : MonoBehaviour {

    public GameObject[] rooms;
    public GameObject startChunk;
    public float worldScale = .4f;
    public GameObject zombiePrefab;

	// Use this for initialization
	void Start () {
        StartCoroutine(Generate());
	}

    IEnumerator Generate() {
        GameObject prevInst = startChunk;
        for (var i = 0; i < 15; i++) {
            var inst = Instantiate(rooms[Random.Range(0,rooms.Length)]);
            if (i == 0) inst.transform.position = Vector3.zero;
            inst.transform.localScale *= worldScale;

            if (prevInst != null) {
                var myDoor = inst.transform.GetChild(0).GetChild(0);
                var prevDoor = prevInst.transform.GetChild(0).GetChild(1);

                myDoor.parent = null;
                inst.transform.parent = myDoor;
                myDoor.transform.position = prevDoor.transform.position;
                myDoor.transform.rotation = prevDoor.transform.rotation;
                myDoor.Rotate(0, 0, 180);
                inst.transform.position += prevDoor.right * -3.5f * worldScale;
                inst.transform.parent = null;
                myDoor.parent = inst.transform.GetChild(0);
                myDoor.SetAsFirstSibling();

                //spawn zombies
                if (inst.transform.GetChild(1).name == "SpawnPoints") {
                    foreach (Transform t in inst.transform.GetChild(1)) {
                        if (Random.value < .2f) {
                            Instantiate(zombiePrefab, t.position, Quaternion.identity);
                        }
                    }
                }
            }
            prevInst = inst;
            yield return new WaitForSeconds(.2f);
        }
    }

}
