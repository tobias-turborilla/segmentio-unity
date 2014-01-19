using UnityEngine;
using System.Collections;
using Segmentio;
using Segmentio.Model;

public class SegmentIOExample : MonoBehaviour {

	// Use this for initialization
	IEnumerator Start () {
		Analytics.Initialize("kb0pxaqjrs", new Options().SetDebugLogJson(true).SetMinBatchSize(2).SetMinSendBatchInterval(new System.TimeSpan(0,0,0)));

		Client client = Analytics.Client;
		Traits traits = new Traits();
		traits.Put("hasPurchased", true).Put("isConnected", false);

		client.Identify("user1", traits);

		yield return new WaitForSeconds(2);

		client.Track("user1", "Started Race", new Properties().Put("track", new Properties().Put("name","track1").Put("rating", 5.4)).Put("skin", "yellow"), null, new Context().SetIp("100.12.12.12").SetLanguage("Swedish"));
		yield return new WaitForSeconds(2);
		client.Track("user1", "Opened Shop");
		yield return new WaitForSeconds(2);
		client.Track("user1", "Started Race", new Properties().Put("track", "track2").Put("skin", "yellow"));
		yield return new WaitForSeconds(2);
		client.Track("user1", "Started Race", new Properties().Put("track", "track3").Put("skin", "yellow"));
		yield return new WaitForSeconds(2);
		client.Track("user1", "Started Race", new Properties().Put("track", "track4").Put("skin", "yellow"));
		yield return new WaitForSeconds(2);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDestroy() {

	}
}
