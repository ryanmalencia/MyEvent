using CSharpLibraries.RXCS;

namespace ConsoleApp
{
    public class SimpleObject : EventSource
    {
        private string m_name;

        public SimpleObject() : base(4)
        {

        }

        public uint ObjId
        {
            get
            {
                return m_id;
            }
            set
            {
                m_id = value;
                this.NotifyObjectChanged(this, (int)ePropertyId.simpleObject_id);
            }
        }

        public string Name
        {
            get
            {
                return m_name;
            }
            set
            {
                m_name = value;
                this.NotifyObjectChanged(this, (int)ePropertyId.simpleObject_name);
            }
        }
    }
}
