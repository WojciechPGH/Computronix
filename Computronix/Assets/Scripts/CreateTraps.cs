using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTraps : MonoBehaviour
{
    public Grid floorGrid;
    public GameObject spikeTrap;

    void Start()
    {
        CreateSpikeTrap(10, 0);
        CreateSpikeTrap(10, 1);
        CreateSequencedTraps(15, 6);
        CreateAllAtOnceTraps(35, 3);
        CreateAllAtOnceTraps(41, 3);
        CreateAllAtOnceTraps(47, 3);
        CreateAllAtOnceTraps(53, 3);
        CreateSequencedTraps(56, 5);
        CreateAllAtOnceTraps(62, 3);

        CreateSequencedTraps(66, 4);
    }


    private GameObject CreateSpikeTrap(int xPos, int layer, bool automatic = true)
    {
        GameObject temp;
        temp = Instantiate(spikeTrap, floorGrid.gameObject.transform, false);
        temp.transform.localPosition = new Vector3(0.09f + xPos * 0.18f, 0.09f + layer * 0.18f);
        temp.GetComponent<TrapController>().automaticTrigger = automatic;

        return temp;
    }

    private IEnumerator SequencedTrapsCoroutine(int xStart, int numOfTraps)
    {
        TrapController[] traps = new TrapController[numOfTraps * 2];
        for (int i = 0; i < numOfTraps * 2; i += 2)
        {
            traps[i] = CreateSpikeTrap(xStart + i/2, 0, false).GetComponent<TrapController>();
            traps[i + 1] = CreateSpikeTrap(xStart + i/2, 1, false).GetComponent<TrapController>();
            traps[i].timeToFire = traps[i + 1].timeToFire = 1;
        }

        while (true)
        {
            for (int i = 0; i < numOfTraps * 2; i += 2)
            {
                traps[i].trigger = traps[i + 1].trigger = true;
                yield return new WaitForSeconds(1f);
            }
            yield return null;
        }
    }

    private IEnumerator AllAtOnceTrapsCoroutine(int xStart, int numOfTraps)
    {
        TrapController[] traps = new TrapController[numOfTraps * 2];
        for (int i = 0; i < numOfTraps * 2; i += 2)
        {
            traps[i] = CreateSpikeTrap(xStart + i / 2, 0, false).GetComponent<TrapController>();
            traps[i + 1] = CreateSpikeTrap(xStart + i / 2, 1, false).GetComponent<TrapController>();
            traps[i].timeToFire = traps[i + 1].timeToFire = 2;
        }

        while (true)
        {
            for (int i = 0; i < numOfTraps * 2; i += 2)
            {
                traps[i].trigger = traps[i + 1].trigger = true;
            }
            yield return new WaitForSeconds(4f);
        }
    }

    private void CreateSequencedTraps(int xStart, int numOfTraps)
    {
        StartCoroutine(SequencedTrapsCoroutine(xStart, numOfTraps));
    }

    private void CreateAllAtOnceTraps(int xStart, int numOfTraps)
    {
        StartCoroutine(AllAtOnceTrapsCoroutine(xStart, numOfTraps));
    }
}
