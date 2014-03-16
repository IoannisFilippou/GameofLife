using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        int[,] p1 = new int[200, 200];     //2D array
        int[,] p2 = new int[200, 200];
        int sum = 0;

        public Form1()
        {
            InitializeComponent();
            start();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
        }

        private void start()   
        {
            int y = 0;
            int x = 0;
            while (x < 100)
            {
                while (y < 100)
                {
                    p1[x, y] = 0;
                    p2[x, y] = 0;
                    y++;
                }
                y = 0;
                x++;
            }
            x = 0;
            y = 0;
            
        }


        private void copy()
        {
            int y = 0;
            int x = 0;
            while (x < 100)
            {
                while (y < 100)
                {
                    p1[x, y] = p2[x, y];
                    y++;
                }
                y = 0;
                x++;
            }
            x = 0;
            y = 0;
            Refresh();
           
        }




        private void newgeneration()
        {
            int y = 0;
            int x = 0;
            while (x < 100)
            {
                while (y < 100)
                {
                    if ((y == 0) && (x == 0))   // Calculate top left square 
                    {
                        if (p1[x + 1, y] + p1[x + 1, y + 1] + p1[x, y + 1] == 3)
                        {
                            p2[x, y] = 1;
                        }
                        else
                        {
                            p2[x, y] = 0;
                        }
                    }

                    if ((y == 0) && (x == 100))   // Calculate top right square 
                    {
                        if (p1[x - 1, y] + p1[x - 1, y + 1] + p1[x, y + 1] == 3)
                        {
                            p2[x, y] = 1;
                        }
                        else
                        {
                            p2[x, y] = 0;
                        }
                    }

                    if ((y == 100) && (x == 0))   // Calculate bottom left square 
                    {
                        if (p1[x, y - 1] + p1[x + 1, y - 1] + p1[x + 1, y] == 3)
                        {
                            p2[x, y] = 1;
                        }
                        else
                        {
                            p2[x, y] = 0;
                        }
                    }

                    if ((y == 100) && (x == 100)) // Calculate bottom right square 
                    {
                        if (p1[x, y - 1] + p1[x - 1, y - 1] + p1[x - 1, y] == 3)
                        {
                            p2[x, y] = 1;
                        }
                        else
                        {
                            p2[x, y] = 0;
                        }
                    }

                    if ((y == 0) && (x > 0) && (x < 100)) //Calculate top middle square 
                    {
                        //int sum = 0;
                        sum = p1[x - 1, y] + p1[x - 1, y + 1] + p1[x, y + 1] + p1[x + 1, y + 1] + p1[x + 1, y];

                        if ((p1[x, y] == 0) && (sum == 3))
                        {
                            p2[x, y] = 1;
                        }

                        if ((p1[x, y] == 1) && (sum <= 1))
                        {
                            p2[x, y] = 0;
                        }

                        if ((p1[x, y] == 1) && (sum >= 4))
                        {
                            p2[x, y] = 0;
                        }

                        if ((p1[x, y] == 1) && ((sum >= 2) && (sum <= 3)))
                        {
                            p2[x, y] = 1;
                        }

                        sum = 0;
                    }

                    if ((x == 0) && (y != 0) && (y != 100)) //Calculate left middle square 
                    {
                        //int sum = 0;
                        sum = p1[x, y - 1] + p1[x + 1, y - 1] + p1[x + 1, y] + p1[x + 1, y + 1] + p1[x, y + 1] + 1;

                        if ((p1[x, y] == 0) && (sum == 3))
                        {
                            p2[x, y] = 1;
                        }

                        if ((p1[x, y] == 1) && (sum <= 1))
                        {
                            p2[x, y] = 0;
                        }

                        if ((p1[x, y] == 1) && (sum >= 4))
                        {
                            p2[x, y] = 0;
                        }

                        if ((p1[x, y] == 1) && ((sum >= 2) && (sum <= 3)))
                        {
                            p2[x, y] = 1;
                        }

                        sum = 0;
                    }

                    if ((x == 100) && (y != 0) && (y != 100)) //Calculate middle right square 
                    {
                        //int sum = 0;
                        sum = p1[x, y - 1] + p1[x - 1, y - 1] + p1[x - 1, y] + p1[x - 1, y + 1] + p1[x, y + 1];

                        if ((p1[x, y] == 0) && (sum == 3))
                        {
                            p2[x, y] = 1;
                        }

                        if ((p1[x, y] == 1) && (sum <= 1))
                        {
                            p2[x, y] = 0;
                        }

                        if ((p1[x, y] == 1) && (sum >= 4))
                        {
                            p2[x, y] = 0;
                        }

                        if ((p1[x, y] == 1) && ((sum >= 2) && (sum <= 3)))
                        {
                            p2[x, y] = 1;
                        }

                        sum = 0;
                    }

                    if ((y == 100) && (x != 0) && (x != 100)) //Calculate middle bottom square 
                    {
                        //int sum = 0;
                        sum = p1[x - 1, y] + p1[x - 1, y - 1] + p1[x, y - 1] + p1[x + 1, y - 1] + p1[x + 1, y];

                        if ((p1[x, y] == 0) && (sum == 3))
                        {
                            p2[x, y] = 1;
                        }

                        if ((p1[x, y] == 1) && (sum <= 1))
                        {
                            p2[x, y] = 0;
                        }

                        if ((p1[x, y] == 1) && (sum >= 4))
                        {
                            p2[x, y] = 0;
                        }

                        if ((p1[x, y] == 1) && ((sum >= 2) && (sum <= 3)))
                        {
                            p2[x, y] = 1;
                        }

                        sum = 0;
                    }

                    if ((x != 0) && (y != 0) && (x != 100) && (y != 100)) //Calculate middle square
                    {
                        //int sum = 0;
                        sum = p1[x - 1, y - 1] + p1[x, y - 1] + p1[x + 1, y - 1] + p1[x - 1, y] + p1[x + 1, y] + p1[x - 1, y + 1] + p1[x, y + 1] + p1[x + 1, y + 1];

                        if ((p1[x, y] == 0) && (sum == 3))
                        {
                            p2[x, y] = 1;
                        }

                        if ((p1[x, y] == 1) && (sum <= 1))
                        {
                            p2[x, y] = 0;
                        }

                        if ((p1[x, y] == 1) && (sum >= 4))
                        {
                            p2[x, y] = 0;
                        }

                        if ((p1[x, y] == 1) && ((sum >= 2) && (sum <= 3)))
                        {
                            p2[x, y] = 1;
                        }

                        sum = 0;
                    }

                    y++;
                }
                y = 0;
                x++;
            }
            x = 0;
            y = 0;
            copy();
            
        }
        
        private void pictureBox1_Paint(object sender, PaintEventArgs e)   
        {
            Graphics g = e.Graphics;

            int y = 0; int x = 0;
           

            

            while (y < 100)
            {
                while (x < 100)
                {
                    if (p1[x, y] == 1)
                    {
                        Brush paint = new SolidBrush(Color.Black);  //Brush color of selected square
                        g.FillRectangle(paint, x * 20 + 20, y * 20 + 20, 15, 15);

                    }
                    else
                    {
                        Brush paint = new SolidBrush(Color.White); //Brush color of unselected square
                        g.FillRectangle(paint, x * 20 + 20, y * 20 + 20, 15, 15);
                    }

                    

                    x++;
                }
                x = 0;
                y++;
            }
            x = 0;
            y = 0;

           


        }


        int starts = 0;
        private void button1_Click(object sender, EventArgs e) //start button
        {
            if (starts == 1)
            {
                starts = 0;
            }
            else
            {
                starts = 1;
            }
        }

        private void timer1_Tick(object sender, EventArgs e) //Timer
        {
            if (starts == 1)
            {
                newgeneration();
            }
            else { Refresh(); }
        }



        int click = 0;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e) 
        {
            click = 1; //value when the mouse is down

            int xe = e.X;
            int ye = e.Y;
            p1[(xe - 20) / 20, (ye - 20) / 20] = 1;
            p2[(xe - 20) / 20, (ye - 20) / 20] = 1;
        }

        private void button2_Click(object sender, EventArgs e) //clear button
        {
            start();
            starts = 0;

            
                timer1.Start();
        
           
           

        }

        private void button3_Click(object sender, EventArgs e)  //stop button
        {
          
                


            timer1.Stop();
             
            
        }

        private void button4_Click(object sender, EventArgs e) //resume button
        {
            

          timer1.Start();
            
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e) // draw while the mouse is down
        {
            int c1 = e.X;
            int c2 = e.Y;

            if (c1 < 500 && c1 > 20 && c2 < 500 && c2 > 20 && click == 1)
            {
                if (e.Button == MouseButtons.Right) 
                {
                    p1[(c1 - 20) / 20, (c2 - 20) / 20] = 0;
                    p2[(c1 - 20) / 20, (c2 - 20) / 20] = 0;
                }
                else    
                {
                    p1[(c1 - 20) / 20, (c2 - 20) / 20] = 1;
                    p2[(c1 - 20) / 20, (c2 - 20) / 20] = 1;
                }
            }





        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e) //value when the mouse is up
        {
            click = 0;
        }

        

        




        






        
    }
}
