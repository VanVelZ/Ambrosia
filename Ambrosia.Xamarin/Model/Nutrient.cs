using System;
namespace Ambrosia.Xamarin.Model
{
    public class Nutrient
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public float Amount { get; set; }
        public string UnitName { get; set; }

        public Nutrient()
        {
        }
        public override string ToString()
        {
            return Name + ": " + Amount + UnitName;
        }
    }
}
