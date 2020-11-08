using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMICalculator
{
    public partial class CalcForm : Form
    {
        public CalcForm()
        {
            InitializeComponent();
        }

        public String calculateBMI()
        {
            String message = "";
            //klamra try catch obsługująca wyjątek FormatException
            try
            {
                //pobranie i sprawdzenie wieku
                int age = Convert.ToInt16(ageTextBox.Text);
                if (age < 18)
                {
                    message = "Jesteś za młoda na obliczenie twojego BMI";
                }
                else
                {
                    //pobranie danych i obliczenie BMI
                    double mass = Convert.ToDouble(massTextBox.Text);
                    double height = Convert.ToDouble(heightTextBox.Text) / 100;
                    double bmi = mass / Math.Pow(height, 2);
                    int correction = 0;
                    message = "Twoje BMI wynosi " + Math.Round(bmi, 2);
                    //korekcja zakresu ze względu na płeć
                    if (maleRadioButton.Checked == true)
                    {
                        correction += 1;
                    }
                    //korekcja zakresu ze względu na wiek
                    if (age >= 25 && age < 35)
                    {
                        correction += 1;
                    }
                    else if (age >= 35 && age < 45)
                    {
                        correction += 2;
                    }
                    else if (age >= 45 && age < 55)
                    {
                        correction += 3;
                    }
                    else if (age >= 55 && age < 65)
                    {
                        correction += 4;
                    }
                    else if (age >= 65)
                    {
                        correction += 5;
                    }
                    //wygenerowanie dodatkowej odpowiedzi
                    if (bmi < 19 + correction)
                    {
                        message += "\nMasz niedowagę";
                    }
                    else if (bmi >= 19 + correction && bmi < 24 + correction)
                    {
                        message += "\nMasz poprawną masę";
                    }
                    else if (bmi >= 24 + correction && bmi < 29 + correction)
                    {
                        message += "\nMasz nadwagę";
                    }
                    else if (bmi >= 29 + correction && bmi < 39 + correction)
                    {
                        message += "\nMasz otyłość";
                    }
                    else if (bmi > 39 + correction)
                    {
                        message += "\nMasz poważną otyłość";
                    }
                    else
                    {
                        message = "Niepoprawna wartość BMI";
                    }
                }
            }
            catch (FormatException)
            {
                message = "Błędne dane";
            }
            return message; 
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(calculateBMI(), "Wynik");
        }
    }
}
