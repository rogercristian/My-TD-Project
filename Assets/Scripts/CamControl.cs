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
   
   
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.GameEnded) { this.enabled = false; return; }

        Vector2 position = InputManager.GetInstance().GetMoveDirection();
        Vector3 move = new Vector3(position.x * speedMove, 0f, position.y * speedMove);

        transform.Translate(move * Time.deltaTime,Space.World );

        //

        float scroll = InputManager.GetInstance().GetScrollAction();
        Vector3 scrollPos = transform.position;

        scrollPos.y -= scroll * scrollSpeed * Time.deltaTime;

        scrollPos.y = Mathf.Clamp(scrollPos.y, min, max);

        transform.position = scrollPos;

        
    }
}
