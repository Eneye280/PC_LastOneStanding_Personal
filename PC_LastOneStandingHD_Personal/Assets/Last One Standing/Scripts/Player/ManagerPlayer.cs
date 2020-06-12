using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Rigidbody))]
[RequireComponent(typeof(PlayerInput), typeof(ParameterPlayer))]
public class ManagerPlayer : MonoBehaviour
{
    [SerializeField] internal bool isGamePlay;
    [SerializeField] internal SOPlayer scriptablePlayer;
    [SerializeField] internal Animator animPlayer;

    private void Awake()
    {
        scriptablePlayer.namePlayer = gameObject.name;
        animPlayer = GetComponent<Animator>();
    }
    private void Update()
    {
        MovementPlayer();
    }

    internal void MovementPlayer()
    {
        if(isGamePlay)
        {
            animPlayer.SetBool("isGamePlay", true);

            scriptablePlayer.horizontal = scriptablePlayer.directionPlayer.x;
            scriptablePlayer.vertical = scriptablePlayer.directionPlayer.y;

            scriptablePlayer.movementPlayer = new Vector3();
            scriptablePlayer.movementPlayer.Set(0, 0, scriptablePlayer.vertical);

            transform.Translate(scriptablePlayer.movementPlayer * scriptablePlayer.speedPlayerMovement * Time.deltaTime);
            transform.Rotate(0, scriptablePlayer.horizontal * scriptablePlayer.speedPlayerRotation * Time.deltaTime, 0);

            animPlayer.SetFloat("Horizontal", scriptablePlayer.horizontal);
            animPlayer.SetFloat("Vertical", scriptablePlayer.vertical);
        }

        else if(!isGamePlay)
        {
            animPlayer.SetBool("isGamePlay", false);
        }

    }
}
