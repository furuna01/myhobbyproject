using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace OseroGame
{
    class CreverseStone
    {
        OseroForm form = null;

        public CreverseStone(OseroForm form)
        {
            this.form = form;
        }

        public void ReverseStone(int x, int y, int fTeban, int[,] sellstatus, Boolean[] arrayflag, int[] stone_num)
        {
            //上方向に石をひっくり返す
            if (arrayflag[0])
            {
                for (int i = 1; i <= stone_num[0]; i++)
                {
                    if (fTeban == 1)
                    {
                        Thread.Sleep(CONST.REVERSE_INTERVAL);
                        form.DrawCircle(x, y - i, CONST.BLACK);
                        sellstatus[y - i, x] = 1;
                    }
                    else
                    {
                        Thread.Sleep(CONST.REVERSE_INTERVAL);
                        form.DrawCircle(x, y - i, CONST.WHITE);
                        sellstatus[y - i, x] = 0;
                    }
                }
            }
            if (arrayflag[1])
            {
                //右上方向に石をひっくり返す
                if (arrayflag[1])
                {
                    for (int i = 1; i <= stone_num[1]; i++)
                    {
                        if (fTeban == 1)
                        {
                            Thread.Sleep(CONST.REVERSE_INTERVAL);
                            form.DrawCircle(x + i, y - i, CONST.BLACK);
                            sellstatus[y - i, x + i] = 1;
                        }
                        else
                        {
                            Thread.Sleep(CONST.REVERSE_INTERVAL);
                            form.DrawCircle(x + i, y - i, CONST.WHITE);
                            sellstatus[y - i, x + i] = 0;
                        }
                    }
                }
            }
            if (arrayflag[2])
            {
                //石を右方向にひっくり返す
                if (arrayflag[2])
                {
                    for (int i = 1; i <= stone_num[2]; i++)
                    {
                        if (fTeban == 1)
                        {
                            Thread.Sleep(CONST.REVERSE_INTERVAL);
                            form.DrawCircle(x + i, y, CONST.BLACK);
                            sellstatus[y, x + i] = 1;
                        }
                        else
                        {
                            Thread.Sleep(CONST.REVERSE_INTERVAL);
                            form.DrawCircle(x + i, y, CONST.WHITE);
                            sellstatus[y, x + i] = 0;
                        }
                    }
                }
            }
            if (arrayflag[3])
            {
                //石を右下方向にひっくり返す
                if (arrayflag[3])
                {
                    for (int i = 1; i <= stone_num[3]; i++)
                    {
                        if (fTeban == 1)
                        {
                            Thread.Sleep(CONST.REVERSE_INTERVAL);
                            form.DrawCircle(x + i, y + i, CONST.BLACK);
                            sellstatus[y + i, x + i] = 1;
                        }
                        else
                        {
                            Thread.Sleep(CONST.REVERSE_INTERVAL);
                            form.DrawCircle(x + i, y + i, CONST.WHITE);
                            sellstatus[y + i, x + i] = 0;
                        }
                    }
                }
            }
            if (arrayflag[4])
            {
                //石を下方向にひっくり返す
                if (arrayflag[4])
                {
                    for (int i = 1; i <= stone_num[4]; i++)
                    {
                        if (fTeban == 1)
                        {
                            Thread.Sleep(CONST.REVERSE_INTERVAL);
                            form.DrawCircle(x, y + i, CONST.BLACK);
                            sellstatus[y + i, x] = 1;
                        }
                        else
                        {
                            Thread.Sleep(CONST.REVERSE_INTERVAL);
                            form.DrawCircle(x, y + i, CONST.WHITE);
                            sellstatus[y + i, x] = 0;
                        }
                    }
                }
            }
            if (arrayflag[5])
            {
                //石を左下方向にひっくり返す
                if (arrayflag[5])
                {
                    for (int i = 1; i <= stone_num[5]; i++)
                    {
                        if (fTeban == 1)
                        {
                            Thread.Sleep(CONST.REVERSE_INTERVAL);
                            form.DrawCircle(x - i, y + i, CONST.BLACK);
                            sellstatus[y + i, x - i] = 1;
                        }
                        else
                        {
                            Thread.Sleep(CONST.REVERSE_INTERVAL);
                            form.DrawCircle(x - i, y + i, CONST.WHITE);
                            sellstatus[y + i, x - i] = 0;
                        }
                    }
                }
            }
            if (arrayflag[6])
            {
                //石を左方向にひっくり返す
                if (arrayflag[6])
                {
                    for (int i = 1; i <= stone_num[6]; i++)
                    {
                        if (fTeban == 1)
                        {
                            Thread.Sleep(CONST.REVERSE_INTERVAL);
                            form.DrawCircle(x - i, y, CONST.BLACK);
                            sellstatus[y, x - i] = 1;
                        }
                        else
                        {
                            Thread.Sleep(CONST.REVERSE_INTERVAL);
                            form.DrawCircle(x - i, y, CONST.WHITE);
                            sellstatus[y, x - i] = 0;
                        }
                    }
                }
            }
            if (arrayflag[7])
            {
                //石を左上方向にひっくり返す
                if (arrayflag[7])
                {
                    for (int i = 1; i <= stone_num[7]; i++)
                    {
                        if (fTeban == 1)
                        {
                            Thread.Sleep(CONST.REVERSE_INTERVAL);
                            form.DrawCircle(x - i, y - i, CONST.BLACK);
                            sellstatus[y - i, x - i] = 1;
                        }
                        else
                        {
                            Thread.Sleep(CONST.REVERSE_INTERVAL);
                            form.DrawCircle(x - i, y - i, CONST.WHITE);
                            sellstatus[y - i, x - i] = 0;
                        }
                    }
                }
            }
        }
    }
}
