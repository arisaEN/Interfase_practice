using 練習1.Components.Interface;

namespace 練習1.Components.Service
{
    public class Dog : IAnimal
    {
        public string Speak()
        {
            return "ワン！ワン！";
        }
    }
}
