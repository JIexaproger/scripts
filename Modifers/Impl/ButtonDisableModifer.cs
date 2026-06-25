using UnityEngine;

public class ButtonDisableModifer : IModifer
{
    private int _randomNum;
    public ButtonDisableModifer()
    {
        _randomNum = Random.Range(0, 4);
    }
    public Vector2 Move(Vector2 inputVector, IPlayerInput input)
    {
        switch (_randomNum)
        {
            case 0: // W или вперед
                Debug.Log("Отказ кнопки для движения Вперёд");
                return new Vector2(Mathf.Min(inputVector.x, 0f), inputVector.y).normalized;
            case 1: // A или влево
                Debug.Log("Отказ кнопки для движения Влево");
                return new Vector2(inputVector.x, Mathf.Min(inputVector.y, 0f)).normalized;
            case 2: // S или назад
                Debug.Log("Отказ кнопки для движения Назад");
                return new Vector2(Mathf.Max(inputVector.x, 0f), inputVector.y).normalized;
            case 3: // D или вправо
                Debug.Log("Отказ кнопки для движения Вправо");
                return new Vector2(inputVector.x, Mathf.Max(inputVector.y, 0f)).normalized;
            default:
                return new();
        }
    }
}
