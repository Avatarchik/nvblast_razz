﻿using UnityEngine;
using System.Collections.Generic;

public class GameObjectBlaster : MonoBehaviour
{
    private CubeFamily _objectToBlastFamily;
    private CubeAsset _thisCubeAsset;

    private GameObject[] _chunks0;

    void Start()
    {
        /*if (!(_objectToBlastFamily = this.GetComponent<CubeFamily>()))
        {
            Debug.Log(this.gameObject.name +  " has no CubeFamily.");
            return;
        }*/

        //Init();

        _chunks0 = GetChildrenByDepth(this.gameObject, 0);
        Debug.Log(_chunks0.Length);
    }

    private GameObject[] GetChildrenByDepth(GameObject parentObj, int depth)
    {
        Chunks[] chunks;
        chunks = GetComponentsInChildren<Chunks>(true);
        List<GameObject> tempList = new List<GameObject>();

        for (int i = 0; i < chunks.Length; i++)
        {
            if (chunks[i].depth == depth)
            {
                tempList.Add(chunks[i].gameObject);
            }
        }

        GameObject[] childArray = new GameObject[tempList.Count];
        childArray = tempList.ToArray();
        return childArray;
    }
    
    private void Init()
    {
        CubeAsset.Settings settings = new CubeAsset.Settings();
        settings.depths.Add(new CubeAsset.DepthInfo(new Vector3(1, 1, 1), NvBlastChunkDesc.Flags.NoFlags));
        settings.depths.Add(new CubeAsset.DepthInfo(new Vector3(2, 2, 2), NvBlastChunkDesc.Flags.SupportFlag));
        settings.extents = new Vector3(10, 10, 10);
        settings.staticHeight = 1.0f;
        _thisCubeAsset = CubeAsset.generate(settings);
        _objectToBlastFamily.Initialize(_thisCubeAsset);
        _objectToBlastFamily.transform.localPosition = this.transform.localPosition;
    }
}
