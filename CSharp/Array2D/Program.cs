using System;

namespace Array2D
{
    internal class Program
    {
        class Player
        {
            private int _x, _y;
            

            // this 키워드
            // 객체 자기자신 참조 키워드
            public void SetPos(int x, int y) //이걸 스택영역에 쌓으려면 코드영역에 있는 SetPos를 복제해서 스택영역에 쌓는것이다.
            {
                this._x = x;
                this._y = y;
                Program.map[y, x] = 5;
                Program.DisplayMap();
            }

            public void MoveDown()
            {
                //움직이면 맵의 경계를 벗어나는지 체크
                if (_y > map.GetLength(0) -1)
                {
                    return;
                }
                // 지나갈 수 없는 벽인지 체크
                if (map[_y+1, _x] == 1)
                {
                    return;
                }
                    SetPos(_x, _y + 1);
            }

            public void MoveUp()
            {
                //움직이면 맵의 경계를 벗어나는지 체크
                if (_y <= 0)
                {
                    return;
                }
                // 지나갈 수 없는 벽인지 체크
                if (map[_y - 1, _x ] == 1)
                {
                    return;
                }
                SetPos(_x, _y - 1);
            }

            public void MoveRight()
            {
                //움직이면 맵의 경계를 벗어나는지 체크
                if (_y >= map.GetLength(1) - 1)
                {
                    return;
                }
                // 지나갈 수 없는 벽인지 체크
                if (map[_y , _x + 1] == 1)
                {
                    return;
                }
                SetPos(_x + 1, _y);
            }

            public void MoveLeft()
            {
                //움직이면 맵의 경계를 벗어나는지 체크
                if (_x <= 0)
                {
                    return;
                }
                // 지나갈 수 없는 벽인지 체크
                if (map[_y, _x -1] == 1)
                {
                    return;
                }
                SetPos(_x - 1, _y);
            }

            public void update()
            {
                DisplayMap();
            }
        }


        // 0 : 지나갈 수 있는 길
        // 1 : 지나갈 수 없는 벽
        // 2 : 도착지점
        // 5 : 플레이어
        static int[,] map = new int[5, 5]
        {
            {0,1,1,1,1 },
            {0,1,1,1,1 },
            {0,0,0,1,1 },
            {1,1,0,1,1 },
            {1,1,0,0,2 },
        };

        static void Main(string[] args)
        {
            Player player = new Player();
            player.SetPos(0, 0);


            int move_x = 0, move_y = 0;

            while (true)
            {
                Console.WriteLine("Enter a number Pos 'a', 's', 'd', 'w' : ");
                char move = char.Parse(Console.ReadLine());
                Console.WriteLine("You entered : ", move);

                if(move == 'a')
                {
                    move_x--;
                    map[move_y, move_x] = 5;
                    
                }
                else if(move == 's')
                {
                    move_y++;
                    map[move_y, move_x] = 5;
                }
                else if (move == 'd')
                {
                    move_x++;
                    map[move_y, move_x] = 5;
                }
                else if (move == 'w')
                {
                    move_y--;
                    map[move_y, move_x] = 5;
                }
                else
                {
                    Console.WriteLine("Nothing");
                }
                DisplayMap();
            }


        }

        static void DisplayMap()
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == 0)
                        Console.Write("□");
                    else if (map[i, j] == 1)
                        Console.Write("■");
                    else if (map[i, j] == 2)
                        Console.Write("☆");
                    else if (map[i, j] == 5)
                        Console.Write("▣");
                }
                Console.WriteLine();
            }
        }
    }
}
