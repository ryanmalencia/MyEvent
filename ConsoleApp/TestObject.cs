using System;
using CSharpLibraries.RXCS;

namespace ConsoleApp
{
    public class TestObject : EventSink
    {
        public TestObject() : base(3)
        {

        }

        public override void OnObjectChanged(object sender, ObjectChangedEventArgs e)
        {
            if (!(e.ObjectChanged is EventSource obj))
                return;

            switch ((ePropertyId)e.PropertyChanged)
            {
                case ePropertyId.simpleObject_id:
                    {
                        Console.WriteLine(obj.Id);
                        break;
                    }
                case ePropertyId.simpleObject_name:
                    {
                        Console.WriteLine(obj.ToString());
                        break;
                    }
            }
        }
    }
}
