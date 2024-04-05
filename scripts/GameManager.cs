

using System.Net.Mime;
using System.Collections;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject obstacle;
    public Transform spawnPoint;
    int score = 0;
    public TextMeshProUGUI scoreText;
    public GameObject playButton;
    public GameObject player;
    public GameObject ExitButton;

    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnObstacles()
    {
        while(true)
        {
            float waitTime = Random.Range(0.5f, 2f);

            yield return new WaitForSeconds(waitTime);

            Instantiate(obstacle,spawnPoint.position,Quaternion.identity);
        }
    }

    void ScoreUp()
    {
        score++;
        scoreText.text=score.ToString();
    }

    public void GameStart()
    {   
        player.SetActive(true);
        playButton.SetActive(false);
        ExitButton.SetActive(false);
        StartCoroutine("SpawnObstacles");
        InvokeRepeating("ScoreUp",2f,1f);
        SimpleSampleCharacterControl control = player.GetComponent<SimpleSampleCharacterControl>();
         if (control != null)
    {
        control.ActivateCharacter(); // This enables the character's ability to move and start animations.
    }
        
    }

    public void Exit()
    {
        Application.Quit();
    }
}
