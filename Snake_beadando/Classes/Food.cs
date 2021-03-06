﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Snake_beadando
{
    //https://github.com/Hatbatamado/prog3_beadando
    class Food : Bindable
    {
        List<Rect> elemek;
        int top, bottom, left, right;

        public Food(Image img)
        {
            Elemek = new List<Rect>();
            //játéktér méretinek beállítása ahol random megjelennek a kaják
            top = 60;
            left = 40;
            bottom = (int)img.ActualHeight - 10;
            right = (int)img.ActualWidth - 10;
        }

        public void AddFood(Random R, Snake jatekos, Snake ellenseg)
        {
            Rect elem;
            //kaja hely kiválasztása ha egy játékos van azon a helyen újjal próbálkozunk
            bool ujra = false;
            do
            {
                elem = new Rect(R.Next(left, right), R.Next(top, bottom), 10, 10);
                bool tmp1 = Utkozes(jatekos, elem);
                bool tmp2 = Utkozes(ellenseg, elem);
                ujra = tmp1 && tmp2;
            } while (!ujra);

            if (elem != null)
            {
                Elemek.Add(elem);
                OPC("Elemek");
            }
        }

        private bool Utkozes(Snake elem, Rect mivel)
        {
            //ütközik-e egy játkos az új kajával
            int i = 0;
            while (i < elem.Elemek.Count && !mivel.IntersectsWith(elem.Elemek[i]))
                i++;
            if (i == elem.Elemek.Count)
                return true;

            return false;
        }

        public List<Rect> Elemek
        {
            get
            {
                return elemek;
            }

            set
            {
                elemek = value;
                OPC();
            }
        }
    }

    class Rocket : Food
    {
        public Rocket(Image img) : base(img) { }
    }
}
