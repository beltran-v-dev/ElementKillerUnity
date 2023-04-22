using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class player_vida : MonoBehaviour
{
    private SpriteRenderer m_SpriteRenderer;
    private GameObject player;
    public GameObject canvasYouDied;
    private Animator animacio;

    public TextMeshProUGUI vidaText;

    public int vida = 5;

    public Material material;

    // Start is called before the first frame update
    private void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        animacio = GetComponent<Animator>();

        material.SetColor("_ToColor", Color.black);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject element = GameObject.Find("Shoot");
        player_shoot tipusElement = element.GetComponent<player_shoot>();

        if (collision.gameObject.tag == "Enemic" || collision.gameObject.tag == "Enemic_2" || collision.gameObject.tag == "Enemic_3")
        {
            //m_SpriteRenderer.sprite = Resources.Load<Sprite>("player_base");
            animacio.SetInteger("color", 0);

            tipusElement.element = 0;

            Destroy(collision.gameObject);

            vida--;

            vidaText.SetText("" + vida);

            material.SetColor("_ToColor", Color.black);

            if (vida == 0)
            {
                Debug.Log("Has mort!");
                canvasYouDied.SetActive(true);
                Time.timeScale = 0f;
            }
        }

        if (collision.gameObject.tag == "Nivell")
        {
            transform.parent = collision.transform;
        }

        if (collision.gameObject.tag == "cor")
        {
            vida = vida + 1;
            vidaText.SetText("" + vida);
            Debug.Log(vida);
            Destroy(collision.gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))

        {
            material.SetColor("_ToColor", Color.red);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))

        {
            material.SetColor("_ToColor", Color.green);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))

        {
            material.SetColor("_ToColor", Color.blue);
        }
    }
}