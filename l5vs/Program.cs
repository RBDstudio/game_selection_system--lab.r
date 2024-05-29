using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l5vs
{
    public class Answer
    {
        public string answer { get; set; }
        public string key { get; set; }

        public Answer(string answer, string key)
        {
            this.answer = answer;
            this.key = key;
        }
    }

    internal class Program
    {
        struct Otvet
        {
            public string name { get; set; }
            public int Difs { get; set; }
        }
        public static void Ask(string qText,ref int Current, ref StringBuilder AnsKey)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("   " + qText+ "\n\n   Y-да           N-нет");
                ConsoleKeyInfo EnteredKey = Console.ReadKey();
                if (EnteredKey.Key == ConsoleKey.Y) { AnsKey[Current] = '1'; Current++; return; }
                if (EnteredKey.Key == ConsoleKey.N) { AnsKey[Current] = '0'; Current++; return; }
            }
        }
        static void Main(string[] args)
        {
            /////////////////////НАСТРОЙКА \/ \/ \/
            
            StringBuilder Answer = new StringBuilder("0000000000");
            Answer[] Keys = new Answer[10]
            {
                new Answer("Prey",          "0110110110"),
                new Answer("The witcher 3", "1110001010"),
                new Answer("Rimworld",      "1101110110"),
                new Answer("Tes 2",         "1001010000"),
                new Answer("Portal 2",      "0110010001"),
                new Answer("Kenshi",        "1001101110"),
                new Answer("Cs 2",          "0010010101"),
                new Answer("No mans sky",   "1010101011"),
                new Answer("It takes two",  "0110100001"),
                new Answer("Stardew valley","0100111011")
            };
            int Current = 0;

            Ask("Ваc больше интересуют большие игровые миры, чем маленькие или линейные?", ref Current,ref Answer);
            Ask("Вам нравиться, когда за каждым углом вас ждёт какая-либо активность, даже если она займёт у вас пару секунд?", ref Current, ref Answer);
            Ask("Для вас важна графика?", ref Current, ref Answer);
            Ask("Вы любите сложные игры, бросающие вызов с первой секунды?", ref Current, ref Answer);
            Ask("Вам важно большое разнообразие взаимодействия с миром?", ref Current, ref Answer);
            Ask("Вас пугают высокие системные требования для игр?", ref Current, ref Answer);
            Ask("Вы готовы погрузится в игру на несколько дней или даже недель?", ref Current, ref Answer);
            Ask("Для вас важна возможность перепрохождения игры?", ref Current, ref Answer);
            Ask("Вы хотите, чтобы ваши решения влияли на развитие сюжета игры?", ref Current, ref Answer);
            Ask("Хотите ли вы иметь возможность поиграть в игру со своим другом?", ref Current, ref Answer);

            /////////////////////НАСТРОЙКА /\ /\ /\
            
            Otvet CurOtvet = new Otvet();
            CurOtvet.Difs = 0;
            Console.Clear();
            for (int Ans = 0;Ans < 10; Ans++)
            {
                int DifCount = 10;
                for (int i = 0; i < 10; i++) 
                {
                    if (Answer[i] != Keys[Ans].key[i])
                    {
                        DifCount--;
                    }
                }
                if(DifCount > CurOtvet.Difs) { CurOtvet.name = Keys[Ans].answer; CurOtvet.Difs = DifCount; }
            }

            Console.WriteLine("Игра " + CurOtvet.name + " подходит вам на " + CurOtvet.Difs * 10 + "%");
        }
    }
}
