using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// 빈 페이지 항목 템플릿에 대한 설명은 https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x412에 나와 있습니다.

namespace Calculate_Matrix
{
    /// <summary>
    /// 자체적으로 사용하거나 프레임 내에서 탐색할 수 있는 빈 페이지입니다.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public int ARowPublicValue = 2;
        public int AColumnPublicValue = 2;
        public int BRowPublicValue = 2;
        public int BColumnPublicValue = 2;
        public int ORowPublicValue = 2;
        public int OColumnPublicValue = 2;

        public MainPage()
        {
            this.InitializeComponent();
            Window.Current.SizeChanged += Current_SizeChanged;
        }

        private void Current_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {

            foreach (var item in MatrixAGrid.Children)
            {
                if (item is TextBox)
                {
                    var element = (TextBox)item;
                    element.FontSize = Convert.ToInt32(element.ActualHeight) - 6;
                }
            }
            foreach (var item in MatrixBGrid.Children)
            {
                if (item is TextBox)
                {
                    var element = (TextBox)item;
                    element.FontSize = Convert.ToInt32(element.ActualHeight) - 6;
                }
            }
            foreach (var item in MatrixOutput.Children)
            {
                if (item is TextBox)
                {
                    var element = (TextBox)item;
                    element.FontSize = Convert.ToInt32(element.ActualHeight) - 6;
                }
            }
        }

