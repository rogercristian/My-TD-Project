using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class CamControl : MonoBehaviour
{
    [SerializeField] float speedMove = 30f;
    [SerializeField] float scrollSpeed = 5.0f;
    [SerializeField] float min = 2f;
    [SerializeField] float max = 10f;
    Rigidbody rb;
    Vector2 position;
    float scroll;

    // Start is called before the first frame update
    void Start()
    {
     rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.GameEnded) { this.enabled = false; return; }

       
        position = InputManager.GetInstance().GetMoveDirection();
      //  Vector3 move = new Vector3(position.x * speedMove, 0f, position.y * speedMove);
       // rb.velocity = new Vector3(position.x * speedMove, 0f, position.y * speedMove) * Time.deltaTime;

       // transform.Translate(rb.velocity = new Vector3(position.x * speedMove, 0f, position.y * speedMove) * Time.deltaTime,Space.World );

        //

       scroll = InputManager.GetInstance().GetScrollAction();
        
        
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector3(position.x * speedMove, 0f, position.y * speedMove) * Time.deltaTime;

        Vector3 scrollPos = transform.position;

        scrollPos.y -= scroll * scrollSpeed * Time.deltaTime;

        scrollPos.y = Mathf.Clamp(scrollPos.y, min, max);

        transform.position = scrollPos;
    }

}
