using System;
using System.Collections.Generic;



public class NumberSystem
{

    public NumberSystem()
    {

    }

    public String Binary(String textbox, int flag) // It displays Binary representation of corresponding number
    {
        long val = 0;

        if (flag == 1)
        {
            val = Convert.ToInt64(textbox);
            textbox = Convert.ToString(val, 2);
        }
        else if (flag == 3)
        {

            val = Convert.ToInt64(textbox);
            val = Convert.ToInt64(val.ToString(), 8);
            textbox = Convert.ToString(val, 2);

        }
        else if (flag == 4)
        {

            val = Convert.ToInt64(textbox, 16);
            textbox = Convert.ToString(val, 2);

        }

        return textbox;
    }

    public String Octal(String textbox, int flag) //It displays Octal representation of corresponding number
    {


        long val = 0;

        if (flag == 1)
        {

            val = Convert.ToInt64(textbox);
            textbox = Convert.ToString(val, 8);

        }
        else if (flag == 2)
        {

            val = Convert.ToInt64(textbox);
            val = Convert.ToInt64(val.ToString(), 2);
            textbox = Convert.ToString(val, 8);
        }
        else if (flag == 4)
        {
            val = Convert.ToInt64(textbox, 16);
            textbox = Convert.ToString(val, 8);

        }
        return textbox;

    }

    public String Hexadecimal(String textbox, int flag) //It displays Hexadecimal representation of corresponding number
    {

        long val = 0;

        val = Convert.ToInt64(textbox);

        if (flag == 1)
        {
            textbox = Convert.ToString(val, 16);
        }
        else if (flag == 2)
        {
            val = Convert.ToInt64(val.ToString(), 2);
            textbox = Convert.ToString(val, 16);

        }
        else if (flag == 3)
        {
            val = Convert.ToInt64(val.ToString(), 8);
            textbox = Convert.ToString(val, 16);
        }

        return textbox;
    }

    public String Decimal(String textbox, int flag) //It displays Decimal representation of corresponding number
    {
        long val = 0;


        if (flag == 2)
        {
            val = Convert.ToInt64(textbox);
            val = Convert.ToInt64(val.ToString(), 2);
            textbox = val.ToString();

        }
        else if (flag == 3)
        {
            val = Convert.ToInt64(textbox);
            val = Convert.ToInt64(val.ToString(), 8);
            textbox = val.ToString();

        }
        else if (flag == 4)
        {
            val = Convert.ToInt64(textbox, 16);
            textbox = val.ToString();

        }

        return textbox;

    }

}


