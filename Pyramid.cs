using UnityEngine;

public class Pyramid : MonoBehaviour
{
    [Header("层数n")]
    public int layers = 7;
    [Header("方块尺寸")]
    public float cubeSize = 1f;
    [Header("方块预制体")]
    public GameObject cubePrefab;
    [Header("是否实心")]
    public bool solid = false;

    void Start()
    {
        BuildPyramid();    
    }

    [ContextMenu("Build Pyramid")]
    public void BuildPyramid()
    {
        if (layers <= 0) return;

        for(int y = 0; y < layers; y ++)
        {
            int side = 2 * (layers - y) - 1; //顶层为1(单位块)
            float offset = (side - 1) * 0.5f;//以原点为中心

            for(int x = 0; x < side; x++)
            {
                for(int z = 0; z < side; z++)
                {
                    bool isEdge = x == 0 || z == 0 || x == side - 1
                        || z == side - 1;
                    if (!solid && !isEdge) continue;//只想留外框

                    Vector3 pos = new Vector3(
                        (x - offset) * cubeSize,
                        y * cubeSize,
                        (z - offset) * cubeSize);

                    SpawnCube(pos);
                }
            }
        }
    }

    void SpawnCube(Vector3 localPos)
    {
        GameObject go = cubePrefab != null
            ? Instantiate(cubePrefab)
            : GameObject.CreatePrimitive(PrimitiveType.Cube);

        go.name = "Cube";
        go.transform.SetParent(this.transform, false);
        go.transform.localPosition = localPos;
        go.transform.localScale = Vector3.one * cubeSize;
    }
  
}
