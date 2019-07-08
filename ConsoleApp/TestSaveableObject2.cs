using CSharpLibraries.BaseObjects;
using CSharpLibraries.ObjectManager;
using System;

namespace ConsoleApp
{
    [Serializable]
    public class TestSaveableObject2 : SaveableObject
    {
        public TestSaveableObject2() : base(2)
        {

        }
    }
}
