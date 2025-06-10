using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Universal_library_management_system
{
    public abstract class Media
    {
        [JsonIgnore]
        private string _author;
        public string Title { get; set; }
        public string Author
        {
            get => _author;
            set
            {
                try
                {
                    bool incorrect = false;
                    foreach (char c in value)
                        if (c >= '0' && c <= '9')
                            incorrect = true;

                    if (incorrect)
                        throw new InputException("Имя не должно содержать цифр", value);
                    else
                        _author = value;
                }
                catch (InputException e)
                {
                    Console.WriteLine($"Ошибка! {e.Message}: {e.Value}");
                }
            }
        }
        public int YearPublished { get; set; }
        public bool IsAvailable { get; set; }
    }
}
