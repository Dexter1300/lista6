using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lista6
{
    public class View
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int nr_klasy { get; set; }

        public string kierunek { get; set; }

        public View(int id, string imie, string nazwisko, int klasa, string kier)
        {
            Id = id;
            FirstName = imie;
            LastName = nazwisko;
            nr_klasy = klasa;
            kierunek = kier;
        }

        public View()
        {
            Id = 0;
            FirstName = "Jan";
            LastName = "Kowalski";
            nr_klasy = 123;
            kierunek = "Informatyka";
        }
    }
}
