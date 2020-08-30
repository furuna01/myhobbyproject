using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TetorisGame
{
    public partial class TetorisForm : Form
    {
        private int[,] screen_status;
        public TetorisForm()
        {
            InitializeComponent();
        }

        private void TetorisForm_Load(object sender, EventArgs e)
        {
            screen_status = new int[CONST.BLOCK_NUM_HEIGHT, CONST.BLOCK_NUM_WIDTH];
            //画面の初期化
            for(int i = 0; i < CONST.BLOCK_NUM_HEIGHT; i ++)
            {
                for(int j = 0; j < CONST.BLOCK_NUM_WIDTH; j ++)
                {
                    screen_status[i, j] = CONST.NOTHING_STATUS;
                }
            }
            //ゲーム画面の初期化
            for(int i = 0; i < 2; i ++)
            {
                for(int j = 0; j < CONST.BLOCK_NUM_WIDTH; j ++)
                {
                    screen_status[i, j] = CONST.NOTHING_STATUS;
                }
            }
            //左側の壁の描写
            for(int i = 1; i < CONST.BLOCK_NUM_HEIGHT; i ++)
            {
                screen_status[i, 0] = CONST.WALL_STATUS;
                screen_status[i, CONST.BLOCK_NUM_WIDTH - 1] = CONST.WALL_STATUS;
            }

            //底の壁の描写
            for(int i = 1; i < CONST.BLOCK_NUM_WIDTH - 1; i ++)
            {
                screen_status[CONST.BLOCK_NUM_HEIGHT - 1, i] = CONST.WALL_STATUS;
            }
            //右側の壁の描写
            for(int i = 1; i < CONST.BLOCK_NUM_HEIGHT; i ++)
            {
                screen_status[i, CONST.BLOCK_NUM_WIDTH - 1] = CONST.WALL_STATUS;
            }
        }
        /*********************************************************************************
        * 機能
        * このイベントで壁を描写する
        * ******************************************************************************/
        private void TetorisForm_Paint(object sender, PaintEventArgs e)
        {
            CDrawFigure figure = new CDrawFigure();
            for(int i = 0; i < CONST.BLOCK_NUM_HEIGHT; i ++)
            {
                for(int j = 0; j < CONST.BLOCK_NUM_WIDTH; j ++)
                {
                    if (screen_status[i, j] == CONST.WALL_STATUS)
                    {
                        figure.DrawBlock(CONST.DISTANCE_TO_SCREEN_WIDTH + CONST.BLOCK_SIZE * j, CONST.DISTANCE_TO_SCREEN_HEIGHT + CONST.BLOCK_SIZE * i,
                            CONST.WALL_STATUS, e.Graphics);
                    }
                    else if (screen_status[i, j] == CONST.BLOCK_STATUS)
                    {
                        figure.DrawBlock(CONST.DISTANCE_TO_SCREEN_WIDTH + CONST.BLOCK_SIZE * j, CONST.DISTANCE_TO_SCREEN_HEIGHT + CONST.BLOCK_SIZE * i,
                            CONST.BLOCK_STATUS, e.Graphics);
                    }
                    else if(screen_status[i,j] == CONST.NOTHING_STATUS)
                    {
                        figure.DrawBlock(CONST.DISTANCE_TO_SCREEN_WIDTH + CONST.BLOCK_SIZE * j, CONST.DISTANCE_TO_SCREEN_HEIGHT + CONST.BLOCK_SIZE * i,
                            CONST.NOTHING_STATUS, e.Graphics);
                    }
                    else
                    {
                        MessageBox.Show("何か違うものが画面の状態の値に入っています");
                    }
                }
            }

        }
        
       
    }
}
