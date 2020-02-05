using UnityEngine;
using System.Collections;

public class UVCube2 : MonoBehaviour
{
    private MeshFilter mf2;
    public float tileSize2 = 0.125f;


    // Use this for initialization
    void Start()
    {

        ApplyTexture();

    }

    public void ApplyTexture()
    {
        mf2 = gameObject.GetComponent<MeshFilter>();
        if (mf2)
        {
            Mesh mesh = mf2.sharedMesh;
            if (mesh)
            {

                Vector2[] uvs2 = mesh.uv;
                //FRBLUD - Freeblood


                // Front
                uvs2[0] = new Vector2(0f, 0f); //Bottom Left
                uvs2[1] = new Vector2(tileSize2, 0f); //Bottom Right
                uvs2[2] = new Vector2(0f, 1f); //Top Left
                uvs2[3] = new Vector2(tileSize2, 1f); // Top Right

                // Right
                uvs2[20] = new Vector2(tileSize2 * 1.001f, 0f);
                uvs2[22] = new Vector2(tileSize2 * 2.001f, 0f);
                uvs2[23] = new Vector2(tileSize2 * 1.001f, 1f);
                uvs2[21] = new Vector2(tileSize2 * 2.001f, 1f);


                // Back
                uvs2[10] = new Vector2((tileSize2 * 2.001f), 1f);
                uvs2[11] = new Vector2((tileSize2 * 3.001f), 1f);
                uvs2[6] = new Vector2((tileSize2 * 2.001f), 0f);
                uvs2[7] = new Vector2((tileSize2 * 3.001f), 0f);

                // Left
                uvs2[16] = new Vector2(tileSize2 * 3.001f, 0f);
                uvs2[18] = new Vector2(tileSize2 * 4.001f, 0f);
                uvs2[19] = new Vector2(tileSize2 * 3.001f, 1f);
                uvs2[17] = new Vector2(tileSize2 * 4.001f, 1f);

                // Up
                uvs2[8] = new Vector2(tileSize2 * 4.001f, 0f);
                uvs2[9] = new Vector2(tileSize2 * 5.001f, 0f);
                uvs2[4] = new Vector2(tileSize2 * 4.001f, 1f);
                uvs2[5] = new Vector2(tileSize2 * 5.001f, 1f);


                // Down
                uvs2[12] = new Vector2(tileSize2 * 5.001f, 0f);
                uvs2[14] = new Vector2(tileSize2 * 6.001f, 0f);
                uvs2[15] = new Vector2(tileSize2 * 5.001f, 1f);
                uvs2[13] = new Vector2(tileSize2 * 6.001f, 1f);


                mesh.uv = uvs2;


            }
        }
        else
            Debug.Log("No mesh filter attached");

    }
}