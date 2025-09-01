using UnityEngine;


public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject destroyedVFX;
    [SerializeField] int hitPoints = 3;

    [SerializeField] int scoreValue = 100;

    ScoreBoard scoreBoard;

    void Start()
    {
        scoreBoard = FindFirstObjectByType<ScoreBoard>();
    }
    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    void ProcessHit()
    {
        hitPoints--;
        if (hitPoints <= 0)
        {
            scoreBoard.IncreaseScore(scoreValue);
            Instantiate(destroyedVFX, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
