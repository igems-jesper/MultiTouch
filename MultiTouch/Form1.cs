using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiTouch
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case Win32.WM_POINTERDOWN:
                case Win32.WM_POINTERUP:
                case Win32.WM_POINTERUPDATE:
                case Win32.WM_POINTERCAPTURECHANGED:
                    break;

                default:
                    base.WndProc(ref m);
                    return;
            }


            int pointerID = Win32.GET_POINTER_ID(m.WParam);
            Win32.POINTER_INFO pi = new Win32.POINTER_INFO();

            if (!Win32.GetPointerInfo(pointerID, ref pi))
            {
                Win32.CheckLastError();
            }

            Point pt = PointToClient(pi.PtPixelLocation.ToPoint());
            MouseEventArgs me = new MouseEventArgs(MouseButtons.Left, 1, pt.X, pt.Y, 0);

            switch (m.Msg)
            {
                case Win32.WM_POINTERDOWN:
                    textBox1.AppendText("Pointer down" + pt + "\n");
                    //(Parent as Jogo).Form1_MouseDown((this as object), me);
                    break;

                case Win32.WM_POINTERUP:
                    textBox1.AppendText("Pointer up" + pt + "\n");
                    //(Parent as Jogo).Form1_MouseUp((this as object), me);
                    break;

                case Win32.WM_POINTERUPDATE:
                    textBox1.AppendText("Pointer update" + pt + "\n");
                    //(Parent as Jogo).Form1_MouseMove((this as object), me);
                    break;
            }
        }
    }
}
