using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Tile/RuleTile")]
public class RuleTileCustom : ScriptableObject
{
    [Header("○○○"), Space(-15)]
    [Header("○●○"), Space(-15)]
    [Header("○●○"), Space(10)]
    [SerializeField]
    private Tile Up;

    [Header("○●○"), Space(-15)]
    [Header("○●○"), Space(-15)]
    [Header("○○○"), Space(10)]
    [SerializeField]
    private Tile Down;

    [Header("○○○"), Space(-15)]
    [Header("●●○"), Space(-15)]
    [Header("○○○"), Space(10)]
    [SerializeField]
    private Tile Left;

    [Header("○○○"), Space(-15)]
    [Header("○●●"), Space(-15)]
    [Header("○○○"), Space(10)]
    [SerializeField]
    private Tile Right;

    [Header("○○○"), Space(-15)]
    [Header("●●●"), Space(-15)]
    [Header("○○○"), Space(10)]
    [SerializeField]
    private Tile Left_Right;

    [Header("○●○"), Space(-15)]
    [Header("○●○"), Space(-15)]
    [Header("○●○"), Space(10)]
    [SerializeField]
    private Tile Up_Down;

    [Header("○●○"), Space(-15)]
    [Header("●●○"), Space(-15)]
    [Header("○○○"), Space(10)]
    [SerializeField]
    private Tile Left_Down;

    [Header("○○○"), Space(-15)]
    [Header("●●○"), Space(-15)]
    [Header("○●○"), Space(10)]
    [SerializeField]
    private Tile Left_Up;

    [Header("○●○"), Space(-15)]
    [Header("○●●"), Space(-15)]
    [Header("○○○"), Space(10)]
    [SerializeField]
    private Tile Right_Down;

    [Header("○○○"), Space(-15)]
    [Header("○●●"), Space(-15)]
    [Header("○●○"), Space(10)]
    [SerializeField]
    private Tile Right_Up;

    [Header("○●○"), Space(-15)]
    [Header("●●○"), Space(-15)]
    [Header("○●○"), Space(10)]
    [SerializeField]
    private Tile Left_Up_Down;

    [Header("○●○"), Space(-15)]
    [Header("○●●"), Space(-15)]
    [Header("○●○"), Space(10)]
    [SerializeField]
    private Tile Right_Up_Down;

    [Header("○●○"), Space(-15)]
    [Header("●●●"), Space(-15)]
    [Header("○○○"), Space(10)]
    [SerializeField]
    private Tile Down_Left_Right;

    [Header("○○○"), Space(-15)]
    [Header("●●●"), Space(-15)]
    [Header("○●○"), Space(10)]
    [SerializeField]
    private Tile Up_Left_Right;

    [Header("○●○"), Space(-15)]
    [Header("●●●"), Space(-15)]
    [Header("○●○"), Space(10)]
    [SerializeField]
    private Tile Four_way;

    [SerializeField, Space(10)]
    private Tile.ColliderType colliderType;

    [SerializeField, Space(10)]
    private Color color = Color.white;

    public Tile GetTileWithNeighbor(int[,] neighborArray)
    {
        if (neighborArray[1,0] == 1 && neighborArray[0, 1] == 1 && neighborArray[2, 1] == 1 && neighborArray[1, 2] == 1)
        {
            return Four_way;
        }
        else if(neighborArray[1, 0] == 1 && neighborArray[0, 1] == 1 && neighborArray[2, 1] == 1)
        {
            return Down_Left_Right;
        }
        else if (neighborArray[0, 1] == 1 && neighborArray[2, 1] == 1 && neighborArray[1, 2] == 1)
        {
            return Up_Left_Right;
        }
        else if (neighborArray[0, 1] == 1 && neighborArray[1, 0] == 1 && neighborArray[1, 2] == 1)
        {
            return Left_Up_Down;
        }
        else if (neighborArray[2, 1] == 1 && neighborArray[1, 0] == 1 && neighborArray[1, 2] == 1)
        {
            return Right_Up_Down;
        }
        else if (neighborArray[2, 1] == 1 && neighborArray[1, 2] == 1)
        {
            return Right_Up;
        }
        else if (neighborArray[2, 1] == 1 && neighborArray[1, 0] == 1)
        {
            return Right_Down;
        }
        else if (neighborArray[0, 1] == 1 && neighborArray[1, 2] == 1)
        {
            return Left_Up;
        }
        else if (neighborArray[0, 1] == 1 && neighborArray[1, 0] == 1)
        {
            return Left_Down;
        }
        else if (neighborArray[0, 1] == 1 && neighborArray[2, 1] == 1)
        {
            return Left_Right;
        }
        else if (neighborArray[1, 0] == 1 && neighborArray[1, 2] == 1)
        {
            return Up_Down;
        }
        else if (neighborArray[1, 2] == 1)
        {
            return Up;
        }
        else if (neighborArray[1, 0] == 1)
        {
            return Down;
        }
        else if (neighborArray[0, 1] == 1)
        {
            return Left;
        }
        else if (neighborArray[2, 1] == 1)
        {
            return Right;
        }
        else
        {
            Debug.LogError("Cannot Find Sprite :: RuleTileCustom");

            return null;
        }
    }
}
