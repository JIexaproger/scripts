using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ModiferManager : MonoBehaviour
{
    private InputModifer _inputModifer;
    private Dictionary<IModifer, Coroutine> _activeModifers = new();

    private void Awake()
    {
        _inputModifer = GetComponent<InputModifer>();
    }

    /// <summary>
    /// Запустить модификатор на определенное время
    /// </summary>
    public void ApplyModifer(IModifer modifer, float duration)
    {
        if (_activeModifers.ContainsKey(modifer))
        {
            StopCoroutine(_activeModifers[modifer]);
            _activeModifers.Remove(modifer);
        }
        else
        {
            _inputModifer.AddModifer(modifer);
        }

        Coroutine timerCoroutine = StartCoroutine(ModiferTimerCoroutine(modifer, duration));
        _activeModifers.Add(modifer, timerCoroutine);
    }

    private IEnumerator ModiferTimerCoroutine(IModifer modifer, float duration)
    {
        yield return new WaitForSeconds(duration);

        _inputModifer.RemoveModifer(modifer);
        _activeModifers.Remove(modifer);

        Debug.Log($"Действие модификатора {modifer.GetType().Name} закончилось");
    }
}

[CustomEditor(typeof(ModiferManager))]
public class ModiferManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        ModiferManager manager = (ModiferManager)target;

        if (GUILayout.Button("Добавить модификатор инверсии на 3 сек"))
        {
            manager.ApplyModifer(new InversionModifer(), 3f);
        }
        if (GUILayout.Button("Добавить модификатор компаса на 5 сек"))
        {
            manager.ApplyModifer(new CompasModifer(), 5f);
        }
        if (GUILayout.Button("Добавить модификатор отказа кнопки на 10 сек"))
        {
            manager.ApplyModifer(new ButtonDisableModifer(), 10f);
        }
    }
}