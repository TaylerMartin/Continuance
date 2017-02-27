using UnityEngine;
using System.Collections;

public class EndOfTheWorldController : MonoBehaviour {
    /// <summary>
    /// Speed of the wall
    /// </summary>
    public static float entropy;
    public static bool LifeExists;
	// Use this for initialization
	void Start ()
    {
        entropy = 10;
    }
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    IEnumerator DeathWall()
    {
        while (LifeExists)
        {
            float x = entropy * Time.deltaTime;

            transform.Translate(x, 0, 0);
            yield return new WaitForEndOfFrame();
        }
    }

}
