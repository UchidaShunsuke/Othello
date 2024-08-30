using UnityEngine;
using System.Collections.Generic;

public class BoardManager : MonoBehaviour
{
    public static BoardManager Instance { get; private set; }

    public GameObject tilePrefab;  // �{�^���i�Z���j�Ɋ��蓖�Ă�v���n�u
    public int gridSize = 8;       // �Ֆʂ̃T�C�Y

    private GameObject[,] board;   // �Ֆʂ��Ǘ�����2�����z��

    void Awake()
    {
        // �C���X�^���X�����ɑ��݂���ꍇ�͂��̃I�u�W�F�N�g��j��
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
                    tileButton.SetPosition(x, y); // �{�^���̍��W��ݒ�
                }
            }
        }
    }

    public void PlaceStone(int x, int y, bool isBlack)
    {
        // ���ɐ΂��z�u����Ă��邩�m�F
        if (board[x, y] != null)
        {
            Debug.LogWarning("Stone already placed at this position.");
            return;
        }

        // �΂�z�u����
        GameObject stone = Instantiate(tilePrefab, board[x, y].transform);
        // �΂̐F��ݒ肷�鏈���������ɒǉ�
        SetStoneColor(stone, isBlack);

        // �΂𗠕Ԃ��������Ăяo��
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

                bool tileIsBlack = IsBlack(tile); // ���̃��\�b�h�B���ۂɂ͐΂̐F���m�F���郍�W�b�N���K�v

                if (tileIsBlack == isBlack)
                    break;

                stonesToFlip.Add(tile);
                i++;
            }
        }

        foreach (var stone in stonesToFlip)
        {
            // �΂̐F��ύX���鏈����ǉ�����
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
        // �^�C���̐F�𔻒f���郍�W�b�N����������
        return false; // ���̖߂�l
    }

    void SetStoneColor(GameObject stone, bool isBlack)
    {
        // �΂̐F��ݒ肷�鏈���������ɒǉ�
    }

    void ToggleStoneColor(GameObject stone)
    {
        // �΂̐F�𗠕Ԃ������������ɒǉ�
    }
}
