using System;
using System.Collections;
using UnityEngine;

using Segmentio.Model;
using Segmentio.Exception;

namespace Segmentio.Request
{
	internal class WWWRequestHandler : IRequestHandler {

		/// <summary>
		/// Segment.io client to mark statistics
		/// </summary>
		private Client client;

		private WWW www;
		private Batch currentBatch;

		internal WWWRequestHandler(Client client) {
			this.client = client;
		}

		public void MakeRequest(Batch batch) {
			try {
				Uri uri = new Uri(client.Options.Host + "/v1/batch");	// correct endpoint

				string json = Json.Serialize(batch);

				if (client.Options.DebugLogJson) {
					Debug.Log(json);
				}

				var encoding = new System.Text.UTF8Encoding();
				var data = encoding.GetBytes(json);
				var postHeaders = new Hashtable();
				postHeaders.Add("Content-Type", "application/json");
				// postHeaders.Add("Content-Length", data.Length); // this is set by WWW class

				www = new WWW(uri.AbsoluteUri, data, postHeaders);
				currentBatch = batch;

			} catch (System.Exception e) {
				Fail(batch, e);
			}
		}

		public void Poll() {
			if (www != null && www.isDone) {
				if (www.error != null) {
					Debug.Log("WWW error: " + www.error);
					Fail(currentBatch, new System.Exception(www.error));
					// Retry
					MakeRequest(currentBatch);

				} else {
					Debug.Log("Batch was succesfully sent"); // git:reject
					Succeed(currentBatch);
					www = null;
					currentBatch = null;
				}
			}
		}

		public bool IsReady() {
			return (www == null);
		}

		private void Fail(Batch batch, System.Exception e) {
			foreach (BaseAction action in batch.batch) {
				client.Statistics.Failed += 1;
				client.RaiseFailure(action, e);
			}
		}


		private void Succeed(Batch batch) {
			foreach (BaseAction action in batch.batch) {
				client.Statistics.Succeeded += 1;
				client.RaiseSuccess(action);
			}
		}
	}
}

