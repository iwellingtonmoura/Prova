using System;
namespace Prova.Data
{
    internal class CollectionAttribute : Attribute
    {
        private string v;

        public CollectionAttribute(string v)
        {
            this.v = v;
        }
    }
}

