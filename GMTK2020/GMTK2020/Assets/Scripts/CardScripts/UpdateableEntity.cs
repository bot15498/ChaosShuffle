using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface UpdateableEntity
{
	void ReceiveUpdate(Card activeCard);
}
