using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class DeathManager : NetworkBehaviour
{
    static List<PaperBagHealth> PaperBags = new List<PaperBagHealth>();

    public static void AddPaperBag(PaperBagHealth PaperBag)
    {
        PaperBags.Add(PaperBag);
    }
		
	

    public static bool RemovePaperBagAndCheckWinner(PaperBagHealth PaperBag)
    {
        PaperBags.Remove(PaperBag);

        if (PaperBags.Count == 1)
            return true;

        return false;
    }

    public static PaperBagHealth GetWinner()
    {
        if (PaperBags.Count != 1)
            return null;

        return PaperBags[0];
    }
}
