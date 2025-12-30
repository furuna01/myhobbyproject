using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TetorisGame
{
    class CLoad_block
    {
        private int[,,] tetoris_mino1;
        private int[,,] tetoris_mino2;
        private int[,,] tetoris_mino3;
        private int[,,] tetoris_mino4;
        private int[,,] tetoris_mino5;
        private int[,,] tetoris_mino6;
        private int[,,] tetoris_mino7;

        public CLoad_block()
        {
            //■
            //■
            //■
            //■
            tetoris_mino1 = new int[4, 4, 4]
            {
                {
                    {1, 0, 0, 0 },
                    {1, 0, 0, 0 },
                    {1, 0, 0, 0 },
                    {1, 0, 0, 0 }
                },
                {
                    {1, 1, 1, 1},
                    {0, 0, 0, 0},
                    {0, 0, 0, 0},
                    {0, 0, 0, 0}
                },

                {
                    {1, 0, 0, 0 },
                    {1, 0, 0, 0 },
                    {1, 0, 0, 0 },
                    {1, 0, 0, 0 }
                },
                {
                    {1, 1, 1, 1},
                    {0, 0, 0, 0},
                    {0, 0, 0, 0},
                    {0, 0, 0, 0}
                }

            };

            //■■
            //■■
            tetoris_mino2 = new int[4, 4, 4]
            {
                {

                    { 1, 1, 0, 0},
                    { 1, 1, 0, 0},
                    { 0, 0, 0, 0 },
                    { 0, 0, 0, 0 }
                },
                {
                    { 1, 1, 0, 0 },
                    { 1, 1, 0, 0 },
                    { 0, 0, 0, 0 },
                    { 0, 0, 0, 0 }
                },
               {

                    { 1, 1, 0, 0},
                    { 1, 1, 0, 0},
                    { 0, 0, 0, 0 },
                    { 0, 0, 0, 0 }
                },
                {
                    { 1, 1, 0, 0 },
                    { 1, 1, 0, 0 },
                    { 0, 0, 0, 0 },
                    { 0, 0, 0, 0 }
                }
            };
            //　■■
            //■■
            tetoris_mino3 = new int[4, 4, 4]
            {
                {
                    { 0, 1, 1, 0 },
                    { 1, 1, 0, 0 },
                    { 0, 0, 0, 0 },
                    { 0, 0, 0, 0 }

                },
                {
                    { 1, 0, 0, 0 },
                    { 1, 1, 0, 0 },
                    { 0, 1, 0, 0 },
                    { 0, 0, 0, 0 }
                    
                },
                {
                    { 0, 1, 1, 0 },
                    { 1, 1, 0, 0 },
                    { 0, 0, 0, 0 },
                    { 0, 0, 0, 0 }

                },
                {
                    { 1, 0, 0, 0 },
                    { 1, 1, 0, 0 },
                    { 0, 1, 0, 0 },
                    { 0, 0, 0, 0 }

                }

            };
            //■■
            //　■■
            tetoris_mino4 = new int[4, 4, 4]
            {
                {
                    {1, 1, 0, 0 },
                    {0, 1, 1, 0 },
                    {0, 0, 0, 0 },
                    {0, 0, 0, 0 }
                },
                {
                    {0, 1, 0, 0 },
                    {1, 1, 0, 0 },
                    {1, 0, 0, 0 },
                    {0, 0, 0, 0 }
                },
                {
                    {1, 1, 0, 0 },
                    {0, 1, 1, 0 },
                    {0, 0, 0, 0 },
                    {0, 0, 0, 0 }
                },
                {
                    {0, 1, 0, 0 },
                    {1, 1, 0, 0 },
                    {1, 0, 0, 0 },
                    {0, 0, 0, 0 }
                },

            };
            //■
            //■■■
            tetoris_mino5 = new int[4, 4, 4]
            {
                {
                    {1, 0, 0, 0 },
                    {1, 1, 1, 0 },
                    {0, 0, 0, 0 },
                    {0, 0, 0, 0 }
                },
                {
                    {1, 1, 0, 0 },
                    {1, 0, 0, 0 },
                    {1, 0, 0, 0 },
                    {0, 0, 0, 0 }
                },
                {
                    {1, 1, 1, 0 },
                    {0, 0, 1, 0 },
                    {0, 0, 0, 0 },
                    {0, 0, 0, 0 }
                },
                {
                    {0, 1, 0, 0 },
                    {0, 1, 0, 0 },
                    {1, 1, 0, 0 },
                    {0, 0, 0, 0 }
                }
            };
            //    ■
            //■■■
            tetoris_mino6 = new int[4, 4, 4]
            {
                {
                    {0, 0, 1, 0 },
                    {1, 1, 1, 0 },
                    {0, 0, 0, 0 },
                    {0, 0, 0, 0 }
                },
                {
                    {1, 0, 0, 0 },
                    {1, 0, 0, 0 },
                    {1, 1, 0, 0 },
                    {0, 0, 0, 0 }
                },
                {
                    {1, 1, 1, 0 },
                    {1, 0, 0, 0 },
                    {0, 0, 0, 0 },
                    {0, 0, 0, 0 },
                },
                {
                    {1, 1, 0, 0 },
                    {0, 1, 0, 0 },
                    {0, 1, 0, 0 },
                    {0, 0, 0, 0 }
                }
            };
            //  ■
            //■■■
            tetoris_mino7 = new int[4, 4, 4]
            {
                {
                    {0, 1, 0, 0 },
                    {1, 1, 1, 0 },
                    {0, 0, 0, 0 },
                    {0, 0, 0, 0 }
                },
                {
                    {1, 0, 0, 0 },
                    {1, 1, 0, 0 },
                    {1, 0, 0, 0 },
                    {0, 0, 0, 0 }
                },
                {
                    {1, 1, 1, 0 },
                    {0, 1, 0, 0 },
                    {0, 0 ,0, 0 },
                    {0, 0, 0, 0 }
                },
                {
                    {0, 1, 0, 0 },
                    {1, 1, 0, 0 },
                    {0, 1, 0, 0 },
                    {0, 0, 0, 0 }
                }
            };
        }
        public int[,,] getTetorisMino1()
        {
            return this.tetoris_mino1;
        }
        public int[,,] getTetorisMino2()
        {
            return this.tetoris_mino2;
        }
        public int[,,] getTetorisMino3()
        {
            return this.tetoris_mino3;
        }
        public int[,,] getTetorisMino4()
        {
            return this.tetoris_mino4;
        }
        public int[,,] getTetorisMino5()
        {
            return this.tetoris_mino5;
        }
        public int[,,] getTetorisMino6()
        {
            return this.tetoris_mino6;
        }
        public int[,,] getTetorisMino7()
        {
            return this.tetoris_mino7;
        }
    }
}
