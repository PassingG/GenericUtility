using UnityEngine;

public class TilemapUtility
{
    public static WholeMapPos ConvertToWholeMapPos(int wholeIndex, WorldMapInfo worldMapInfo)
    {
        int calculateX = wholeIndex % worldMapInfo.wholeTileMapSize;
        int calculateY = wholeIndex / worldMapInfo.wholeTileMapSize;

        int tileXIndex = calculateX / worldMapInfo.perTileMapSize;
        int tileYIndex = calculateY / worldMapInfo.perTileMapSize;

        int perTileXIndex = calculateX % worldMapInfo.perTileMapSize;
        int perTileYIndex = calculateY % worldMapInfo.perTileMapSize;

        // 몇번째 타일인지 계산
        int tileIndex = tileXIndex + (tileYIndex * worldMapInfo.chunkWidthCount);

        // 타일 안에서의 인덱스
        int perTileIndex = perTileXIndex + (perTileYIndex * worldMapInfo.perTileMapSize);

        WholeMapPos MapPos = new WholeMapPos(tileIndex, perTileIndex, wholeIndex);

        return MapPos;
    }
    public static WholeMapPos ConvertToWholeMapPos(int chunkIndex, int perTileIndex, WorldMapInfo worldMapInfo)
    {
        int perTileXPos = perTileIndex % worldMapInfo.perTileMapSize;
        int perTileYPos = perTileIndex / worldMapInfo.perTileMapSize;
        int chunkRowCount = chunkIndex / worldMapInfo.chunkWidthCount * worldMapInfo.perTileMapSize;
        int chunkColumnCount = (chunkIndex % worldMapInfo.chunkWidthCount) * worldMapInfo.perTileMapSize;
        int wholeIndex = ((perTileYPos + chunkRowCount) * worldMapInfo.wholeTileMapSize) + perTileXPos + chunkColumnCount;

        WholeMapPos MapPos = new WholeMapPos(chunkIndex, perTileIndex, wholeIndex);

        return MapPos;
    }

    public static Vector2Int PointToWholeChunkPos(Vector3 pos, WorldMapInfo worldMapInfo)
    {
        Vector2Int gridPos = new Vector2Int();

        gridPos.x = (int)((pos.x / worldMapInfo.cellSize.x) + (pos.y / worldMapInfo.cellSize.y));
        gridPos.y = (int)((pos.y / worldMapInfo.cellSize.y) - (pos.x / worldMapInfo.cellSize.x));

        return gridPos;
    }

    public static int PointToIndex(Vector3 pos, WorldMapInfo worldMapInfo)
    {
        Vector2Int gridPos = PointToWholeChunkPos(pos, worldMapInfo);

        return gridPos.x + (gridPos.y * worldMapInfo.wholeTileMapSize);
    }

    public static Vector2Int IndexToGridPos(int index, int width)
    {
        Vector2Int gridPos = new Vector2Int();
        gridPos.x = (int)((float)index % (float)width);
        gridPos.y = (int)((float)index / (float)width);

        return gridPos;
    }

    public static int GridPosToIndex(Vector2Int gridPos, int width)
    {
        return gridPos.x + (gridPos.y * width);
    }

    public static Vector3 IndexToPointCenter(int index, WorldMapInfo worldMapInfo, float zPos = 0f)
    {
        Vector3 point;

        point = new Vector3
            (
            (worldMapInfo.cellSize.x * 0.5f) * ((index % worldMapInfo.wholeTileMapSize) - (index / worldMapInfo.wholeTileMapSize)),
            ((worldMapInfo.cellSize.y * 0.5f) * ((index % worldMapInfo.wholeTileMapSize) + (index / worldMapInfo.wholeTileMapSize))) + (worldMapInfo.cellSize.y / 2f),
            zPos
            );

        return point;
    }

    public static Vector3 IndexToPoint(int index, WorldMapInfo worldMapInfo, float zPos = 0f)
    {
        Vector3 point;

        point = new Vector3
            (
            (worldMapInfo.cellSize.x * 0.5f) * ((index % worldMapInfo.wholeTileMapSize) - (index / worldMapInfo.wholeTileMapSize)), 
            ((worldMapInfo.cellSize.y * 0.5f) * ((index % worldMapInfo.wholeTileMapSize) + (index / worldMapInfo.wholeTileMapSize))),
            zPos
            );

        return point;
    }

    public static Vector3 GridPosToPointCenter(Vector2Int gridPos, Vector3 cellSize, float zPos = 0f)
    {
        Vector3 point;

        point = new Vector3((cellSize.x * 0.5f) * (gridPos.x - gridPos.y), (cellSize.y * 0.5f) * (gridPos.x + gridPos.y) + (cellSize.y / 2f), zPos);

        return point;
    }

    public static Vector3 GridPosToPoint(Vector2Int gridPos,WorldMapInfo worldMapInfo, float zPos = 0f)
    {
        Vector3 point;

        point = new Vector3((worldMapInfo.cellSize.x * 0.5f) * (gridPos.x - gridPos.y), (worldMapInfo.cellSize.y * 0.5f) * (gridPos.x + gridPos.y), zPos);

        return point;
    }
}
