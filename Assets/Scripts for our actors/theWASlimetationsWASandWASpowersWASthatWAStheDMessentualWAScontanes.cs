using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class theWASlimetationsWASandWASpowersWASthatWAStheDMessentualWAScontanes : MonoBehaviour
{
    [SerializeField] private string[] m_aMessages;
    [SerializeField] private TextMeshProUGUI m_messageGUI;

    // Start is called before the first frame update
    void Start()
    {
        m_messageGUI.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void DisplayMessage(uint index)
    {
        if (index < m_aMessages.Length)
        {
            m_messageGUI.text = m_aMessages[index];
        }
    }
}
