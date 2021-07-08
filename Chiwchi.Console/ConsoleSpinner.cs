using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using Pastel;

namespace Chiwchi.Console
{
    /// <summary>
    /// 
    /// </summary>
    public class ConsoleSpinner : IDisposable
    {
        public enum SpinnerTypes
        {
            Balloon,
            BouncingBall,
            BouncingBar,
            Dqpb,
            Flip,
            Line,
            Pipe,
            RoundTrip,
            Shark,
            SimpleDots,
            SimpleDotsScrolling,
            Spinner,
            Star,
            Turn
        }

        private bool _active;
        private int _currentAnimationFrame;
        private Thread _thread;
        private List<string> AnimationFrames { get; set; }
        public string Message { get; set; }
        public int Delay { get; set; } = 50;
        public SpinnerTypes SpinnerType { get; set; } = SpinnerTypes.Line;
        public Color MessageColor { get; set; } = Color.White;
        public Color SpinnerColor { get; set; } = Color.White;

        public void Dispose()
        {
            Stop();
        }

        public void Start()
        {
            GetFrames();
            _active = true;
            _currentAnimationFrame = 0;
            _thread = new Thread(Spin);
            _thread.Start();
        }

        public void Stop()
        {
            _active = false;
            Thread.Sleep(100);

            if (Message is null)
                Message = string.Empty;

            Draw(string.Empty.PadRight(Message.Length + 50));

            Thread.Sleep(100);
        }

        private void Draw(string content)
        {
            var left = !_active ? 0 : System.Console.CursorLeft;
            var top = System.Console.CursorTop;

            System.Console.CursorVisible = false;
            System.Console.Write(content.Pastel(SpinnerColor));
            System.Console.SetCursorPosition(left, top);
        }

        private void Spin()
        {
            if (!string.IsNullOrEmpty(Message))
                System.Console.Write(Message.Pastel(MessageColor));

            while (_active)
            {
                Thread.Sleep(Delay);
                Turn();
            }
        }

        private void Turn()
        {
            _currentAnimationFrame++;

            if (_currentAnimationFrame == AnimationFrames.Count)
                _currentAnimationFrame = 0;

            Draw(AnimationFrames[_currentAnimationFrame]);
        }

        private void GetFrames()
        {
            switch (SpinnerType)
            {
                case SpinnerTypes.Balloon:
                    AnimationFrames = new List<string>
                    {
                        ".",
                        "o",
                        "O",
                        "°",
                        "O",
                        "o",
                        "."
                    };
                    break;
                case SpinnerTypes.BouncingBall:
                    AnimationFrames = new List<string>
                    {
                        "( ¤    )",
                        "(  ¤   )",
                        "(   ¤  )",
                        "(    ¤ )",
                        "(     ¤)",
                        "(    ¤ )",
                        "(   ¤  )",
                        "(  ¤   )",
                        "( ¤    )",
                        "(¤     )"
                    };
                    break;
                case SpinnerTypes.BouncingBar:
                    AnimationFrames = new List<string>
                    {
                        "[    ]",
                        "[=   ]",
                        "[==  ]",
                        "[=== ]",
                        "[ ===]",
                        "[  ==]",
                        "[   =]",
                        "[    ]",
                        "[   =]",
                        "[  ==]",
                        "[ ===]",
                        "[====]",
                        "[=== ]",
                        "[==  ]",
                        "[=   ]"
                    };
                    break;
                case SpinnerTypes.Dqpb:
                    AnimationFrames = new List<string> { "d", "q", "p", "b" };
                    break;
                case SpinnerTypes.Flip:
                    AnimationFrames = new List<string>
                    {
                        "_",
                        "_",
                        "_",
                        "-",
                        "`",
                        "`",
                        "'",
                        "´",
                        "-",
                        "_",
                        "_",
                        "_"
                    };
                    break;
                case SpinnerTypes.Line:
                    AnimationFrames = new List<string> { "|", "/", "-", "\\" };
                    break;
                case SpinnerTypes.Pipe:
                    AnimationFrames = new List<string>
                    {
                        "┤",
                        "┘",
                        "┴",
                        "└",
                        "├",
                        "┌",
                        "┬",
                        "┐"
                    };
                    break;
                case SpinnerTypes.RoundTrip:
                    AnimationFrames = new List<string>
                    {
                        "........",
                        "*.......",
                        "**......",
                        "***.....",
                        "****....",
                        "*****...",
                        "******..",
                        "*******.",
                        "********",
                        "*******.",
                        "******..",
                        "*****...",
                        "****....",
                        "***.....",
                        "**......",
                        "*......."
                    };
                    break;
                case SpinnerTypes.Shark:
                    AnimationFrames = new List<string>
                    {
                        "▐|\\____________▌",
                        "▐_|\\___________▌",
                        "▐__|\\__________▌",
                        "▐___|\\_________▌",
                        "▐____|\\________▌",
                        "▐_____|\\_______▌",
                        "▐______|\\______▌",
                        "▐_______|\\_____▌",
                        "▐________|\\____▌",
                        "▐_________|\\___▌",
                        "▐__________|\\__▌",
                        "▐___________|\\_▌",
                        "▐____________|\\▌",
                        "▐____________/|▌",
                        "▐___________/|_▌",
                        "▐__________/|__▌",
                        "▐_________/|___▌",
                        "▐________/|____▌",
                        "▐_______/|_____▌",
                        "▐______/|______▌",
                        "▐_____/|_______▌",
                        "▐____/|________▌",
                        "▐___/|_________▌",
                        "▐__/|__________▌",
                        "▐_/|___________▌",
                        "▐/|____________▌"
                    };
                    break;
                case SpinnerTypes.SimpleDots:
                    AnimationFrames = new List<string> { ".  ", ".. ", "...", "   " };
                    break;
                case SpinnerTypes.SimpleDotsScrolling:
                    AnimationFrames = new List<string>
                    {
                        ".  ",
                        ".. ",
                        "...",
                        " ..",
                        "  .",
                        "   "
                    };
                    break;
                case SpinnerTypes.Spinner:
                    AnimationFrames = new List<string>
                    {
                        "",
                        "°",
                        "°º",
                        "°º¤",
                        " º¤ø",
                        "  ¤ø,",
                        "   ø,¸",
                        "    ,¸¸",
                        "     ¸¸,",
                        "      ¸,ø",
                        "       ,ø¤",
                        "        ø¤º",
                        "         ¤º°",
                        "          º°`",
                        "           °``",
                        "            ``°",
                        "             `°º",
                        "              °º¤",
                        "               º¤ø",
                        "                ¤ø,",
                        "                 ø,¸",
                        "                  ,¸¸",
                        "                   ¸¸,",
                        "                    ¸,",
                        "                     ,",
                        "                       "
                    };
                    break;
                case SpinnerTypes.Star:
                    AnimationFrames = new List<string> { "+", "x", "*" };
                    break;
                case SpinnerTypes.Turn:
                    AnimationFrames = new List<string> { "v", "<", "^", ">" };
                    break;
            }
        }
    }
}