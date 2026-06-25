using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class InputModifer : MonoBehaviour
{
    private List<IModifer> _modifers = new List<IModifer>();

    public void AddModifer(IModifer controlModifer)
    {
        if (!_modifers.Contains(controlModifer))
        {
            _modifers.Add(controlModifer);
        }
    }

    public void RemoveModifer(IModifer controlModifer)
    {
        if (_modifers.Contains(controlModifer))
        {
            _modifers.Remove(controlModifer);
        }
    }

    public void ClearModifers()
    {
        _modifers.Clear();
    }

    public Vector2 GetMoveVector(IPlayerInput input)
    {
        Vector2 moveVector = input.moveInput;
        foreach (var modifer in _modifers)
        {
            moveVector = modifer.Move(moveVector, input);
        }
        return moveVector;
    }
}

[CustomEditor(typeof(InputModifer))]
public class InputModiferEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        InputModifer inputModifer = (InputModifer)target;

        if (GUILayout.Button("Сбросить все"))
        {
            inputModifer.ClearModifers();
        }
        if (GUILayout.Button("Добавить модификатор инверсии"))
        {
            inputModifer.AddModifer(new InversionModifer());
        }
        if (GUILayout.Button("Добавить модификатор компаса"))
        {
            inputModifer.AddModifer(new CompasModifer());
        }
        if (GUILayout.Button("Добавить модификатор отказа кнопки"))
        {
            inputModifer.AddModifer(new ButtonDisableModifer());
        }
        if (GUILayout.Button("Добавить модификатор стрелочек"))
        {
            inputModifer.AddModifer(new ArrowsOnlyModifer());
        }
        if (GUILayout.Button("Добавить модификатор двойного ввода"))
        {
            inputModifer.AddModifer(new DoubleInputModifer());
        }
        if (GUILayout.Button("Добавить модификатор </>"))
        {
            inputModifer.AddModifer(new AngleBracketsModifer());
        }
    }
}
