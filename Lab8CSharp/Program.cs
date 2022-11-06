using System.Text.RegularExpressions;

Console.WriteLine("Lab#8 ");

Start:
var choose = 0;
do
{
    Console.WriteLine("Which ex you want to start 1-5: ");
    choose = int.Parse(Console.ReadLine());
} while (choose > 5 || choose < 1);

switch (choose)
{
    case 1:
        {
            static void lineChanger(string newText, string fileName, int line_to_edit)
            {
                string[] arrLine = File.ReadAllLines(fileName);
                arrLine[line_to_edit - 1] = newText;
                File.WriteAllLines(fileName, arrLine);
            }

            string text = File.ReadAllText(@"C:\Users\vvojc\Source\Repos\VLazorykOOP\lab8-K4chur\Lab8CSharp\1in.txt");
            Regex regex = new Regex(@"[a-fA-F0-9]{2}\.[a-fA-F0-9]{2}\.[a-fA-F0-9]{2}\.[a-fA-F0-9]{2}");
            MatchCollection matches = regex.Matches(text);
            if (matches.Count > 0)
            {
                Console.WriteLine("\nNumbers of matches:" + matches.Count+"\n");
                
                string output = @"C:\Users\vvojc\Source\Repos\VLazorykOOP\lab8-K4chur\Lab8CSharp\1out.txt";
                if (File.Exists(output))
                {
                    File.Delete(output);
                }
                using (StreamWriter sw = File.CreateText(output))
                {
                    foreach (Match match in matches)
                    {
                        Console.WriteLine(match.Value);
                        sw.WriteLine(match.ToString());
                    }
                }

                //lineChanger("BA.C1.5A.2F", output, 2);
            }
            else
            {
                Console.WriteLine("There is no matches");
            }
        }
        break;
    case 2:
        {
            string str = File.ReadAllText(@"C:\Users\vvojc\Source\Repos\VLazorykOOP\lab8-K4chur\Lab8CSharp\2in.txt");
            str = Regex.Replace(str, @"\b\w\b\W*", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"\ba.*?\b", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"\bb.*?\b", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"\bc.*?\b", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"\bd.*?\b", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"\be.*?\b", "", RegexOptions.IgnoreCase);
            Console.WriteLine(str);

            string output = @"C:\Users\vvojc\Source\Repos\VLazorykOOP\lab8-K4chur\Lab8CSharp\2out.txt";
            if (File.Exists(output))
            {
                File.Delete(output);
            }
            using (StreamWriter sw = File.CreateText(output))
            {
                sw.WriteLine(str);
            }

        }
        break;
    case 3:
        {
            string str = File.ReadAllText(@"C:\Users\vvojc\Source\Repos\VLazorykOOP\lab8-K4chur\Lab8CSharp\3in.txt");
            char[] delimiterChars = { ' ', ',', '.', ':', '\t' };
            string[] words = str.Split(delimiterChars);

            
            string output = @"C:\Users\vvojc\Source\Repos\VLazorykOOP\lab8-K4chur\Lab8CSharp\3out.txt";
            if (File.Exists(output))
            {
                File.Delete(output);
            }
            using (StreamWriter sw = File.CreateText(output))
            {
                
                foreach (var word in words)
                {
                    var error = 0;
                    for (int i = 0, j = word.Length-1; i < j; i++, j--)
                    {
                        if (word[i] != word[j])
                        {
                            error++;
                        }
                    }
                    if (error == 0 && word.Length > 1)
                    {
                        sw.WriteLine(word.ToString());
                    }

                }
            }

        }
        break;
    case 4:
        {
            string input = @"C:\Users\vvojc\Source\Repos\VLazorykOOP\lab8-K4chur\Lab8CSharp\4in.txt";
            if (File.Exists(input))
            {
                File.Delete(input);
            }
            using (StreamWriter sw = File.CreateText(input))
            {
                Console.WriteLine("Input N: ");
                uint n = uint.Parse(Console.ReadLine());
                ulong[] fibonachi = new ulong[n];
                for(int i = 0; i < fibonachi.Length; i++)
                {   
                    if(i == 0)
                    {
                        fibonachi[i] = 0;
                    } else if (i == 1)
                    {
                        fibonachi[i] = 1;
                    } else if(i != 0 && i != 1)
                    {
                        fibonachi[i] = fibonachi[i - 1] + fibonachi[i - 2];
                    }
                    sw.WriteLine(fibonachi[i]);
                    if((i % 3 != 0) || (i == 0))
                    {
                        Console.WriteLine($"{i}. {fibonachi[i]}");
                    }
                }
            }
            
        }
        break;
    case 5:
        {
            if (Directory.Exists(@"D:\Temp\All"))
            {
                Directory.Delete(@"D:\Temp\All", true);
            }
            string dir = @"D:\Temp\Voichenko_Vadim1";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            } else if(Directory.Exists(dir))
            {
                Directory.Delete(dir,true);
                Directory.CreateDirectory(dir);
            }

            string dir2 = @"D:\Temp\Voichenko_Vadim2";
            if (!Directory.Exists(dir2))
            {
                Directory.CreateDirectory(dir2);
            }
            else if (Directory.Exists(dir2))
            {
                Directory.Delete(dir2,true);
                Directory.CreateDirectory(dir2);
            }


            string t1 = @"D:\Temp\Voichenko_Vadim1\t1.txt";
            if (File.Exists(t1))
            {
                File.Delete(t1);
            }
            using (StreamWriter sw = File.CreateText(t1))
            {
                sw.WriteLine("Voichenko Vadim Sergiyovich, 2003 year of birth, place of living city Chernivtsi");
            }

            string t2 = @"D:\Temp\Voichenko_Vadim1\t2.txt";
            if (File.Exists(t2))
            {
                File.Delete(t2);
            }
            using (StreamWriter sw = File.CreateText(t2))
            {
                sw.WriteLine("Lutsiuk Yurii Vasulyovich, 2003 year of birth, place of living city Chernivtsi");
            }


            string t1str = File.ReadAllText(@"D:\Temp\Voichenko_Vadim1\t1.txt");
            string t2str = File.ReadAllText(@"D:\Temp\Voichenko_Vadim1\t2.txt");


            string t3 = @"D:\Temp\Voichenko_Vadim2\t3.txt";
            if (File.Exists(t3))
            {
                File.Delete(t3);
            }
            using (StreamWriter sw = File.CreateText(t3))
            {
                sw.WriteLine(t1str);
                sw.WriteLine(t2str);
            }

            string t3str = File.ReadAllText(@"D:\Temp\Voichenko_Vadim2\t3.txt");

            string[] infodir = Directory.GetFiles(dir);
            for (int i = 0; i < infodir.Length; i++)
            {
                Console.WriteLine(infodir[i]);
                Console.WriteLine(File.ReadAllText(infodir[i]));
            }
            string[] infodir2 = Directory.GetFiles(dir2);
            for (int i = 0; i < infodir2.Length; i++)
            {
                Console.WriteLine(infodir2[i]);
                Console.WriteLine(File.ReadAllText(infodir2[i]));
            }

            string t1copy = @"D:\Temp\Voichenko_Vadim2\t1.txt";
            File.Copy(t1, t1copy, true);
            string t2copy = @"D:\Temp\Voichenko_Vadim2\t2.txt";
            File.Move(t2, t2copy, true);

            string dir2rename = @"D:\Temp\All";
            Directory.Move(dir2, dir2rename);
            Directory.Delete(dir, true);

            string[] info = Directory.GetFiles(dir2rename);
            for(int i = 0; i < info.Length; i++)
            {
                Console.WriteLine(info[i]);
                Console.WriteLine(File.ReadAllText(info[i]));
            }
            
            
        }
        break;

    default: Console.WriteLine("Something went wrong");
        break;
}

Console.WriteLine("\nInput 0 for REchoose, any other numb for END: ");
var end = int.Parse(Console.ReadLine());
if (end == 0)
{
    goto Start;
}
else
{
    return 0;
}