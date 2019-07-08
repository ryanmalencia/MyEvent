using CSharpLibraries.BaseObjects;
using CSharpLibraries.ObjectManager;
using System;

namespace ConsoleApp
{
    [Serializable]
    public class TestSaveableObject : SaveableObject
    {
        public TestSaveableObject() : base(1)
        {

        }
    }
}
