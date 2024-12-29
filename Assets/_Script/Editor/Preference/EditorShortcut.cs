using UnityEditor;
using UnityEditor.ShortcutManagement;
using UnityEngine;

public class EditorShortcut
{
    [Shortcut("Window/Close", KeyCode.W, ShortcutModifiers.Control)]
    private static void CloseTab()
    {
        if (EditorWindow.focusedWindow == null) return;
        EditorWindow.focusedWindow.Close();
    }
}
