using System;
using System.Collections;
using System.Collections.Generic;

namespace 享元模式
{

    //共享对象
    public abstract class AbstractEnemy
    {
        public string Color { set; get; }

        public int x;
        public int y;

        public AbstractEnemy()
        {
            Color = "红色";
        }

        public override string ToString()
        {
            return $"generate {Color} Enemy ,located in ({x},{y})";
        }
    }

    public class Enemy : AbstractEnemy
    {
        public Enemy(int y)
        {
            this.y = y;
        }
    }

    public class FactoryEnemy
    {
        private readonly Hashtable  _enemyList;

        public FactoryEnemy()
        {
            _enemyList = new Hashtable {{1, new Enemy(100)}, {2, new Enemy(200)}};

        }

        public Enemy GetEnemy(int num)
        {
            return _enemyList[num] as Enemy;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var factoryEnemy = new FactoryEnemy();
            var enemy = factoryEnemy.GetEnemy(1);
            Console.WriteLine(enemy);
            var enemy1 = factoryEnemy.GetEnemy(2);
            Console.WriteLine(enemy1);
        }
    }
}
