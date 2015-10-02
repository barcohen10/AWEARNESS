using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWEARNESS.Models.Repository
{
    public enum eEventType
    {
        Scan = 1,
        Typed = 2,
        Notified = 3
    }

    public class Event
    {
        public Guid Id { get; set; }
        public DateTime Time { get; set; }
        public string Catagory { get; set; }
        public string PhoneNumberCaregiver { get; set; }
        public eEventType EventType { get; set; }

    }
    public class EventMng
    {
        private static EventMng m_Instance;
        private Dictionary<string, Event> m_Events = new Dictionary<string, Event>();
        private AwearnessDB m_DB = new AwearnessDB();

        private EventMng()
        {

            var events = m_DB.Events.ToList();

            foreach (Event eventt in events)
            {
                this.m_Events.Add(eventt.Id.ToString(), eventt);
            }
        }

        public static EventMng Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new EventMng();
                }
                return m_Instance;
            }
        }

        public List<Event> AllQRCodes
        {
            get
            {
                return m_Events.Values.ToList();
            }
        }

        public Event GetEvent(string i_EventId)
        {
            if (m_Events.ContainsKey(i_EventId))
            {
                return m_Events[i_EventId.ToString()];
            }
            return null;
        }

        public void CreateEvent(Event i_Event)
        {
            if (!m_Events.ContainsKey(i_Event.Id.ToString()))
            {
                m_Events.Add(i_Event.Id.ToString(), i_Event);
                m_DB.Events.Add(i_Event);
                m_DB.SaveChanges();
            }
        }

        public void UpdateEvent(Event i_Event)
        {
            Event eventItem = EventMng.Instance.GetEventFromDb(i_Event.Id.ToString());
            eventItem.PhoneNumberCaregiver = i_Event.PhoneNumberCaregiver;
            eventItem.Time = i_Event.Time;
            eventItem.EventType = i_Event.EventType;
            eventItem.Catagory = i_Event.Catagory;
            m_DB.Entry(eventItem).State = EntityState.Modified;
            m_DB.SaveChanges();
        }

        public void DeleteEvent(string i_ID)
        {
            Event eventItem = m_DB.Events.Find(i_ID);
            m_Events.Remove(i_ID);
            m_DB.Events.Remove(eventItem);
            m_DB.SaveChanges();
        }

        public Event GetEventFromDb(string i_ID)
        {
            Event eventItem = m_DB.Events.Find(i_ID);
            return eventItem;
        }
    }

}