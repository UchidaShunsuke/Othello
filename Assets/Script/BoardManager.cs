using UnityEngine;
using System.Collections.Generic;

public class BoardManager : MonoBehaviour
{
    public static BoardManager Instance { get; private set; }

    public GameObject tilePrefab;  // ボタン（セル）に割り当てるプレハブ
    public int gridSize = 8;       // 盤面のサイズ

    private GameObject[,] board;   // 盤面を管理する2次元配列

    void Awake()
    {
        // インスタンスが既に存在する場合はこのオブジェクトを破棄
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        board = new GameObject[gridSize, gridSize];
        CreateBoard();
    }

    void CreateBoard()
    {
        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                GameObject tile = Instantiate(tilePrefab, transform);
                board[x, y] = tile;

                TileButton tileButton = tile.GetComponent<TileButton>();
                if (tileButton != null)
                {
                    tileButton.SetPosition(x, y); // ボタンの座標を設定
                }
            }
        }
    }

    public void PlaceStone(int x, int y, bool isBlack)
    {
        // 既に石が配置されているか確認
        if (board[x, y] != null)
        {
            Debug.LogWarning("Stone already placed at this position.");
            return;
        }

        // 石を配置する
        GameObject stone = Instantiate(tilePrefab, board[x, y].transform);
        // 石の色を設定する処理をここに追加
        SetStoneColor(stone, isBlack);

        // 石を裏返す処理を呼び出す
        FlipStones(x, y, isBlack);
    }

    void FlipStones(int x, int y, bool isBlack)
    {
        List<GameObject> stonesToFlip = new List<GameObject>();

        foreach (var direction in GetDirections())
        {
            int i = 1;
            while (true)
            {
                int newX = x + direction.x * i;
                int newY = y + direction.y * i;

                if (!IsInBounds(newX, newY))
                    break;

                GameObject tile = board[newX, newY];
                if (tile == null)
                    break;

                bool tileIsBlack = IsBlack(tile); // 仮のメソッド。実際には石の色を確認するロジックが必要

                if (tileIsBlack == isBlack)
                    break;

                stonesToFlip.Add(tile);
                i++;
            }
        }

        foreach (var stone in stonesToFlip)
        {
            // 石の色を変更する処理を追加する
            ToggleStoneColor(stone);
        }
    }

    bool IsInBounds(int x, int y)
    {
        return x >= 0 && x < gridSize && y >= 0 && y < gridSize;
    }

    Vector2Int[] GetDirections()
    {
        return new Vector2Int[]
        {
            new Vector2Int(-1, -1), new Vector2Int(0, -1), new Vector2Int(1, -1),
            new Vector2Int(-1, 0), new Vector2Int(1, 0),
            new Vector2Int(-1, 1), new Vector2Int(0, 1), new Vector2Int(1, 1)
        };
    }

    bool IsBlack(GameObject tile)
    {
        // タイルの色を判断するロジックを実装する
        return false; // 仮の戻り値
    }

    void SetStoneColor(GameObject stone, bool isBlack)
    {
        // 石の色を設定する処理をここに追加
    }

    void ToggleStoneColor(GameObject stone)
    {
        // 石の色を裏返す処理をここに追加
    }
}
