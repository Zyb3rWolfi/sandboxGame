using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class veinManager : MonoBehaviour
{
    public int oreAmount;
    private GameObject _miner;

    public void oreMined()
    {
        oreAmount -= 1;
    }
}
