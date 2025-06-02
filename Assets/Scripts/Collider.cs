using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Collider : MonoBehaviour
{
    [SerializeField] Renderer finishRen;
    [SerializeField] Movement movementScript;
    [SerializeField] TMP_Text Score;
    [SerializeField] TMP_Text Yorum;
    [SerializeField] Material FinishMaterial;
    [SerializeField] Material WallMaterial;
    [SerializeField] Material CloseWallMaterial;
    //[SerializeField] Reflection reflectionScript;
    [SerializeField] float collisionCooldown = 0.2f;

    int number;
    float lastCollisionTime;
    public bool canPlay = true;
    public bool canSuccess = false;

    
    void Start()
    {
        int levelIndex = SceneManager.GetActiveScene().buildIndex;
        switch (levelIndex)
        {
            case 1: number = 3; break;
            case 2: number = 3; break;
            case 3: number = 4; break;
            case 4: number = 4; break;
            case 5: number = 4; break;
        }
        Score.text = number.ToString();
        movementScript = GetComponent<Movement>();

        //reflectionScript = GetComponent<Reflection>();
        lastCollisionTime = -collisionCooldown;

    }

    void Update()
    {
        if (number == 0)
        {
            finishRen.material = FinishMaterial;
        }
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            if (number == 2)
            {
                GameObject oldFinishWall = GameObject.Find("OldFinishWall");
                oldFinishWall.GetComponent<Renderer>().material = WallMaterial;
                finishRen.material = CloseWallMaterial;
                Debug.Log("OldWall: " + oldFinishWall);
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        //if (!reflectionScript.canCollide) return;
        if (Time.time - lastCollisionTime < collisionCooldown) return;
        lastCollisionTime = Time.time;
        if (collision.gameObject.CompareTag("wall"))
        {
            if (number != 0)
            {
                number--;
            }
            else
            {
                Nanay();
            }
        }
        else
        {
            if (number != 0)
            {
                Nanay();
            }
            else
            {
                //
                canSuccess = true;
                Yorum.text = "Bravo sonunda hayatta bi siki başardın Afferin";
                movementScript.StopMove();
                Invoke("LoadNextLevel", 2f);
            }
        }
        Score.text = number.ToString();

    }
    void Nanay()
    {
        canPlay = false;
        Yorum.text = "Yandın PUHAHAHHAHA";
        movementScript.StopMove();
        
        Invoke("ReloadLevel", 2f);
    }
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    
    
}
