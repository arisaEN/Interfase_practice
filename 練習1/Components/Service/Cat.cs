using 練習1.Components.Interface;

namespace 練習1.Components.Service
{
    public class Cat : IAnimal
    {
        public string Speak()
        {
            return "ニャー！";
        }
    }
}
