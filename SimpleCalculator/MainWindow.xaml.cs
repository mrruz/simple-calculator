using System.Windows;

namespace SimpleCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        enum InputBlock{Block_A,Block_B}
        enum Method { Null, Add, Subtract}
        enum ButtonPush{ Zero=0,One=1,Two=2,Three=3,Four=4,Five=5,Six=6,Seven=7,Eight=8,Nine=9,Add,Subtract,Enter,Clear,Null}


        private InputBlock CurrentInputBlock { get; set; }
        private ButtonPush LastButtonPushed { get; set; }
        private Method CMethod { get; set; }
        
        private string BlockA { get; set; }
        private string BlockB { get; set; }
        private string ScreenText { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Clear();
        }

        private void Clear()
        {
            CurrentInputBlock = InputBlock.Block_A;
            LastButtonPushed = ButtonPush.Null;
            CMethod = Method.Null;
            BlockA = "";
            BlockB = "";
            UpdateField("", false);

        }

        private void ChangeCurrentBlock()
        {
            switch (CurrentInputBlock)
            {
                case InputBlock.Block_A:
                    CurrentInputBlock = InputBlock.Block_B;
                    break;
                case InputBlock.Block_B:
                    CurrentInputBlock = InputBlock.Block_A;
                    break;
            }
        }

        private void HoldInMemory(string value)
        {
            switch (CurrentInputBlock)
            {
                case InputBlock.Block_A:
                    BlockA = BlockA + value;
                    break;
                case InputBlock.Block_B:
                    BlockB = BlockB + value;
                    break;
            }
        }

        private void AppLogic(ButtonPush value)
        {
            switch (value)
            {
                case ButtonPush.One:
                    HoldInMemory("1");
                    UpdateField("1", true);
                    break;
                case ButtonPush.Two:
                    HoldInMemory("2");
                    UpdateField("2", true);
                    break;
                case ButtonPush.Three:
                    HoldInMemory("3");
                    UpdateField("3", true);
                    break;
                case ButtonPush.Four:
                    HoldInMemory("4");
                    UpdateField("4", true);
                    break;
                case ButtonPush.Five:
                    HoldInMemory("5");
                    UpdateField("5", true);
                    break;
                case ButtonPush.Six:
                    HoldInMemory("6");
                    UpdateField("6", true);
                    break;
                case ButtonPush.Seven:
                    HoldInMemory("7");
                    UpdateField("7", true);
                    break;
                case ButtonPush.Eight:
                    HoldInMemory("8");
                    UpdateField("8", true);
                    break;
                case ButtonPush.Nine:
                    HoldInMemory("9");
                    UpdateField("9", true);
                    break;
                case ButtonPush.Zero:
                    HoldInMemory("0");
                    UpdateField("0", true);
                    break;
                case ButtonPush.Add:
                    if ((int)LastButtonPushed <= 9)
                    {
                        ChangeCurrentBlock();
                        UpdateField(" + ", true);
                        CMethod = Method.Add;
                    }
                    break;
                case ButtonPush.Subtract:
                    if ((int)LastButtonPushed <= 9)
                    {
                        ChangeCurrentBlock();
                        UpdateField(" - ", true);
                        CMethod = Method.Subtract;
                    }
                    break;
                case ButtonPush.Enter:
                    if (CMethod != Method.Null)
                    {
                        UpdateField(Calculate(CMethod).ToString(), false);
                    }
                    break;
                case ButtonPush.Clear:
                    Clear();
                    break;
            }
            LastButtonPushed = value;
        }

        private double Calculate(Method value)
        {
            double answer = 0;
            double num1;
            double num2;
            double.TryParse(BlockA, out num1);
            double.TryParse(BlockB, out num2);
            switch (value)
            {
                case Method.Null:
                    break;
                case Method.Add:
                    return num1 + num2;
                case Method.Subtract:
                    return num1 - num2;
            }
            return answer;
        }

        private void UpdateField(string value, bool append)
        {
            if (append)
            {
                TextBoxField.Text = TextBoxField.Text + value;
            }
            else
            {
                TextBoxField.Text = value;
            }
        }

        #region Input
        private void _0_Click(object sender, RoutedEventArgs e){AppLogic(ButtonPush.Zero);}
        private void _1_Click(object sender, RoutedEventArgs e){AppLogic(ButtonPush.One);}
        private void _2_Click(object sender, RoutedEventArgs e){AppLogic(ButtonPush.Two);}
        private void _3_Click(object sender, RoutedEventArgs e){AppLogic(ButtonPush.Three);}
        private void _4_Click(object sender, RoutedEventArgs e){AppLogic(ButtonPush.Four);}
        private void _5_Click(object sender, RoutedEventArgs e){AppLogic(ButtonPush.Five);}
        private void _6_Click(object sender, RoutedEventArgs e){AppLogic(ButtonPush.Six);}
        private void _7_Click(object sender, RoutedEventArgs e){AppLogic(ButtonPush.Seven);}
        private void _8_Click(object sender, RoutedEventArgs e){AppLogic(ButtonPush.Eight);}
        private void _9_Click(object sender, RoutedEventArgs e){AppLogic(ButtonPush.Nine);}
        private void Enter_Click(object sender, RoutedEventArgs e){ AppLogic(ButtonPush.Enter); }
        private void BtnAdd_Click(object sender, RoutedEventArgs e){AppLogic(ButtonPush.Add);}
        private void BtnSubtract_Click(object sender, RoutedEventArgs e){AppLogic(ButtonPush.Subtract);}
        private void Btn_Clear_Click(object sender, RoutedEventArgs e){AppLogic(ButtonPush.Clear);}
        #endregion
    }
}
