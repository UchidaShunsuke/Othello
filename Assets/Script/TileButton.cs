using UnityEngine;

public class TileButton : MonoBehaviour
{
    public int x; // このボタンのX座標
    public int y; // このボタンのY座標

    public void OnClick()
    {
        // 石を配置するロジックを呼び出す
        BoardManager.Instance.PlaceStone(x, y, true); // trueは黒石の例
    }

    // ボタンの位置を設定するメソッド
    public void SetPosition(int xPos, int yPos)
    {
        x = xPos;
        y = yPos;
    }
}
