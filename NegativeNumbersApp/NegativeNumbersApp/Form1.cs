using System;
using System.Drawing;
using System.Windows.Forms;

namespace NegativeNumbersApp
{
    public partial class Form1 : Form
    {
        // Елементи інтерфейсу
        private TabControl tabControl;
        private ToolStripStatusLabel lblStatus; // Виправлений тип

        // Масиви для збереження елементів керування завдань
        private TextBox[] txtAnswers = new TextBox[6];
        private Label[] lblQuestions = new Label[6];
        private Label[] lblResults = new Label[6];

        // Правильні відповіді (цілі числа)
        private int[] correctAnswers = new int[6];

        public Form1()
        {
            // Налаштування форми
            this.Text = "Навчально-контролююча програма «Додавання й віднімання від'ємних чисел»";
            this.Size = new Size(800, 520);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;

            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            // 1. Створення головного TabControl (вкладок)
            tabControl = new TabControl();
            tabControl.Dock = DockStyle.Fill;
            this.Controls.Add(tabControl);

            // 2. Додавання статус-бару знизу (як на макеті)
            StatusStrip statusStrip = new StatusStrip();
            lblStatus = new ToolStripStatusLabel("Варіант 24 | Готовий до роботи");
            statusStrip.Items.Add(lblStatus);
            this.Controls.Add(statusStrip);

            // Генерація завдань з математики для 6 класу
            GenerateTasks();

            // 3. Створення вкладок
            CreateTheoryTab();       // Вкладка 1: Теорія
            CreateTaskTabs();        // Вкладки 2-7: Завдання 1-6
            CreateSummaryTab();      // Вкладка 8: Результати та оцінка
        }

        private void GenerateTasks()
        {
            // Рівень 1: Додавання чисел з однаковими знаками (Завдання 1, 2)
            correctAnswers[0] = -12;
            lblQuestions[0] = new Label { Text = "Рівень 1. Завдання 1\r\nОбчислити: -5 + (-7)" };

            correctAnswers[1] = -35;
            lblQuestions[1] = new Label { Text = "Рівень 1. Завдання 2\r\nОбчислити: -15 + (-20)" };

            // Рівень 2: Додавання чисел з різними знаками (Завдання 3, 4)
            correctAnswers[2] = -4;
            lblQuestions[2] = new Label { Text = "Рівень 2. Завдання 3\r\nОбчислити: 10 + (-14)" };

            correctAnswers[3] = 7;
            lblQuestions[3] = new Label { Text = "Рівень 2. Завдання 4\r\nОбчислити: -8 + 15" };

            // Рівень 3: Віднімання від'ємних чисел (Завдання 5, 6)
            correctAnswers[4] = 8;
            lblQuestions[4] = new Label { Text = "Рівень 3. Завдання 5\r\nОбчислити: 5 - (-3)" };

            correctAnswers[5] = -16;
            lblQuestions[5] = new Label { Text = "Рівень 3. Завдання 6\r\nОбчислити: -10 - 6" };
        }

        // Вкладка 1: Теорія (за підручником 6 класу)
        private void CreateTheoryTab()
        {
            TabPage tabTheory = new TabPage("Теорія");
            tabTheory.BackColor = Color.FromArgb(245, 245, 245);

            Label lblTitle = new Label();
            lblTitle.Text = "Додавання та віднімання від'ємних чисел (Математика 6 клас)";
            lblTitle.Font = new Font("Arial", 13, FontStyle.Bold);
            lblTitle.Bounds = new Rectangle(20, 20, 700, 30);

            TextBox txtTheory = new TextBox();
            txtTheory.Multiline = true;
            txtTheory.ReadOnly = true;
            txtTheory.ScrollBars = ScrollBars.Vertical;
            txtTheory.Font = new Font("Arial", 11);
            txtTheory.Bounds = new Rectangle(20, 60, 740, 340);

            txtTheory.Text =
                "ПРАВИЛО 1. Додавання від'ємних чисел (з однаковими знаками):\r\n" +
                "Щоб скласти два від'ємних числа, треба додати їхні модулі і перед отриманим числом поставити знак мінус.\r\n" +
                "Приклад: -5 + (-7) = - (5 + 7) = -12\r\n\r\n" +
                "ПРАВИЛО 2. Додавання чисел з різними знаками:\r\n" +
                "Щоб скласти два числа з різними знаками, треба від більшого модуля відняти менший і перед результатами поставити знак числа з більшим модулем.\r\n" +
                "Приклад: -8 + 15 = +(15 - 8) = 7\r\n" +
                "Приклад: 10 + (-14) = -(14 - 10) = -4\r\n\r\n" +
                "ПРАВИЛО 3. Віднімання від'ємних чисел:\r\n" +
                "Щоб від одного числа відняти інше, можна до зменшуваного додати число, протилежне від'ємнику: a - b = a + (-b).\r\n" +
                "Приклад: 5 - (-3) = 5 + 3 = 8\r\n" +
                "Приклад: -10 - 6 = -10 + (-6) = -16\r\n\r\n" +
                "Переходьте до наступних вкладок («Завдання 1-6»), щоб перевірити свої знання на практиці!";

            tabTheory.Controls.Add(lblTitle);
            tabTheory.Controls.Add(txtTheory);
            tabControl.TabPages.Add(tabTheory);
        }

