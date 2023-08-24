using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarSelector : MonoBehaviour
{
    public ReneverseMintManager mintManager;
    readonly Dictionary<int, string> map = new() {
        { 1, "Normal" },
        { 2, "Yellow" },
        { 3, "Red" },
        { 4, "Black" },
        { 5, "Maroon" },
        { 6, "Blue" },
        { 7, "Green" }
    };

    readonly Dictionary<string, int> map2 = new() {
        { "Normal", 1},
        { "Yellow", 2 },
        { "Red", 3},
        { "Black", 4 },
        { "Maroon", 5 },
        { "Blue" , 6 },
        { "Green" , 7 }
    };

    readonly Dictionary<int, string> assetTemplateIDs = new()
    {
        { 2, "c60a6151-f28c-4965-8f32-454fdeefc5d4" },
        { 3, "643d2e17-c463-4e15-b4de-5cd4aed65e5d" },
        { 4, "d5867d7d-db83-4c65-a6cd-b2070e361a66" },
        { 5, "9d69dbbf-8209-48fe-9d0e-bb6a77ffc00f" },
        { 6, "9aaa87c6-ce2f-4be8-bad0-a0a04217b2d1" },
        { 7, "305f022d-22cb-4cea-a554-a787ab80144c" }
    };

    public List<GameObject> select;
    public List<GameObject> locked;
    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        foreach (Asset asset in ReneverseManager.NFTCounter)
        {
            locked[map2[asset.AssetName] - 1].SetActive(false);
        }
    }

    public async void SetSkin(int index)
    {

        foreach (Asset asset in ReneverseManager.NFTCounter)
        {
            if (asset.AssetName == map[index])
            {
                return;
            }
        }

        try
        {
            await mintManager.Mint(assetTemplateIDs[index]);
            Asset tempAsset = new(map[index], "tempDesc", "tempUrl", assetTemplateIDs[index], "tempId");
            ReneverseManager.NFTCounter.Add(tempAsset);
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }

    }
}
