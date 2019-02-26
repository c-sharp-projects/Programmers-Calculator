using System;
using System.Reflection;
using System.IO;
using System.Windows.Controls;
using System.Windows;


namespace Programmer_Calc
{
    public partial class MainWindow : Window
    {
        private String value1;
        private int flag;
        private char op;
        Assembly DLL;

        public MainWindow() 
        {
            InitializeComponent();

            A.IsEnabled = false;
            B.IsEnabled = false;
            C.IsEnabled = false;
            D.IsEnabled = false;
            E.IsEnabled = false;
            F.IsEnabled = false;
            dec.IsEnabled = false;

            flag = 1;
            value1 = "0";
            op = '\0';
            DLL = Assembly.LoadFile(Path.GetFullPath("Calc.dll"));
        }

        public void Conversion(object sender, RoutedEventArgs e)
        {
            if (ChkError())
            {
                return;
            }

            Button btn = (Button)sender;
            Type[] types = DLL.GetTypes();
            object[] args = { textbox1.Text, flag };

            foreach (Type typ in types)
            {
                if (typ.ToString().Equals("NumberSystem"))
                {
                    object obj = Activator.CreateInstance(typ);

                    MethodInfo mi = typ.GetMethod(btn.Content.ToString());

                    switch (btn.Content.ToString())
                    {
                        case "Binary":

                            BinaryButtonPressed();
                            textbox1.Text = mi.Invoke(obj, args).ToString();

                            flag = 2;
                            break;

                        case "Octal":

                            OctalButtonPressed();
                            textbox1.Text = mi.Invoke(obj, args).ToString();

                            flag = 3;
                            break;

                        case "Hexadecimal":

                            HexadecimalButtonPressed();
                            textbox1.Text = mi.Invoke(obj, args).ToString();

                            flag = 4;
                            break;

                        case "Decimal":

                            DecimalButtonPressed();
                            textbox1.Text = mi.Invoke(obj, args).ToString();

                            flag = 1;
                            break;
                    }
                }
            }
        }


        public void ActionListener(object sender, RoutedEventArgs e) // This function does all the arithmatic and logical operation 
        {
            Button btn = (Button)sender;

            String value2 = "0";

            float result = 0.0f;

            switch (btn.Uid)
            {
                case "+":
                    value1 = textbox1.Text;
                    op = '+';
                    textbox1.Text = "";
                    break;
                case "*":
                    value1 = textbox1.Text;
                    op = '*';
                    textbox1.Text = "";
                    break;
                case "/":
                    value1 = textbox1.Text;
                    op = '/';
                    textbox1.Text = "";
                    break;
                case "-":
                    value1 = textbox1.Text;
                    op = '-';
                    textbox1.Text = "";
                    break;
                case "%":
                    value1 = textbox1.Text;
                    op = '%';
                    textbox1.Text = "";
                    break;
                case "+/-":
                    value1 = textbox1.Text;
                    value1 = (float.Parse(value1) * -1).ToString();
                    textbox1.Text = value1;
                    break;

                case "^":
                    value1 = textbox1.Text;
                    op = '^';
                    textbox1.Text = "";
                    break;
                case "Lsh":
                    value1 = textbox1.Text;
                    op = 'L';
                    textbox1.Text = "";
                    break;
                case "Rsh":
                    value1 = textbox1.Text;
                    op = 'R';
                    textbox1.Text = "";
                    break;
                case "OR":
                    value1 = textbox1.Text;
                    op = 'O';
                    textbox1.Text = "";
                    break;
                case "AND":
                    value1 = textbox1.Text;
                    op = 'A';
                    textbox1.Text = "";
                    break;
                case "XOR":
                    value1 = textbox1.Text;
                    op = 'X';
                    textbox1.Text = "";
                    break;
                case "NOT":
                    result = ~(Convert.ToInt32(textbox1.Text));
                    textbox1.Text = result.ToString();
                    break;

                case "Clr":
                    textbox1.Text = "0";
                    value1 = "0";
                    value2 = "0";
                    op = '\0';
                    break;
                case "=":
                    value2 = textbox1.Text;

                    if (ChkError(value1,value2))
                    {
                        return;
                    }

                    ToDecimal(ref value1, ref value2);

                    switch (op)
                    {
                        case '+':
                            result = float.Parse(value1) + float.Parse(value2);
                            break;
                        case '-':
                            result = float.Parse(value1) - float.Parse(value2);
                            break;
                        case '*':
                            result = float.Parse(value1) * float.Parse(value2);
                            break;
                        case '/':
                            result = float.Parse(value1) / float.Parse(value2); ;
                            break;
                        case '%':
                            result = float.Parse(value1) % float.Parse(value2); ;
                            break;
                        case '^':
                            float val1 = float.Parse(value1);
                            int val2 = Convert.ToInt32(value2);
                            while (val2 > 1)
                            {
                                val1 *= val1;
                                val2--;
                            }
                            result = val1;
                            break;

                        case 'L':
                            if (IsFloat(value1) || IsFloat(value2))
                            {
                                ErrorMessage("BitwiseErr", 1);

                                return;
                            }
                            result = Convert.ToInt32(value1) << Convert.ToInt32(value2);
                            break;
                        case 'R':
                            if (IsFloat(value1) || IsFloat(value2))
                            {
                                ErrorMessage("BitwiseErr", 2);
                                return;
                            }
                            result = Convert.ToInt32(value1) >> Convert.ToInt32(value2);
                            break;
                        case 'O':
                            if (IsFloat(value1) || IsFloat(value2))
                            {
                                ErrorMessage("BitwiseErr", 3);
                                return;
                            }
                            result = Convert.ToInt32(value1) | Convert.ToInt32(value2);
                            break;
                        case 'A':
                            if (IsFloat(value1) || IsFloat(value2))
                            {
                                ErrorMessage("BitwiseErr", 4);
                                return;
                            }
                            result = Convert.ToInt32(value1) & Convert.ToInt32(value2);
                            break;
                        case 'X':
                            if (IsFloat(value1) || IsFloat(value2))
                            {
                                ErrorMessage("BitwiseErr", 5);
                                return;
                            }
                            result = Convert.ToInt32(value1) ^ Convert.ToInt32(value2);
                            break;
                        case '\0':
                            result = Convert.ToInt32(textbox1.Text);
                            break;

                        default:
                            textbox1.Text = value1.ToString();
                            break;
                    }


                    textbox1.Text = ToText(result);
                    break;

                default:
                    textbox1.Text += btn.Content.ToString();
                    break;

            }
        }