        // Вкладки із завданнями
        private void CreateTaskTabs()
        {
            for (int i = 0; i < 6; i++)
            {
                int taskIndex = i;
                TabPage tabTask = new TabPage($"Завдання {taskIndex + 1}");
                tabTask.BackColor = Color.FromArgb(240, 240, 240);

                // Текст завдання
                lblQuestions[taskIndex].Font = new Font("Arial", 12, FontStyle.Regular);
                lblQuestions[taskIndex].Bounds = new Rectangle(30, 25, 600, 45);
                tabTask.Controls.Add(lblQuestions[taskIndex]);

                // Підказка "Введіть відповідь:"
                Label lblPrompt = new Label();
                lblPrompt.Text = "Введіть вашу відповідь (ціле число):";
                lblPrompt.Font = new Font("Arial", 10, FontStyle.Italic);
                lblPrompt.Bounds = new Rectangle(30, 75, 300, 20);
                tabTask.Controls.Add(lblPrompt);

                // Поле для введення відповіді
                txtAnswers[taskIndex] = new TextBox();
                txtAnswers[taskIndex].Font = new Font("Arial", 12);
                txtAnswers[taskIndex].Bounds = new Rectangle(30, 100, 500, 30);
                tabTask.Controls.Add(txtAnswers[taskIndex]);

                // Кнопка "Обчислити"
                Button btnCheck = new Button();
                btnCheck.Text = "Обчислити";
                btnCheck.Font = new Font("Arial", 10);
                btnCheck.Size = new Size(160, 40);
                btnCheck.Location = new Point(30, 150);
                btnCheck.BackColor = Color.White;

                // Результат перевірки відповіді
                lblResults[taskIndex] = new Label();
                lblResults[taskIndex].Font = new Font("Arial", 11, FontStyle.Bold);
                lblResults[taskIndex].Bounds = new Rectangle(30, 210, 600, 30);
                tabTask.Controls.Add(lblResults[taskIndex]);

                btnCheck.Click += (sender, e) => {
                    CheckAnswer(taskIndex);
                };

                tabTask.Controls.Add(btnCheck);
                tabControl.TabPages.Add(tabTask);
            }
        }

        // Вкладка підсумків
        private void CreateSummaryTab()
        {
            TabPage tabSummary = new TabPage("Результати");
            tabSummary.BackColor = Color.FromArgb(245, 245, 245);

            Button btnCalculateMark = new Button();
            btnCalculateMark.Text = "Підбити підсумки та виставити оцінку";
            btnCalculateMark.Font = new Font("Arial", 11, FontStyle.Bold);
            btnCalculateMark.Size = new Size(350, 50);
            btnCalculateMark.Location = new Point(30, 30);
            btnCalculateMark.BackColor = Color.LightBlue;

            Label lblMarkResult = new Label();
            lblMarkResult.Font = new Font("Arial", 14, FontStyle.Bold);
            lblMarkResult.Bounds = new Rectangle(30, 100, 700, 250);
            lblMarkResult.Text = "Натисніть кнопку вище, щоб дізнатися свою оцінку.";

            btnCalculateMark.Click += (sender, e) => {
                int correctCount = 0;
                int unansweredCount = 0;

                for (int i = 0; i < 6; i++)
                {
                    if (string.IsNullOrWhiteSpace(txtAnswers[i].Text))
                    {
                        unansweredCount++;
                        continue;
                    }

                    if (int.TryParse(txtAnswers[i].Text, out int userAnswer))
                    {
                        if (userAnswer == correctAnswers[i])
                            correctCount++;
                    }
                }

                // Оцінка за 12-бальною системою (6 завдань по 2 бали кожне)
                int mark = correctCount * 2;

                lblMarkResult.Text = $"Результати тестування:\n" +
                                     $"-------------------------------------\n" +
                                     $"Правильних відповідей: {correctCount} з 6\n" +
                                     $"Невирішених завдань: {unansweredCount}\n\n" +
                                     $"Ваша підсумкова оцінка: {mark} балів!\n\n";

                if (mark >= 10)
                    lblMarkResult.Text += "Чудово! Матеріал засвоєно на відмінно.";
                else if (mark >= 7)
                    lblMarkResult.Text += "Добре! Але рекомендується ще раз переглянути правила.";
                else
                    lblMarkResult.Text += "Уважно прочитайте вкладку 'Теорія' та спробуйте ще раз.";

                lblStatus.Text = $"Роботу завершено. Оцінка: {mark} балів.";
            };

            tabSummary.Controls.Add(btnCalculateMark);
            tabSummary.Controls.Add(lblMarkResult);
            tabControl.TabPages.Add(tabSummary);
        }

        // Логіка перевірки відповіді
        private void CheckAnswer(int index)
        {
            string userInput = txtAnswers[index].Text.Trim();

            if (string.IsNullOrEmpty(userInput))
            {
                lblResults[index].ForeColor = Color.OrangeRed;
                lblResults[index].Text = "Будь ласка, введіть число!";
                return;
            }

            if (int.TryParse(userInput, out int userNum))
            {
                if (userNum == correctAnswers[index])
                {
                    lblResults[index].ForeColor = Color.Green;
                    lblResults[index].Text = "Правильно! Чудова робота.";
                    lblStatus.Text = $"Завдання {index + 1}: Виконано правильно.";
                }
                else
                {
                    lblResults[index].ForeColor = Color.Red;
                    lblResults[index].Text = $"Неправильно. Згадай правила з вкладки 'Теорія'!";
                    lblStatus.Text = $"Завдання {index + 1}: Помилка у відповіді.";
                }
            }
            else
            {
                lblResults[index].ForeColor = Color.Purple;
                lblResults[index].Text = "Помилка введення! Вводьте лише цілі числа (наприклад: -12 або 5).";
            }
        }
    }
}