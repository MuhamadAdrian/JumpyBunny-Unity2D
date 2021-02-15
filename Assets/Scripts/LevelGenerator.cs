using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public List<LevelBlock> legoBlocks = new List<LevelBlock>();

    public List<LevelBlock> currentBlocks = new List<LevelBlock>();

    public Transform initialPoint;

    private static LevelGenerator _sharedInstance;

    public static LevelGenerator sharedInstance {
        get{
            return _sharedInstance;
        }
    }

    public int initialBlockRendered = 2;

    private void Awake() {
        _sharedInstance = this;
        createInitializeBlock();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void createInitializeBlock(){
        for (int i = 0; i < initialBlockRendered; i++)
        {
            AddNewBlock(true);
        }
    }
    public void AddNewBlock(bool initialBlock = false)
    {
        int randNumber = initialBlock ? 0 : Random.Range(0, legoBlocks.Count);
        var block = Instantiate(legoBlocks[randNumber]);
        block.transform.SetParent(this.transform, false);
        Vector3 blockPosition = Vector3.zero;
        if (currentBlocks.Count == 0)
        {
            blockPosition = initialPoint.position;
        } else
        {
            int lastBlockPosition = currentBlocks.Count - 1;
            blockPosition = currentBlocks[lastBlockPosition].exitPoint.position;
        }
        block.transform.position = blockPosition;
        currentBlocks.Add(block);
    }

    public void RemoveOldBlock(){
        var oldBlock = currentBlocks[0];
        currentBlocks.Remove(oldBlock);
        Destroy(oldBlock.gameObject);
    }

    public void RemoveAllBlock()
    {
        while (currentBlocks.Count > 0)
        {
            RemoveOldBlock();
        }
    }
}
