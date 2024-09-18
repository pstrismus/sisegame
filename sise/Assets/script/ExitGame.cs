using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void Exit()
    {
        // Oyun derlenmiş bir build halindeyken oyundan çıkar
        Application.Quit();

        // Bu kod sadece editör modunda çalışır, editörde test ederken faydalı olur
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}