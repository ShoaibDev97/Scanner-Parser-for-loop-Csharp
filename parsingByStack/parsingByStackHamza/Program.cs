using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace parsingByStackHamza
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] table = new string[,] {{"0","for","(",")","A","{","}","$"}
                                             ,{"F","for(A;A;A){f}"," "," "," "," "," "," "}
                                             ,{"f","F"," "," "," "," ","Null"," "}};

           



            StreamReader sr = new StreamReader("input.txt");
            //   Stack<string> st1 = new Stack<string>();
            // string sentence = @"id/+id$";
            string sentence;
            while (sr.Peek() >=0)
            {
                Stack<string> st = new Stack<string>();
                sentence = sr.ReadLine();
                Console.WriteLine("Parsing for Sentence---->  " + sentence);
                st.Push("$");
                print(st);
                st.Push("F");
                print(st);
                string b = "";
                string a = st.Pop();
                bool invalid = false;
                for (int i = 0; i < sentence.Length; )
                {


                    if (sentence[i] == 'f' && sentence[i + 1] == 'o' && sentence[i + 2] == 'r')
                    {
                        if (sentence[i] == 'f')
                        {
                            b = "" + (sentence[i]);
                            b += sentence[i + 1];
                            b += sentence[i + 2];
                            
                        }
                        //else
                        //{
                        //    if (sentence[i] == 'd')
                        //    {
                        //        b = "" + sentence[i + 1];
                        //    }
                        //    else
                        //    {
                        //        b = "" + sentence[i];
                        //    }

                        //}

                        for (int s = 0; s < table.GetLength(0); )
                        {
                            if (invalid)
                            {
                                break;
                            }
                            for (int z = 0; z < table.GetLength(1); z++)
                            {
                                if (invalid)
                                {
                                    break;
                                }

                                if (table[s, z] == b)
                                {
                                    int col = z;
                                    z = 0;
                                    while (table[s, z] != a && z < table.GetLength(1))
                                    {

                                        s++;
                                    }
                                    int row = s;
                                    string c = table[row, col];
                                    char[] array = c.ToCharArray();
                                    int arrayLength = array.Length;
                                    string id = "";
                                    if (array[0] == 'f')
                                    {
                                        for (int k = 0; k < 3; k++)
                                        {
                                            id += array[k].ToString();
                                        }
                                        // id = c.ToString();
                                        //  st.Push(id);

                                        for (int l = array.Length - 1; l >= 3; l--)
                                        {
                                            st.Push(array[l].ToString());
                                        }
                                        st.Push(id);
                                    }
                                    else
                                    {
                                        st.Push(c);
                                    }

                                    print(st);




                                    a = st.Pop();
                                    if (a == " ")
                                    {
                                        Console.WriteLine(sentence);
                                        Console.WriteLine("Invalid Sentence...");
                                        s = table.GetLength(0);
                                        z = table.GetLength(1);
                                        i = sentence.Length;
                                        invalid = true;
                                        break;
                                    }
                                    if (a == b)
                                    {
                                        while (a == b && a != "f")
                                        {
                                            if ((i + 3) == sentence.Length - 1)
                                            {
                                                i += 1;
                                            }
                                            else if (sentence[i] == 'f')
                                            {
                                                i += 3;
                                            }
                                            else
                                            {
                                                i += 1;
                                            }
                                            print(st);
                                            a = st.Pop();
                                            b = sentence[i].ToString();
                                        }
                                        if (a != b && a != "f")
                                        {
                                            Console.WriteLine("Invalid Sentence...!");
                                            invalid = true;
                                            i = sentence.Length;
                                            break;
                                        }
                                        //  i++;

                                        s = table.GetLength(0);
                                        z = table.GetLength(1);
                                        //  a = st.Pop();

                                    }
                                    else
                                    {
                                        s = 0;
                                    }




                                }

                            }

                        }

                    }
                    else
                    {
                        if (sentence[i] == 'r')
                        {
                            if (sentence[i] == 'r')
                            {
                                b = "" + sentence[i + 1];
                            }
                            else
                            {
                                b = "" + sentence[i];
                            }
                        }
                        else
                        {

                            b = "" + sentence[i];
                            while (a == b && a != "$")
                            {
                                print(st);
                                a = st.Pop();
                                i++;
                                b = "" + sentence[i];
                            }
                            if (a != b && (a != "f" || a != "$"))
                            {
                                Console.WriteLine("Invalid Sentence...!");
                                invalid = true;
                                break;
                            }
                        }


                        for (int s = 0; s < table.GetLength(0); )
                        {
                            if (invalid)
                            {
                                break;
                            }
                            for (int z = 0; z < table.GetLength(1); z++)
                            {
                                // z = 21;
                                if (invalid)
                                {
                                    break;
                                }

                                if (table[s, z] == b)
                                {
                                    int col = z;
                                    z = 0;
                                    //  s = 2;
                                    if (a == "$" && sentence[i] == '$')
                                    {
                                        Console.WriteLine(sentence);
                                        Console.WriteLine("Sentence Parsed..");
                                        z = table.GetLength(1);
                                        s = table.GetLength(0);
                                        i = sentence.Length;
                                        break;
                                    }
                                    if (a == b)
                                    {
                                        z = table.GetLength(1);
                                        s = table.GetLength(0);
                                        a = st.Pop();
                                        break;
                                    }
                                    while (table[s, z] != a && z < table.GetLength(1))
                                    {
                                        //s = 23;
                                        s++;
                                    }

                                    int row = s;
                                    string c = table[row, col];
                                    char[] array = c.ToCharArray();
                                    int arrayLength = array.Length;
                                    if (array[0] == 'i')
                                    {
                                        string id = c.ToString();
                                        st.Push(id);
                                    }
                                    else if (array[0] == 'N')
                                    {
                                        //string Null = c.ToString();
                                        // a = st.Pop();
                                        z = 0;

                                    }
                                    else
                                    {
                                        while (arrayLength >= 0)
                                        {
                                            if (arrayLength == 0)
                                            {
                                                break;
                                            }
                                            else
                                            {
                                                string chr = c[arrayLength - 1].ToString();
                                                arrayLength--;
                                                st.Push(chr);
                                            }


                                        }
                                    }
                                    print(st);
                                    a = st.Pop();

                                    if (a == " ")
                                    {
                                        Console.WriteLine(sentence);
                                        Console.WriteLine("Invalid Sentece");
                                        s = table.GetLength(0);
                                        z = table.GetLength(1);
                                        i = sentence.Length;
                                        invalid = true;
                                    }

                                    while (a == b && a != "$")
                                    {
                                        print(st);
                                        a = st.Pop();
                                    }





                                    if (a == b && st.Count() != 0)
                                    {
                                        a = st.Pop();
                                        i++;
                                        s = table.GetLength(0);
                                        z = table.GetLength(1);

                                    }
                                    else
                                    {
                                        if (st.Count != 0)
                                        {
                                            s = 0;
                                        }

                                    }






                                }

                            }

                        }

                    }


                }

            }
        }

        public static void print(Stack<string> s)
        {
            Stack<string> st1 = new Stack<string>();

            Console.Write("Contents Of Stack  : ");
            foreach (string a in s)
            {
                Console.Write(a);
            }
            Console.WriteLine();


        }
    }
}
