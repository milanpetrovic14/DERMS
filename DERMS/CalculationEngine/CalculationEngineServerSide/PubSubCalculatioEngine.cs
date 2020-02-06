using CalculationEngineServiceCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculationEngineService
{
    public class PubSubCalculatioEngine : IPubSubCalculateEngine, INotify
    {
        private Dictionary<string, ServerSideProxy> subscribers = new Dictionary<string, ServerSideProxy>();
        private TopicSubscriptions topicSubscriptions = new TopicSubscriptions();
        private object subscribersLock = new object();

        public void Notify(string forcastDayAhead, long gidOfTopic)
        {
            throw new NotImplementedException();
        }

        public void Subscribe(string clientAddress, long gidOfTopic)
        {
            lock (subscribersLock)
            {
                if (!subscribers.ContainsKey(clientAddress))
                {
                    subscribers.Add(clientAddress, new ServerSideProxy(clientAddress));
                }
                topicSubscriptions.Subscribe(clientAddress, gidOfTopic);
            }
        }

        public void Unsubscribe(string clientAddress, long gidOfTopic, bool disconnect)
        {
            lock (subscribersLock)
            {
                if (disconnect)
                {
                    //close connection
                    subscribers.Remove(clientAddress);
                }
                topicSubscriptions.Unsubscribe(clientAddress, gidOfTopic);
            }
        }
    }
}
