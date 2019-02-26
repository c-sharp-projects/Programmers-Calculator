using System;
using System.Windows;
using System.Windows.Controls;
using System.Reflection;
using System.IO;

namespace Programmer_Calc
{

    public partial class MainWindow : Window 
    {

        protected void BinaryButtonPressed()
        { 
           
            dot.IsEnabled = false;
            plus_or_minus.IsEnabled = false;

            A.IsEnabled = false;
            B.IsEnabled = false;
            C.IsEnabled = false;
            D.IsEnabled = false;
            E.IsEnabled = false;
            F.IsEnabled = false;

            two.IsEnabled = false;
            three.IsEnabled = false;
            four.IsEnabled = false;
            five.IsEnabled = false;
            six.IsEnabled = false;
            seven.IsEnabled = false;
            eight.IsEnabled = false;
            nine.IsEnabled = false;
            binary.IsEnabled = false;

            hexadecimal.IsEnabled = true;
            octal.IsEnabled = true;
            dec.IsEnabled = true;
            }

        
        protected void OctalButtonPressed()
        {
            dot.IsEnabled = false;
            plus_or_minus.IsEnabled = false;

            A.IsEnabled = false;
            B.IsEnabled = false;
            C.IsEnabled = false;
            D.IsEnabled = false;
            E.IsEnabled = false;
            F.IsEnabled = false;
            eight.IsEnabled = false;
            nine.IsEnabled = false;
            octal.IsEnabled = false;

            two.IsEnabled = true;
            three.IsEnabled = true;
            four.IsEnabled = true;
            five.IsEnabled = true;
            six.IsEnabled = true;
            seven.IsEnabled = true;

            binary.IsEnabled = true;
            hexadecimal.IsEnabled = true;
            dec.IsEnabled = true;

        }

        protected void HexadecimalButtonPressed() 
        {
            dot.IsEnabled = false;
            plus_or_minus.IsEnabled = false;

            A.IsEnabled = true;
            B.IsEnabled = true;
            C.IsEnabled = true;
            D.IsEnabled = true;
            E.IsEnabled = true;
            F.IsEnabled = true;
            two.IsEnabled = true;
            three.IsEnabled = true;
            four.IsEnabled = true;
            five.IsEnabled = true;
            six.IsEnabled = true;
            seven.IsEnabled = true;
            eight.IsEnabled = true;
            nine.IsEnabled = true;

            octal.IsEnabled = true;
            binary.IsEnabled = true;
            dec.IsEnabled = true;

            hexadecimal.IsEnabled = false;

        }

        public void DecimalButtonPressed()
        {
            dot.IsEnabled = false;
            plus_or_minus.IsEnabled = false;

            dec.IsEnabled = false;
            A.IsEnabled = false;
            B.IsEnabled = false;
            C.IsEnabled = false;
            D.IsEnabled = false;
            E.IsEnabled = false;
            F.IsEnabled = false;

            two.IsEnabled = true;
            three.IsEnabled = true;
            four.IsEnabled = true;
            five.IsEnabled = true;
            six.IsEnabled = true;
            seven.IsEnabled = true;
            eight.IsEnabled = true;
            nine.IsEnabled = true;

            octal.IsEnabled = true;
            binary.IsEnabled = true;
            hexadecimal.IsEnabled = true;

            dot.IsEnabled = true;
            plus_or_minus.IsEnabled = true;

        }

       

        //  protected virtual void Conversion(object sender, RoutedEventArgs e) { }
        // protected virtual void ActionListener(object sender, RoutedEventArgs e) { }
    }  
}