        private void ARCAppply_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in MatrixAGrid.Children)
            {
                if (item is TextBox)
                {
                    var TextBox = item as TextBox;
                    TextBox.Visibility = Visibility.Collapsed;
                }
            }
            int ARowValue = Convert.ToInt32(ARow.Value);
            int AColumnValue = Convert.ToInt32(AColumn.Value);

            foreach (var item in MatrixAGrid.Children)
            {
                if (item is TextBox)
                {
                    var element = (TextBox)item;
                    int ItemRow = Grid.GetRow(element);
                    int ItemColumn = Grid.GetColumn(element);
                    if (ItemRow <= ARowValue && ItemColumn <= AColumnValue)
                    {
                        element.Visibility = Visibility.Visible;
                    }
                }
            }

            ARowPublicValue = ARowValue;
            AColumnPublicValue = AColumnValue;

            string LeftContent = ARowPublicValue.ToString();
            string RightContent = AColumnPublicValue.ToString();
            Left.Content = "A: " + LeftContent + "X" + RightContent;

            AFlyout.Hide();
        }

        private void BRCAppply_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in MatrixBGrid.Children)
            {
                if (item is TextBox)
                {
                    var TextBox = item as TextBox;
                    TextBox.Visibility = Visibility.Collapsed;
                }
            }

            int BRowValue = Convert.ToInt32(BRow.Value);
            int BColumnValue = Convert.ToInt32(BColumn.Value);

            foreach (var item in MatrixBGrid.Children)
            {
                if (item is TextBox)
                {
                    var element = (TextBox)item;
                    int ItemRow = Grid.GetRow(element);
                    int ItemColumn = Grid.GetColumn(element);
                    if (ItemRow <= BRowValue && ItemColumn <= BColumnValue)
                    {
                        element.Visibility = Visibility.Visible;
                    }
                }
            }

            BRowPublicValue = BRowValue;
            BColumnPublicValue = BColumnValue;

            string LeftContent = BRowPublicValue.ToString();
            string RightContent = BColumnPublicValue.ToString();
            Right.Content = "B: " + LeftContent + "X" + RightContent;

            BFlyout.Hide();
        }

        private void Switch_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void AllClear_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in MatrixAGrid.Children)
            {
                if (item is TextBox)
                {
                    var TextBox = item as TextBox;
                    TextBox.Text = "";
                }
            }
            foreach (var item in MatrixBGrid.Children)
            {
                if (item is TextBox)
                {
                    var TextBox = item as TextBox;
                    TextBox.Text = "";
                }
            }
            foreach (var item in MatrixOutput.Children)
            {
                if (item is TextBox)
                {
                    var TextBox = item as TextBox;
                    TextBox.Text = "";
                }
            }
        }

        private void AClear_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in MatrixAGrid.Children)
            {
                if (item is TextBox)
                {
                    var TextBox = item as TextBox;
                    TextBox.Text = "";
                }
            }
        }

        private void BClear_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in MatrixBGrid.Children)
            {
                if (item is TextBox)
                {
                    var TextBox = item as TextBox;
                    TextBox.Text = "";
                }
            }
        }

        private void OutputClear_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in MatrixOutput.Children)
            {
                if (item is TextBox)
                {
                    var TextBox = item as TextBox;
                    TextBox.Text = "";
                }
            }
        }

        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            if (ARowPublicValue == BRowPublicValue && AColumnPublicValue == BColumnPublicValue)
            {
                int[,] AArray = new int[ARowPublicValue, AColumnPublicValue];
                foreach (var item in MatrixAGrid.Children)
                {
                    if (item is TextBox)
                    {
                        var element = (TextBox)item;
                        int elementRow = Grid.GetRow(element) - 1;
                        int elementColumn = Grid.GetColumn(element) - 1;
                        if (elementRow < ARowPublicValue && elementColumn < AColumnPublicValue)
                        {
                            AArray.SetValue(Convert.ToInt32(element.Text), elementRow, elementColumn);
                        }
                    }
                }
                int[,] BArray = new int[BRowPublicValue, BColumnPublicValue];
                foreach (var item in MatrixBGrid.Children)
                {
                    if (item is TextBox)
                    {
                        var element = (TextBox)item;
                        int elementRow = Grid.GetRow(element) - 1;
                        int elementColumn = Grid.GetColumn(element) - 1;
                        if (elementRow < BRowPublicValue && elementColumn < BColumnPublicValue)
                        {
                            BArray.SetValue(Convert.ToInt32(element.Text), elementRow, elementColumn);
                        }
                    }
                }
                int[,] OArray = new int[ARowPublicValue, AColumnPublicValue];
                for (int i = 0; i < ARowPublicValue; i++)
                {
                    for (int j = 0; j < AColumnPublicValue; j++)
                    {
                        int Aelement = Convert.ToInt32(AArray.GetValue(i, j));
                        int Belement = Convert.ToInt32(BArray.GetValue(i, j));
                        OArray.SetValue(Aelement + Belement, i, j);
                    }
                }
                foreach (var item in MatrixOutput.Children)
                {
                    if (item is TextBox)
                    {
                        var element = (TextBox)item;
                        int elementRow = Grid.GetRow(element) - 1;
                        int elementColumn = Grid.GetColumn(element) - 1;
                        if (elementRow < ARowPublicValue && elementColumn < AColumnPublicValue)
                        {
                            element.Text = OArray.GetValue(elementRow, elementColumn).ToString();
                        }
                    }
                }
            }
            else
            {
                //Error message
            }
        }

        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            if (ARowPublicValue == BRowPublicValue && AColumnPublicValue == BColumnPublicValue)
            {
                int[,] AArray = new int[ARowPublicValue, AColumnPublicValue];
                foreach (var item in MatrixAGrid.Children)
                {
                    if (item is TextBox)
                    {
                        var element = (TextBox)item;
                        int elementRow = Grid.GetRow(element) - 1;
                        int elementColumn = Grid.GetColumn(element) - 1;
                        if (elementRow < ARowPublicValue && elementColumn < AColumnPublicValue)
                        {
                            AArray.SetValue(Convert.ToInt32(element.Text), elementRow, elementColumn);
                        }
                    }
                }
                int[,] BArray = new int[BRowPublicValue, BColumnPublicValue];
                foreach (var item in MatrixBGrid.Children)
                {
                    if (item is TextBox)
                    {
                        var element = (TextBox)item;
                        int elementRow = Grid.GetRow(element) - 1;
                        int elementColumn = Grid.GetColumn(element) - 1;
                        if (elementRow < BRowPublicValue && elementColumn < BColumnPublicValue)
                        {
                            BArray.SetValue(Convert.ToInt32(element.Text), elementRow, elementColumn);
                        }
                    }
                }
                int[,] OArray = new int[ARowPublicValue, AColumnPublicValue];
                for (int i = 0; i < ARowPublicValue; i++)
                {
                    for (int j = 0; j < AColumnPublicValue; j++)
                    {
                        int Aelement = Convert.ToInt32(AArray.GetValue(i, j));
                        int Belement = Convert.ToInt32(BArray.GetValue(i, j));
                        OArray.SetValue(Aelement - Belement, i, j);
                    }
                }
                foreach (var item in MatrixOutput.Children)
                {
                    if (item is TextBox)
                    {
                        var element = (TextBox)item;
                        int elementRow = Grid.GetRow(element) - 1;
                        int elementColumn = Grid.GetColumn(element) - 1;
                        if (elementRow < ARowPublicValue && elementColumn < AColumnPublicValue)
                        {
                            element.Text = OArray.GetValue(elementRow, elementColumn).ToString();
                        }
                    }
                }
            }
            else
            {
                //Error message
            }
        }

        private void Multiple_Click(object sender, RoutedEventArgs e)
        {
            if (ARowPublicValue == BColumnPublicValue && AColumnPublicValue == BRowPublicValue)
            {
                int[,] AArray = new int[ARowPublicValue, AColumnPublicValue];
                foreach (var item in MatrixAGrid.Children)
                {
                    if (item is TextBox)
                    {
                        var element = (TextBox)item;
                        int elementRow = Grid.GetRow(element) - 1;
                        int elementColumn = Grid.GetColumn(element) - 1;
                        if (elementRow < ARowPublicValue && elementColumn < AColumnPublicValue)
                        {
                            AArray.SetValue(Convert.ToInt32(element.Text), elementRow, elementColumn);
                        }
                    }
                }
                int[,] BArray = new int[BRowPublicValue, BColumnPublicValue];
                foreach (var item in MatrixBGrid.Children)
                {
                    if (item is TextBox)
                    {
                        var element = (TextBox)item;
                        int elementRow = Grid.GetRow(element) - 1;
                        int elementColumn = Grid.GetColumn(element) - 1;
                        if (elementRow < BRowPublicValue && elementColumn < BColumnPublicValue)
                        {
                            BArray.SetValue(Convert.ToInt32(element.Text), elementRow, elementColumn);
                        }
                    }
                }

                int[,] OArray = new int[ARowPublicValue, BColumnPublicValue];
                int temp = 0;
                for (int a = 0; a < ARowPublicValue; a++)
                {
                    for (int b = 0; b < BColumnPublicValue; b++)
                    {
                        for (int c = 0; c < AColumnPublicValue; c++)
                        {
                            temp += AArray[a, c] * BArray[c, b];
                        }
                        OArray[a, b] = temp;
                        temp = 0;
                    }
                }

                foreach (var item in MatrixOutput.Children)
                {
                    if (item is TextBox)
                    {
                        var element = (TextBox)item;
                        int elementRow = Grid.GetRow(element) - 1;
                        int elementColumn = Grid.GetColumn(element) - 1;
                        if (elementRow < ARowPublicValue && elementColumn < BColumnPublicValue)
                        {
                            element.Text = OArray.GetValue(elementRow, elementColumn).ToString();
                        }
                    }
                }
                ORowPublicValue = ARowPublicValue;
                OColumnPublicValue = BColumnPublicValue;
            }
            else
            {
                //Error message
            }
        }

        private void InverseA_Click(object sender, RoutedEventArgs e)
        {
            if(ARowPublicValue==2&&AColumnPublicValue==2)
            {
                int[,] a = new int[2, 2];
                int[,] b = new int[2, 2];

                a[0, 0] = Convert.ToInt32(A11.Text);
                a[0, 1] = Convert.ToInt32(A12.Text);
                a[1, 0] = Convert.ToInt32(A21.Text);
                a[1, 1] = Convert.ToInt32(A22.Text);

                b[0, 0] = Convert.ToInt32(B11.Text);
                b[0, 1] = Convert.ToInt32(B12.Text);
                b[1, 0] = Convert.ToInt32(B21.Text);
                b[1, 1] = Convert.ToInt32(B22.Text);
            }
        }

        private void InverseB_Click(object sender, RoutedEventArgs e)
        {
            if(BRowPublicValue==2&&BColumnPublicValue==2)
            {

            }
        }

        private void ApplyToA_Click(object sender, RoutedEventArgs e)
        {
            ARowPublicValue = ORowPublicValue;
            AColumnPublicValue = OColumnPublicValue;
            int[,] Temp = new int[ORowPublicValue, OColumnPublicValue];
            foreach (var item in MatrixOutput.Children)
            {
                if(item is TextBox)
                {
                    var element = (TextBox)item;
                    int elementRow = Grid.GetRow(element) - 1;
                    int elementColumn = Grid.GetColumn(element) - 1;
                    if (elementRow < ORowPublicValue && elementColumn < OColumnPublicValue)
                    {
                        Temp.SetValue(Convert.ToInt32(element.Text), elementRow, elementColumn);
                    }
                }
            }
            foreach (var item in MatrixAGrid.Children)
            {
                if(item is TextBox)
                {
                    var element = (TextBox)item;
                    int elementRow = Grid.GetRow(element) - 1;
                    int elementColumn = Grid.GetColumn(element) - 1;
                    if (elementRow < ARowPublicValue && elementColumn < AColumnPublicValue)
                    {
                        element.Visibility = Visibility.Visible;
                        element.Text = Temp.GetValue(elementRow, elementColumn).ToString();
                    }
                    else
                    {
                        element.Visibility = Visibility.Collapsed;
                    }
                }
            }
        }

        private void ApplyToB_Click(object sender, RoutedEventArgs e)
        {
            BRowPublicValue = ORowPublicValue;
            BColumnPublicValue = OColumnPublicValue;
            int[,] Temp = new int[ORowPublicValue, OColumnPublicValue];
            foreach (var item in MatrixOutput.Children)
            {
                if (item is TextBox)
                {
                    var element = (TextBox)item;
                    int elementRow = Grid.GetRow(element) - 1;
                    int elementColumn = Grid.GetColumn(element) - 1;
                    if (elementRow < ORowPublicValue && elementColumn < OColumnPublicValue)
                    {
                        Temp.SetValue(Convert.ToInt32(element.Text), elementRow, elementColumn);
                    }
                }
            }
            foreach (var item in MatrixBGrid.Children)
            {
                if (item is TextBox)
                {
                    var element = (TextBox)item;
                    int elementRow = Grid.GetRow(element) - 1;
                    int elementColumn = Grid.GetColumn(element) - 1;
                    if (elementRow < BRowPublicValue && elementColumn < BColumnPublicValue)
                    {
                        element.Visibility = Visibility.Visible;
                        element.Text = Temp.GetValue(elementRow, elementColumn).ToString();
                    }
                    else
                    {
                        element.Visibility = Visibility.Collapsed;
                    }
                }
            }
        }

        private void AFlyout_Opening(object sender, object e)
        {
            ARow.Value = Convert.ToDouble(ARowPublicValue);
            AColumn.Value = Convert.ToDouble(AColumnPublicValue);
        }

        private void BFlyout_Opening(object sender, object e)
        {
            BRow.Value = Convert.ToDouble(BRowPublicValue);
            BColumn.Value = Convert.ToDouble(BColumnPublicValue);
        }
    }
}
