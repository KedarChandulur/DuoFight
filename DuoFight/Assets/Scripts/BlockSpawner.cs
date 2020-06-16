using System.Collections;
using UnityEngine;

public class BlockSpawner : MonoBehaviour {

	public delegate void Retry();

	public static event Retry OnRetryRaised;

	public delegate void Restart();

	public static event Restart OnRestartRaised;

	[SerializeField] private Transform GreenBlock;
    [SerializeField] private Transform PinkBlock;

    private Vector3 startposition;
    private int blockscount;
	public static int count;

	[SerializeField] private GameObject youWin;

	public GameObject youLoss;

	void Start () {
		OnRetryRaised += EventRetryRaised;
		OnRestartRaised += EventRestartRaised;
		youWin.GetComponent<TextMesh>().text = "You Lost!";
		youWin.GetComponent<TextMesh>().text = "You Win!";
		youLoss.SetActive(false);
		youWin.SetActive(false);
		startposition = new Vector3(0f,-3.5f,0f);
        blockscount = (int)(Camera.main.orthographicSize * 2) - 1;
        Initialize();
    }

	private void OnDisable()
	{
		OnRetryRaised -= EventRetryRaised;
		OnRestartRaised -= EventRestartRaised;
	}

	void EventRetryRaised()
	{
		if (this.gameObject != null)
			StartCoroutine(RetryMethod());
	}
	void EventRestartRaised()
	{
		if (this.gameObject != null)
			StartCoroutine(RestartMethod());
	}

	public static void InvokeRetry()
	{
		OnRetryRaised?.Invoke();
	}
	public static void InvokeRestart()
	{
		OnRestartRaised?.Invoke();
	}

	void Initialize()
    {
        float randomnumber = 0f;
        System.Random r = new System.Random();
        for(int i = 0;i< blockscount;i++)
        {
            randomnumber = r.Next(0, 10);

            Transform blocktospawn = randomnumber > 5f ? PinkBlock : GreenBlock;
            Instantiate(blocktospawn, startposition + Vector3.up * i, Quaternion.identity);
			count++;
        }
    }

	IEnumerator RestartMethod()
	{
			youWin.SetActive(true);
			yield return new WaitForSeconds(3f);
			youWin.GetComponent<TextMesh>().text = "Restarting Hold Up...";
			yield return new WaitForSeconds(3f);
			UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
	}

	IEnumerator RetryMethod()
	{
			youLoss.SetActive(true);
			yield return new WaitForSeconds(1.5f);
			youLoss.GetComponent<TextMesh>().text = "Restarting Hold Up...";
			yield return new WaitForSeconds(1.5f);
			UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
	}
}