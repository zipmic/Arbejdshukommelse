using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordBlock : MonoBehaviour {

    [HideInInspector]
    public string BlockText;
    public Text TextInBlock1, TextInBlock2;



    public void SetBlock(string NameOnBlock)
    {
        BlockText = NameOnBlock;
        TextInBlock1.text = BlockText;
        TextInBlock2.text = BlockText;
    }
}
