using System;
using System.Collections.Generic;

using Segmentio;
using Segmentio.Request;
using Segmentio.Model;
using Segmentio.Exception;

namespace Segmentio.Flush
{
	internal class BatchingFlushHandler : IFlushHandler {

		int minBatchSize;
		int maxQueueSize;
		TimeSpan minInterval;

		DateTime nextFlushTime;

		Queue<BaseAction> actionQueue;
		IRequestHandler requestHandler;
		IBatchFactory batchFactory;

		public BatchingFlushHandler() {
			actionQueue = new Queue<BaseAction>();
			nextFlushTime = DateTime.MinValue;
		}

		public BatchingFlushHandler(
			IBatchFactory batchFactory, 
			IRequestHandler requestHandler, 
			int minBatchSize, 
			int maxQueueSize, 
			TimeSpan minInterval
		) : this() {

			this.requestHandler = requestHandler;
			this.batchFactory = batchFactory;
			this.minBatchSize = minBatchSize;
			this.maxQueueSize = maxQueueSize;
			this.minInterval = minInterval;
		}

		public void Process(BaseAction action) {
			requestHandler.Poll();

			int size = actionQueue.Count;

			if (size > maxQueueSize) {
				// drop the message
			} else {
				actionQueue.Enqueue(action);
			}

			if (size+1 >= minBatchSize && DateTime.Now > nextFlushTime && requestHandler.IsReady()) {
				FlushOne();
				nextFlushTime = DateTime.Now.Add(minInterval);
			}
		}

		public void FlushOne() {
			var actionList = new List<BaseAction>();

			for (int i = 0; i < Constants.BatchIncrement; i++) {
				if (actionQueue.Count <= 0) {
					break;
				}
				actionList.Add(actionQueue.Dequeue());
			}

			Batch batch = batchFactory.Create(actionList);
	
			requestHandler.MakeRequest(batch);
		}

		public void Flush() {
			requestHandler.Poll();
			// Send them all
			while (actionQueue.Count > 0) {
				FlushOne();
			}
		}

		public void Dispose() {
			actionQueue = null;
		}
	}
}

