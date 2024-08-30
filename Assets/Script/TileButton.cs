using UnityEngine;

public class TileButton : MonoBehaviour
{
    public int x; // ���̃{�^����X���W
    public int y; // ���̃{�^����Y���W

    public void OnClick()
    {
        // �΂�z�u���郍�W�b�N���Ăяo��
        BoardManager.Instance.PlaceStone(x, y, true); // true�͍��΂̗�
    }

    // �{�^���̈ʒu��ݒ肷�郁�\�b�h
    public void SetPosition(int xPos, int yPos)
    {
        x = xPos;
        y = yPos;
    }
}
