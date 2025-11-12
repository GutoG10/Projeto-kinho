using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int peixes = 0;
    public TMP_Text textoPeixes;

    void Start()
    {
        textoPeixes.text = "Peixes: " + peixes;
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void AdicionarMoeda(int valor)
    {
        peixes += valor;
        AtualizarUI();
    }

    private void AtualizarUI()
    {
        if (textoPeixes != null)
            textoPeixes.text = "Peixes: " + peixes;
    }
}
