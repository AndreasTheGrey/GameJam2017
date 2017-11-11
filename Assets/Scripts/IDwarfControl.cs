using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDwarfControl {
	void Jump ();
	void Move (float horizontal, float vertical);
	void Attack ();
}
