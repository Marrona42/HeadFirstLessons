﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintBallGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PaintBallGun gun = new PaintBallGun();

            while (true)
            {
                Console.WriteLine($"{gun.Balls} balls, {gun.GetBallsLoaded()} loaded");
                if (gun.IsEmpty())
                {
                    Console.WriteLine("WARNING: you're out of ammo");
                }
                Console.WriteLine(("Space to shoot, r to reload, + to add ammo, q to quit"));
                char key = Console.ReadKey().KeyChar;

                if (key == ' ') Console.WriteLine($"Shooting returned {gun.Shoot()}");
                else if (key == 'r') gun.Reload();
                else if (key == '+') gun.Balls += PaintBallGun.MAGAZINE_SIZE;
                else if (key == 'q') return;
            }
        }
    }

    class PaintBallGun
    {
        public const int MAGAZINE_SIZE = 16;

        private int balls = 0;
        private int ballsLoaded = 0;

        public int GetBallsLoaded() { return ballsLoaded; }
        public bool IsEmpty() { return ballsLoaded == 0; }
        public int Balls
        {
            get { return balls; }
            set
            {
                if (value > 0)
                {
                    balls = value;
                }
                Reload();
            }
        }

        public void Reload()
        {
            if (balls > MAGAZINE_SIZE)
            {
                ballsLoaded = MAGAZINE_SIZE;
            }
            else
            {
                ballsLoaded = balls;
            }
        }

        public bool Shoot()
        {
            if (ballsLoaded == 0)
            {
                return false;
            }
            ballsLoaded--;
            balls--;
            return true;
        }
    }

}
