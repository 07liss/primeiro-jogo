using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    public Transform camera;
    public Rigidbody corpo;
    public float velocidade = 60.0f;

    public Vector2 olhar;

    public Vector2 movimentacao;

    float rotacaoVertical;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        Vector3 arrumandoMov = new Vector3(-movimentacao.x, 0, -movimentacao.y);
        transform.Translate(arrumandoMov * velocidade * Time.deltaTime);

        float rotacaoHorizontal = olhar.x * 10.0f * Time.deltaTime;
        transform.Rotate(0, rotacaoHorizontal, 0);

        rotacaoVertical -= olhar.y * 10.0f * Time.deltaTime;
        rotacaoVertical = Mathf.Clamp(rotacaoVertical, -90, 90);
        camera.localRotation = Quaternion.Euler(rotacaoVertical, 0, 0);

        //corpo.AddForce(Vector3.forward * velocidade * Time.deltaTime, ForceMode.Force);
    }

    void OnMove(InputValue value)
    {
        movimentacao = value.Get<Vector2>();
    }

    void OnLook(InputValue value)
    {
        olhar = value.Get<Vector2>();
    }
}