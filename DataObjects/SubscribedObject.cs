namespace DataObjects
{
    public class SubscribedObject : EventSink
    {
        private int m_id = 2;
        private string m_name = "test";

        public string Name { get => m_name; set => m_name = value; }
        public int Id { get => m_id; set => m_id = value; }

        public SubscribedObject()
        {

        }

        public override void OnObjectChanged(object sender, ObjectChangedEventArgs e)
        {
            if (!(e.ObjectChanged is SimpleObject obj))
                return;

            switch ((ePropertyId)e.PropertyChanged)
            {
                case ePropertyId.simpleObject_id:
                    {
                        this.Id = obj.Id;
                        break;
                    }
                case ePropertyId.simpleObject_name:
                    {
                        m_name = obj.Name;
                        break;
                    }
            }
        }
    }
}
