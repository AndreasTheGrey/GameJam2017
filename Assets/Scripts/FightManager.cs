using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightManager : MonoBehaviour {

    public Transform[] SpawnPoints;
    public GameObject DwarfPrefab;
    private List<GameObject> dwarves = new List<GameObject> ();
    private bool fighting;

    public void startNewFight(int players) {
        if (!fighting) {
            fighting = true;
            foreach (GameObject dwarf in dwarves) {
                Destroy(dwarf);
            }
            dwarves.Clear ();
            Debug.Log ("Start new fight with " + players + " players!");
            int playersSpawned = 0;
            for (int i = 0; i < SpawnPoints.Length; i++) {
                if (playersSpawned == players) {
                    break;
                }
                GameObject dwarf = (GameObject)Instantiate (DwarfPrefab);
                dwarf.GetComponent<PlayerDwarfControl> ().PlayerNum = i + 1;
                dwarf.transform.position = SpawnPoints [i].transform.position;
                dwarves.Add (dwarf);
                playersSpawned += 1;
            }
        }
    }

	void Start () {
		
	}
	
	void Update () {
        if (fighting) {
            int dwarvesAlive = 0;
            GameObject winningDwarf = null;
            foreach (GameObject dwarf in dwarves) {
                if (!dwarf.GetComponent<DwarfHealth> ().dead) {
                    winningDwarf = dwarf;
                    dwarvesAlive += 1;
                }
            }
            if (dwarvesAlive <= 1) {
                fighting = false;
                GameManager.Instance.FightEnd (winningDwarf != null ? winningDwarf.GetComponent<Dwarf>().dwarfName : null);
            }
        }
	}
}
