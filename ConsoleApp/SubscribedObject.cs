using CSharpLibraries.RXCS;

namespace ConsoleApp
{
    public class SubscribedObject : EventSink
    {
        private string m_name = "test";

        public string Name { get => m_name; set => m_name = value; }
        public uint ObjId { get => m_id; set => m_id = value; }

        public SubscribedObject() : base(5)
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
                        this.ObjId = obj.ObjId;
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
