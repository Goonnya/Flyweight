using System;
using System.Collections.Generic;

namespace Flyweight
{
    class Program
    {
        static void Main(string[] args)
        {
            // переменные 
            var alphavite = new[]
            {
                'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ж', 'З',
                'И', 'Й', 'К',(char)106,
            };
            var alphavite1 = new[]
            {
                'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ж', 'З',
                'И', 'Й', 'К',(char)106,
            };
            double longitude = 2;
            double longitude1 = 2;
            double longitude2 = 2;

            ShipFactory shipFactory = new ShipFactory();
            for (int i = 0; i < 4; i++)
            {
                Ship1 singleShip = shipFactory.GetShip1("Single");
                if (singleShip != null)
                    singleShip.Build1(longitude, alphavite[i+5]);
                longitude += 2;
            }

            for (int i = 0; i < 3; i++)
            {
                Ship doubleShip = shipFactory.GetShip("Double");
                if (doubleShip != null)
                    doubleShip.Build(longitude1, alphavite[i+2], longitude2, alphavite1[i+3]);
                longitude1 += 2;
                longitude2 += 2;
            }

            Console.Read();
        }
    }

    abstract class Ship1
    {
        protected int stages;

        public abstract void Build1(double longitude, char alphavite);
    }
    abstract class Ship
    {
        protected int stages; 

        public abstract void Build(double longitude, char alphavite, double longitude1, char alphavite1);
    }

    class SingleShip : Ship1
    {
        public SingleShip()
        {
            stages = 1;
        }

        public override void Build1(double longitude, char alphavite)
        {
            Console.WriteLine("Однопалубный корабль помещён на координаты: ({0}; {1})",
                alphavite, longitude);
        }
    }
    class DoubleShip : Ship
    {
        public DoubleShip()
        {
            stages = 2;
        }

        public override void Build(double longitude, char alphavite, double longitude1, char alphavite1)
        {
            Console.WriteLine("Двупалубный корабль помещён на координаты: ({0}; {1}) и ({2}; {3})", 
                alphavite, longitude, alphavite1, longitude1);
        }
    }

    class ShipFactory
    {
        Dictionary<string, Ship1> ships1 = new Dictionary<string, Ship1>();
        Dictionary<string, Ship> ships = new Dictionary<string, Ship>();
        public ShipFactory()
        {
            ships1.Add("Single", new SingleShip());
            ships.Add("Double", new DoubleShip());
        }

        public Ship GetShip(string key)
        {
            if (ships.ContainsKey(key))
                return ships[key];
            else
                return null;
        }
        public Ship1 GetShip1(string key)
        {
            if (ships1.ContainsKey(key))
                return ships1[key];
            else
                return null;
        }
    }
}