using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("拖拽物体")]
    public GameObject bodyPrefab;
    public GameObject Head;
    public GameObject apple;

    private float timer = 0;
    private float previousTime = 0.8f;

    private int Length = 3;
    //float moveTime = 1f;
    /* private Vector3 up = new Vector3(0, 0, 1);
     private Vector3 down = new Vector3(0, 0, -1);
     private Vector3 left = new Vector3(-1, 0, 0);
     private Vector3 right = new Vector3(1, 0, 0);*/
    private Vector3 up => Vector3.forward;
    private Vector3 down => -Vector3.forward;
    private Vector3 left => -Vector3.right;
    private Vector3 right => Vector3.right;
    private Vector3 direction;

    private void Start()
    {
        direction = up;
        //i = 1,2,3
        for (int i = 1; i <= Length; i++)
        {
            GameObject body = Instantiate(bodyPrefab, transform);

            body.transform.position = new Vector3(Head.transform.position.x, Head.transform.position.y, Head.transform.position.z - i);
        }

    }
    private void Update()
    {
        //print("时间"+Time.deltaTime);
        //改变运动方向
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            direction = up;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction = left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction = right;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            direction = down;
        }

        timer += Time.deltaTime;

        if (timer > previousTime)
        {

            timer = 0;
            //从蛇尾开始移动，最后移动蛇头
            for (int n = Length - 1; n > 0; n--)
            {
                transform.GetChild(n).position = transform.GetChild(n - 1).position;

            }
            //第一个子物体移动
            transform.GetChild(0).position = Head.transform.position;
            //蛇头开始移动
            Head.transform.position += direction;
        }

    }

    public void GetApple()
    {


        apple.transform.position = new Vector3(Random.Range(0, 18) + 0.5f, 0.5f, Random.Range(0, 18) + 0.5f);

        //Destroy(apple.gameObject);
        GameObject body = Instantiate(bodyPrefab, transform);

        body.transform.position = transform.GetChild(Length - 1).position;
        Length++;

    }


}
