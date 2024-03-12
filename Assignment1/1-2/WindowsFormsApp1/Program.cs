using System;
using System.Windows.Forms;

namespace CalculatorApp
{
    public partial class CalculatorForm : Form
    {
        //图像化界面的基本组件
        private TextBox textBoxNum1;
        private TextBox textBoxNum2;
        private ComboBox comboBoxOperator;
        private Button calculateButton;
        private Label labelResult;

        public CalculatorForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            textBoxNum1 = new TextBox();
            textBoxNum2 = new TextBox();
            comboBoxOperator = new ComboBox();
            calculateButton = new Button();
            labelResult = new Label();

            SuspendLayout();//即将进行多个控的更改 用于提高布局效率

            //设置各组件的位置和大小
            textBoxNum1.Location = new System.Drawing.Point(50, 50);//左上坐标
            textBoxNum1.Size = new System.Drawing.Size(100, 20);//长宽

            
            textBoxNum2.Location = new System.Drawing.Point(200, 50);
            textBoxNum2.Size = new System.Drawing.Size(100, 20);

            
            comboBoxOperator.DropDownStyle = ComboBoxStyle.DropDownList;//下拉格式
            comboBoxOperator.Items.AddRange(new object[] { "+", "-", "*", "/" });
            comboBoxOperator.Location = new System.Drawing.Point(150, 50);
            comboBoxOperator.Size = new System.Drawing.Size(50, 20);

            
            calculateButton.Text = "计算";
            calculateButton.Location = new System.Drawing.Point(300, 50);
            calculateButton.Click += new EventHandler(CalculateButton_Click);

            
            labelResult.Location = new System.Drawing.Point(150, 100);
            labelResult.Size = new System.Drawing.Size(200, 20);

           
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(400, 200);
            Controls.Add(textBoxNum1);
            Controls.Add(textBoxNum2);
            Controls.Add(comboBoxOperator);
            Controls.Add(calculateButton);
            Controls.Add(labelResult);
            Name = "CalculatorForm";
            Text = "简单计算器";
            ResumeLayout(false);
            PerformLayout();
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            try
            {
                double num1 = Convert.ToDouble(textBoxNum1.Text);
                double num2 = Convert.ToDouble(textBoxNum2.Text);
                char op = Convert.ToChar(comboBoxOperator.SelectedItem);

                double result = 0;
                switch (op)
                {
                    case '+':
                        result = num1 + num2;
                        break;
                    case '-':
                        result = num1 - num2;
                        break;
                    case '*':
                        result = num1 * num2;
                        break;
                    case '/':
                        if (num2 != 0)
                        {
                            result = num1 / num2;
                        }
                        else
                        {
                            MessageBox.Show("除数不能为零。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        break;
                    default:
                        MessageBox.Show("无效的运算符。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }

                labelResult.Text = $"结果: {result}";
            }
            catch (FormatException)
            {
                MessageBox.Show("请输入有效的数字。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"发生错误：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CalculatorForm());
        }
    }
}
