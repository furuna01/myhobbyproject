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
        private CTetorisTimer Maintimer;
        public TetorisForm()
        {
            InitializeComponent();
        }

        private void TetorisForm_Load(object sender, EventArgs e)
        {
            screen_status = new int[CONST.WHOLE_SCREEN_SIZE_HEIGHT, CONST.WHOLE_SCREEN_SIZE_WIDTH];
            //画面の初期化
            for(int i = 0; i < CONST.WHOLE_SCREEN_SIZE_HEIGHT; i ++)
            {
                for(int j = 0; j < CONST.WHOLE_SCREEN_SIZE_WIDTH; j ++)
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
            Maintimer = new CTetorisTimer(screen_status, this);
            Maintimer.Run();
        }
        /*********************************************************************************
        * 機能
        * このイベントで壁を描写する
        * ******************************************************************************/
        private void TetorisForm_Paint(object sender, PaintEventArgs e)
        {
            CDrawFigure figure = new CDrawFigure();
            figure.DrawBlockOrWall(e.Graphics, screen_status);

        }
        public int[,] getScreenStatus()
        {
            return screen_status;
        }
        /******************************************************************************************
         * 機能
         * キーが押された時の処理、ミノを回転させる処理と、ミノを移動させる処理
         * ***************************************************************************************/
        private void TetorisForm_KeyDown(object sender, KeyEventArgs e)
        {
            //現在のミノの位置を取得
            int pos_x = Maintimer.getMinoPos_x();
            int pos_y = Maintimer.getMinoPos_y();
            int minoNo = Maintimer.getMinoNo();
            int direction = Maintimer.getDirection();
            int[,,] minoblock = Maintimer.getTetorisMino();
            int[,] screen_status = Maintimer.getScreenStatus();

            CchangeScreen screen = new CchangeScreen();
            CDrawFigure figure = new CDrawFigure();
            //右ノーが押されたとき
            if (e.KeyCode == Keys.Right)
            {
                //前の状態を消去
                screen.deleteScreen(pos_x, pos_y - 1, screen_status, minoblock, direction);
                //ミノを右に移動させる
                pos_x++;
                if(screen.checkBlockIsMove(pos_x, pos_y - 1, screen_status, minoblock, direction))
                {
                    //ミノが動かせるときにミノを移動させる
                    //新しい状態のミノを表示
                    screen.setScreen(pos_x, pos_y - 1, screen_status, minoblock, direction);
                    //物理的に描く
                    figure.DrawBlock(this.CreateGraphics(), screen_status);
                    Maintimer.setMinoPos_x(pos_x);
                    Maintimer.setMinoPos_y(pos_y);
                }

            }
            if(e.KeyCode == Keys.Down)
            {
                //ミノを下に移動させる
                //前の状態を消去
                screen.deleteScreen(pos_x, pos_y - 1, screen_status, minoblock, direction);
                //ミノを右に移動させる
                pos_y ++;
                if (screen.checkBlockIsMove(pos_x, pos_y - 1, screen_status, minoblock, direction))
                {
                    //ミノが動かせるときにミノを移動させる
                    //新しい状態のミノを表示
                    screen.setScreen(pos_x, pos_y - 1, screen_status, minoblock, direction);
                    //物理的に描く
                    figure.DrawBlock(this.CreateGraphics(), screen_status);
                    Maintimer.setMinoPos_x(pos_x);
                    Maintimer.setMinoPos_y(pos_y);
                }

            }
            if(e.KeyCode == Keys.Left)
            {
                //ミノを左に移動させる
                //前の状態を消去
                screen.deleteScreen(pos_x, pos_y - 1, screen_status, minoblock,direction);
                //ミノを右に移動させる
                pos_x --;
                if (screen.checkBlockIsMove(pos_x, pos_y - 1, screen_status, minoblock, direction))
                {
                    //ミノが動かせるときにミノを移動させる
                    //新しい状態のミノを表示
                    screen.setScreen(pos_x, pos_y - 1, screen_status, minoblock, direction);
                    //物理的に描く
                    figure.DrawBlock(this.CreateGraphics(), screen_status);
                    Maintimer.setMinoPos_x(pos_x);
                    Maintimer.setMinoPos_y(pos_y);
                }
            }
            if(e.KeyCode == Keys.L)
            {
                //ミノを右回転させる
            }
            if(e.KeyCode == Keys.J)
            {
                //ミノを左回転させる

            }

        }
    }
}
