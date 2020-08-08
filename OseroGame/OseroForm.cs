using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace OseroGame
{
    public partial class OseroForm : Form
    {
        private int fTeban = 1;
        private int[,] sell_status = new int[CONST.MATH_NUM, CONST.MATH_NUM];
        public OseroForm()
        {
            InitializeComponent();
        }
        //初期表示
        private void OseroForm_Load(object sender, EventArgs e)
        {   
            //セルの初期化オセロのゲームの初めの状態
            for (int i = 0; i < CONST.MATH_NUM; i++)
            {
                for (int j = 0; j < CONST.MATH_NUM; j++)
                {
                    if (i == 3 && j == 3)
                    {
                        sell_status[i, j] = 0;
                    }
                    else if (i == 3 && j == 4)
                    {
                        sell_status[i, j] = 1;
                    }
                    else if (i == 4 && j == 3)
                    {
                        sell_status[i, j] = 1;
                    }
                    else if (i == 4 && j == 4)
                    {
                        sell_status[i, j] = 0;
                    }
                    else
                    {
                        sell_status[i, j] = -1;
                    }
                }
            }
        }
        override protected void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = this.CreateGraphics();
            graphics.FillRectangle(
                new SolidBrush(Color.Green),
                CONST.FIRST_WIDTH, CONST.FIRST_HIGHT, CONST.FILED_WIDTH, CONST.FILED_HEIGHT
            );
            //横の線を描く
            for (int i = 0; i < CONST.MATH_NUM + 1; i++)
            {
                graphics.DrawLine(Pens.Black, CONST.FIRST_WIDTH,
                    CONST.FIRST_HIGHT + i * CONST.ONE_BLOCK_HEIGHT,
                    CONST.FIRST_WIDTH + CONST.FILED_WIDTH,
                    CONST.FIRST_WIDTH + i * CONST.ONE_BLOCK_WIDTH);

            }
            //縦の線を描く
            for (int i = 0; i < CONST.MATH_NUM + 1; i++)
            {
                graphics.DrawLine(Pens.Black, CONST.FIRST_WIDTH + i * CONST.ONE_BLOCK_WIDTH,
                   CONST.FIRST_HIGHT, CONST.FIRST_WIDTH + i * CONST.ONE_BLOCK_WIDTH,
                   CONST.FIRST_HIGHT + CONST.FILED_HEIGHT);
            }

            //石を描く
            for (int i = 0; i < CONST.MATH_NUM; i++)
            {
                for (int j = 0; j < CONST.MATH_NUM; j++)
                {
                    if (sell_status[i, j] == CONST.WHITE)
                    {
                        DrawCircle(j, i, CONST.WHITE);
                    }
                    else if (sell_status[i, j] == CONST.BLACK)
                    {
                        DrawCircle(j, i, CONST.BLACK);
                    }

                }
            }

        }

        /*g.FillEllipse(new SolidBrush(Color.Black), 
            CONST.FIRST_WIDTH + 2 * CONST.ONE_BLOCK_WIDTH, 
            CONST.FIRST_HIGHT + 2 * CONST.ONE_BLOCK_HIGHT,
            CONST.CIRCLE_SIZE, CONST.CIRCLE_SIZE);*/

        //オセロの石を描く
        private void ShowScreen(Graphics g, int x, int y)
        {
            for (int i = 0; i < CONST.MATH_NUM; i++)
            {
                for (int j = 0; j < CONST.MATH_NUM; j++)
                {
                    if (sell_status[i, j] == CONST.WHITE)
                    {
                        this.DrawCircle(i - 1, j - 1, CONST.WHITE);
                    } else if (sell_status[i, j] == CONST.BLACK) {
                        this.DrawCircle(i - 1, j - 1, CONST.BLACK);
                    }

                }
            }
        }
        //石を描く
        public void DrawCircle(int x, int y, int flag)
        {
            Graphics graphics = this.CreateGraphics();
            graphics = this.CreateGraphics();
            if (flag == CONST.WHITE)
            {
                graphics.FillEllipse(new SolidBrush(Color.White),
                CONST.FIRST_WIDTH + x * CONST.ONE_BLOCK_WIDTH,
                CONST.FIRST_HIGHT + y * CONST.ONE_BLOCK_HEIGHT,
                CONST.CIRCLE_SIZE, CONST.CIRCLE_SIZE);
            }
            else if (flag == CONST.BLACK)
            {
                graphics.FillEllipse(new SolidBrush(Color.Black),
                CONST.FIRST_WIDTH + x * CONST.ONE_BLOCK_WIDTH,
                CONST.FIRST_HIGHT + y * CONST.ONE_BLOCK_HEIGHT,
                CONST.CIRCLE_SIZE, CONST.CIRCLE_SIZE);
            }

        }
        //先手ボタンが押されたら人間が先にプレーを開始
        private void SenteBtn_Click(object sender, EventArgs e)
        {
            fTeban = 1;
        }
        //後手を押されたら先にコンピュータが考える
        private void KouteBtn_Click(object sender, EventArgs e)
        {
            fTeban = 0;
        }
        //クリックされた場所を検知して、対象ないであれば、石をひっくり返す
        private void OseroForm_MouseClick(object sender, MouseEventArgs e)
        {
            CreverseStone stone = new CreverseStone(this);
            for (int i = 0; i < CONST.MATH_NUM; i++)
            {
                for (int j = 0; j < CONST.MATH_NUM; j++) {
                    //MessageBox.Show(i.ToString() + "," + j.ToString());
                    if (CONST.FIRST_HIGHT + CONST.ONE_BLOCK_HEIGHT * i < e.Y &&
                        CONST.FIRST_HIGHT + CONST.ONE_BLOCK_HEIGHT * i + CONST.ONE_BLOCK_HEIGHT > e.Y &&
                        CONST.FIRST_WIDTH + CONST.ONE_BLOCK_WIDTH * j < e.X &&
                        CONST.FIRST_WIDTH + CONST.ONE_BLOCK_WIDTH * j + CONST.ONE_BLOCK_WIDTH> e.X)
                    {
                        //石が置けるかどうか判定する
                        CcheckabletoPut able = new CcheckabletoPut();
                        int[] array_count_num = new int[CONST.DIRECTION_NUMBER];

                        for(int k = 0; k < CONST.DIRECTION_NUMBER; k ++)
                        {
                            array_count_num[k] = 0;
                        }
                        Boolean[] arrayflag = able.CountAbletoPut(i, j, fTeban, sell_status, array_count_num);
                        
                        //裏返せるかどうか判定するして、裏返せるなら裏返す
                        if(able.CheckAbleToPut(arrayflag))
                        {
                            //石を裏返す
                            stone = new CreverseStone(this);
                            if(fTeban == 1)
                            {
                                this.DrawCircle(j, i, CONST.BLACK);
                                sell_status[i, j] = CONST.BLACK;
                            }
                            else
                            {
                                this.DrawCircle(j, i, CONST.WHITE);
                                sell_status[i, j] = CONST.WHITE;
                            }
                            stone.ReverseStone(j, i, fTeban, sell_status, arrayflag, array_count_num);
                        }else
                        {
                            return;
                        }
                    }
                }
            }
            CControlGame control = new CControlGame();
            if(control.showGameResult(sell_status, fTeban))
            {
                return;
            }
            fTeban = (fTeban + 1) % 2;
            //コンピュータの考える番
            Thread.Sleep(CONST.REVERSE_INTERVAL);
            CcheckabletoPut able2 = new CcheckabletoPut();
            
            int[] count_num = new int[CONST.DIRECTION_NUMBER];
            for(int i = 0; i < CONST.DIRECTION_NUMBER; ++i)
            {
                count_num[i] = 0;
            }
            Boolean[] outflag = new bool[CONST.DIRECTION_NUMBER];
            for (int i = 0; i < CONST.DIRECTION_NUMBER; ++i)
            {
                outflag[i] = false;
            }
            //四隅のひっくり返せる数を取得する
            int pos_x = 0;
            int pos_y = 0;
            int max_num = 0;
            max_num = able2.ChekcYonsumiIsAvaiable(fTeban, sell_status, count_num, outflag, ref pos_x, ref pos_y);
            
            //端の石をひっくり返せるか調べる
            if(max_num > 0)
            {
                if(fTeban == 1)
                {
                    DrawCircle(pos_y, pos_x, CONST.BLACK);
                }else
                {
                    DrawCircle(pos_y, pos_x, CONST.WHITE);
                }
                stone.ReverseStone(pos_y, pos_x, fTeban, sell_status, outflag, count_num);
                fTeban = (fTeban + 1) % 2;
                return;
            }


            //4隅以外にひっくり返せる石を調べる
            count_num = new int[CONST.DIRECTION_NUMBER];
            for (int i = 0; i < CONST.DIRECTION_NUMBER; ++i)
            {
                count_num[i] = 0;
            }
            
            outflag = new bool[CONST.DIRECTION_NUMBER];
            for (int i = 0; i < CONST.DIRECTION_NUMBER; ++i)
            {
                outflag[i] = false;
            }
            pos_x = 0;
            pos_y = 0;
            max_num = able2.CountCenterAbaiable(fTeban, sell_status, count_num, outflag, ref pos_x, ref pos_y);
            if(max_num > 0)
            {
                if (fTeban == 1)
                {
                    DrawCircle(pos_y, pos_x, CONST.BLACK);
                    sell_status[pos_x, pos_y] = CONST.BLACK;
                }
                else
                {
                    DrawCircle(pos_y, pos_x, CONST.WHITE);
                    sell_status[pos_x, pos_y] = CONST.WHITE;
                }
                stone.ReverseStone(pos_y, pos_x, fTeban, sell_status, outflag, count_num);
            }
            if(control.showGameResult(sell_status, fTeban))
            {
                return;
            }
            fTeban = (fTeban + 1) % 2;
        }
    }
}