        private bool IsFloat(String Text)
        {
            bool bRet = false;

            foreach (char c in Text)
            {
                if (c.Equals('.'))
                {
                    bRet = true;
                    break;
                }
            }
            return bRet;
        }

        private bool IsSyntaxErr(String Text)
        {
            bool bRet = false;
            int cnt = 0;

            foreach (char c in Text)
            {
                if (c.Equals('.'))
                {
                    cnt++;
                }
            }

            if (cnt > 1)
            {
                bRet = true;
            }
            return bRet;
        }

        private bool ChkError() // checks error for binary octal and hexadecimal number system
        {
            bool bRet = false;

            if (IsFloat(textbox1.Text))
            {
                ErrorMessage("ConversionErr");
                bRet = true;
            }
            else if (textbox1.Text.Equals("\u221E")) // if number is infinity.
            {
                ErrorMessage("ConversionErr");
                bRet = true;
            }
            else if (textbox1.Text.Equals("")) // if number is infinity.
            {
                ErrorMessage("NumberMissingErr");
                textbox1.Text = "0";
                bRet = true;
            }

            if (flag == 2)
            {
                if (textbox1.Text.Length > 16)
                {
                    ErrorMessage("LengthErr");
                    bRet = true;
                }
            }

            return bRet;
        }

        private bool ChkError(String text1,String text2) //OverLoaded method
        {
            bool bRet = false;

            if (text1.Equals("") || text2.Equals(""))
            {
                ErrorMessage("NumberMissingErr");
                bRet = true;
            }
            if (IsSyntaxErr(text1) || IsSyntaxErr(text2))
            {
                ErrorMessage("FloatingPointErr");
                bRet = true;
            }
            if (textbox1.Text.Equals("\u221E"))
            {
                ErrorMessage("ConversionErr");
                bRet = true;
            }

            return bRet;
        }

        private void ToDecimal(ref String text1, ref String text2)
        {
            if (flag == 2) // To convert the binary number to decimal
            {
                text1 = (Convert.ToInt32(text1, 2)).ToString();
                text2 = (Convert.ToInt32(text2, 2)).ToString();
            }
            else if (flag == 3)  // To convert the octal number to decimal
            {
                text1 = (Convert.ToInt32(text1, 8)).ToString();
                text2 = (Convert.ToInt32(text2, 8)).ToString();
            }
            else if (flag == 4)  // To convert the hex number to decimal
            {
                text1 = (Convert.ToInt32(text1, 16)).ToString();
                text2 = (Convert.ToInt32(text2, 16)).ToString();
            }
        }

        private String ToText(float result)
        {
            String text = textbox1.Text;

            if (flag == 2)
            {
                text = Convert.ToString((Int32)result, 2);
            }
            else if (flag == 3)
            {
                text = Convert.ToString((Int32)result, 8);
            }
            else if (flag == 4)
            {
                text = Convert.ToString((Int32)result, 16);
            }
            else
            {
                text = result.ToString();
            }

            return text;
        }

        private void ErrorMessage(String Error, int Errno = 0)
        {
            switch (Error)
            {
                case "ConversionErr":
                    MessageBox.Show("Conversion Error !");
                    break;

                case "LengthErr":
                    MessageBox.Show("Difficult to handle length is greater than 16 bytes");
                    break;

                case "NumberMissingErr":
                    MessageBox.Show("Please Enter the number");
                    break;

                case "BitwiseErr":
                    if (Errno == 1)
                    {
                        MessageBox.Show("Left shift cannot be applied to floating point number !");
                    }
                    else if (Errno == 2)
                    {
                        MessageBox.Show("Right shift cannot be applied to floating point number !");
                    }
                    else if (Errno == 3)
                    {
                        MessageBox.Show("Bitwise OR cannot be applied to floating point number !");
                    }
                    else if (Errno == 4)
                    {
                        MessageBox.Show("Bitwise AND cannot be applied to floating point number !");
                    }
                    else
                    {
                        MessageBox.Show("Bitwise XOR cannot be applied to floating point number !");
                    }
                    break;

                case "FloatingPointErr":
                    MessageBox.Show("Syntax Error!");
                    break;


            }
        }
    }
}
