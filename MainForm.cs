using System;
using System.Collections;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WordleHelper
{
    //TODO if you can figure out how to update list dynamically have the list populate on the click or text change event instead of clicking a button
    //TODO add a priority to the list sort that lets the letters use most often in the words to push most liekly words to top?
    //TODO or add a list of most common letters sorted form most to least and update that as letters are used.
    //TODO if you can implement the most common letter list add a hint(or help clearing letters) button 
        //to show a list of words with the most common letters in them that only appear once in the word so that they can check the letters off quicker
    public partial class MainForm : Form
    {
        char[] green = new char[5] { ' ', ' ', ' ', ' ', ' ' };
        string[] yellow = new string[5]{"", "", "", "" , ""};

        List<string> fiveLetterDictionary;
        List<string> wordList = new List<string>();
        BindingSource bs = new BindingSource();

        public MainForm()
        {
            InitializeComponent();
            generateDictionary();
        }

        private void generateDictionary()
        {
            fiveLetterDictionary = new List<string>();
            //TODO update the file name to work with a file included with project
            string file5LetterList = "C:\\Users\\SChmielowski\\Google Drive\\Programming\\C#\\WordleHelper\\5LetterWordList.txt";
            StreamReader sr5LetterList = new StreamReader(file5LetterList);
            String line = sr5LetterList.ReadLine();
            while (line != null)
            {
                fiveLetterDictionary.Add(line);
                line = sr5LetterList.ReadLine();
            }
            sr5LetterList.Close();

            wordList = fiveLetterDictionary;
            bs.DataSource = wordList;
        }

        private void greenLetters()
        {
            //remove all words from wordList that do not contain needed letters
            for (int i = 0; i < 5; i++)
            {
                Stack toRemove = new Stack();
                if (green[i] != ' ')
                {
                    for (int j = 0; j < wordList.Count; j++)
                    {
                        if (!wordList[j][i].Equals(Char.ToLower(green[i])))
                        {
                            toRemove.Push(j);
                        }
                    }
                }
                while (toRemove.Count > 0)
                {
                    wordList.RemoveAt((int)toRemove.Pop());
                }
            }
        }

        private void yellowLetters()
        {
            //remove all words from wordList that do not contain needed letters
            for (int i = 0; i < 5; i++)
            {
                if (yellow[i].Length > 0)
                {
                    char[] temp = new char[yellow.Length];
                    foreach (char c in yellow[i])
                    {
                        char check = Char.ToLower(c);

                        Stack toRemove = new Stack();
                        for (int j = 0; j < wordList.Count; j++)
                        {
                            if (wordList[j][i].Equals(check))
                            {
                                toRemove.Push(j);
                                Console.WriteLine($"trying to remove: {wordList[j]}");
                            }
                        }
                        while (toRemove.Count > 0)
                        {
                            wordList.RemoveAt((int)toRemove.Pop());
                        }
                        wordList.RemoveAll(word => !word.Contains(check.ToString()));
                    }
                }
            }
        }

        private void redLetters()
        {
            var labels = new List<Label> { ignoredA, ignoredB, ignoredC, 
                ignoredD, ignoredE, ignoredF, ignoredG, ignoredH, ignoredI,
                ignoredJ, ignoredK, ignoredL, ignoredM, ignoredN, ignoredO, 
                ignoredP, ignoredQ, ignoredR, ignoredS, ignoredT, ignoredU, 
                ignoredV, ignoredW, ignoredX, ignoredY, ignoredZ };
            foreach (Label label in labels)
            {
                if (label.Enabled && label.Visible)
                    {
                        wordList.RemoveAll(word => word.Contains(label.Text.ToLower()));
                    }
            }
        }

        // does nothing at the moment but if list cant be updated propery creating a new box might work?
        /*        private void newBox()
                {
                    listBox1 = new System.Windows.Forms.ListBox();

                    listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    listBox1.FormattingEnabled = true;
                    listBox1.ItemHeight = 37;
                    listBox1.Location = new System.Drawing.Point(46, 722);
                    listBox1.MultiColumn = true;
                    listBox1.Name = "listBox1";
                    listBox1.SelectionMode = System.Windows.Forms.SelectionMode.None;
                    listBox1.Size = new System.Drawing.Size(1108, 522);
                    listBox1.TabIndex = 0;
                    listBox1.TabStop = false;
                }
        */
        // horribly inefficient way to copy list over
        /*        private void resetToDict()
                {
                    wordList.Clear();
                    foreach (string word in fiveLetterDictionary)
                    {
                        wordList.Add(word);
                        Console.WriteLine(word);//TODO Remove-----------------------------------------------------------
                    }
                    Console.WriteLine("Reset Complete");//TODO Remove-----------------------------------------------------------
                }
        */
        private void click_ignoreLetter(object sender, EventArgs e)
        {
            Label button = (Label)sender;

            switch (button.Text)
            {
                case "A":
                    ignoredA.Enabled = true;
                    ignoredA.Visible = true;
                    labelA.Enabled = false;
                    labelA.Visible = false;
                    break;
                case "B":
                    ignoredB.Enabled = true;
                    ignoredB.Visible = true;
                    labelB.Enabled = false;
                    labelB.Visible = false;
                    break;
                case "C":
                    ignoredC.Enabled = true;
                    ignoredC.Visible = true;
                    labelC.Enabled = false;
                    labelC.Visible = false;
                    break;
                case "D":
                    ignoredD.Enabled = true;
                    ignoredD.Visible = true;
                    labelD.Enabled = false;
                    labelD.Visible = false;
                    break;
                case "E":
                    ignoredE.Enabled = true;
                    ignoredE.Visible = true;
                    labelE.Enabled = false;
                    labelE.Visible = false;
                    break;
                case "F":
                    ignoredF.Enabled = true;
                    ignoredF.Visible = true;
                    labelF.Enabled = false;
                    labelF.Visible = false;
                    break;
                case "G":
                    ignoredG.Enabled = true;
                    ignoredG.Visible = true;
                    labelG.Enabled = false;
                    labelG.Visible = false;
                    break;
                case "H":
                    ignoredH.Enabled = true;
                    ignoredH.Visible = true;
                    labelH.Enabled = false;
                    labelH.Visible = false;
                    break;
                case "I":
                    ignoredI.Enabled = true;
                    ignoredI.Visible = true;
                    labelI.Enabled = false;
                    labelI.Visible = false;
                    break;
                case "J":
                    ignoredJ.Enabled = true;
                    ignoredJ.Visible = true;
                    labelJ.Enabled = false;
                    labelJ.Visible = false;
                    break;
                case "K":
                    ignoredK.Enabled = true;
                    ignoredK.Visible = true;
                    labelK.Enabled = false;
                    labelK.Visible = false;
                    break;
                case "L":
                    ignoredL.Enabled = true;
                    ignoredL.Visible = true;
                    labelL.Enabled = false;
                    labelL.Visible = false;
                    break;
                case "M":
                    ignoredM.Enabled = true;
                    ignoredM.Visible = true;
                    labelM.Enabled = false;
                    labelM.Visible = false;
                    break;
                case "N":
                    ignoredN.Enabled = true;
                    ignoredN.Visible = true;
                    labelN.Enabled = false;
                    labelN.Visible = false;
                    break;
                case "O":
                    ignoredO.Enabled = true;
                    ignoredO.Visible = true;
                    labelO.Enabled = false;
                    labelO.Visible = false;
                    break;
                case "P":
                    ignoredP.Enabled = true;
                    ignoredP.Visible = true;
                    labelP.Enabled = false;
                    labelP.Visible = false;
                    break;
                case "Q":
                    ignoredQ.Enabled = true;
                    ignoredQ.Visible = true;
                    labelQ.Enabled = false;
                    labelQ.Visible = false;
                    break;
                case "R":
                    ignoredR.Enabled = true;
                    ignoredR.Visible = true;
                    labelR.Enabled = false;
                    labelR.Visible = false;
                    break;
                case "S":
                    ignoredS.Enabled = true;
                    ignoredS.Visible = true;
                    labelS.Enabled = false;
                    labelS.Visible = false;
                    break;
                case "T":
                    ignoredT.Enabled = true;
                    ignoredT.Visible = true;
                    labelT.Enabled = false;
                    labelT.Visible = false;
                    break;
                case "U":
                    ignoredU.Enabled = true;
                    ignoredU.Visible = true;
                    labelU.Enabled = false;
                    labelU.Visible = false;
                    break;
                case "V":
                    ignoredV.Enabled = true;
                    ignoredV.Visible = true;
                    labelV.Enabled = false;
                    labelV.Visible = false;
                    break;
                case "W":
                    ignoredW.Enabled = true;
                    ignoredW.Visible = true;
                    labelW.Enabled = false;
                    labelW.Visible = false;
                    break;
                case "X":
                    ignoredX.Enabled = true;
                    ignoredX.Visible = true;
                    labelX.Enabled = false;
                    labelX.Visible = false;
                    break;
                case "Y":
                    ignoredY.Enabled = true;
                    ignoredY.Visible = true;
                    labelY.Enabled = false;
                    labelY.Visible = false;
                    break;
                case "Z":
                    ignoredZ.Enabled = true;
                    ignoredZ.Visible = true;
                    labelZ.Enabled = false;
                    labelZ.Visible = false;
                    break;
            }
        }

        private void click_includeLetter(object sender, EventArgs e)
        {
            Label button = (Label)sender;

            switch (button.Text)
            {
                case "A":
                    ignoredA.Enabled = false;
                    ignoredA.Visible = false;
                    labelA.Enabled = true;
                    labelA.Visible = true;
                    break;
                case "B":
                    ignoredB.Enabled = false;
                    ignoredB.Visible = false;
                    labelB.Enabled = true;
                    labelB.Visible = true;
                    break;
                case "C":
                    ignoredC.Enabled = false;
                    ignoredC.Visible = false;
                    labelC.Enabled = true;
                    labelC.Visible = true;
                    break;
                case "D":
                    ignoredD.Enabled = false;
                    ignoredD.Visible = false;
                    labelD.Enabled = true;
                    labelD.Visible = true;
                    break;
                case "E":
                    ignoredE.Enabled = false;
                    ignoredE.Visible = false;
                    labelE.Enabled = true;
                    labelE.Visible = true;
                    break;
                case "F":
                    ignoredF.Enabled = false;
                    ignoredF.Visible = false;
                    labelF.Enabled = true;
                    labelF.Visible = true;
                    break;
                case "G":
                    ignoredG.Enabled = false;
                    ignoredG.Visible = false;
                    labelG.Enabled = true;
                    labelG.Visible = true;
                    break;
                case "H":
                    ignoredH.Enabled = false;
                    ignoredH.Visible = false;
                    labelH.Enabled = true;
                    labelH.Visible = true;
                    break;
                case "I":
                    ignoredI.Enabled = false;
                    ignoredI.Visible = false;
                    labelI.Enabled = true;
                    labelI.Visible = true;
                    break;
                case "J":
                    ignoredJ.Enabled = false;
                    ignoredJ.Visible = false;
                    labelJ.Enabled = true;
                    labelJ.Visible = true;
                    break;
                case "K":
                    ignoredK.Enabled = false;
                    ignoredK.Visible = false;
                    labelK.Enabled = true;
                    labelK.Visible = true;
                    break;
                case "L":
                    ignoredL.Enabled = false;
                    ignoredL.Visible = false;
                    labelL.Enabled = true;
                    labelL.Visible = true;
                    break;
                case "M":
                    ignoredM.Enabled = false;
                    ignoredM.Visible = false;
                    labelM.Enabled = true;
                    labelM.Visible = true;
                    break;
                case "N":
                    ignoredN.Enabled = false;
                    ignoredN.Visible = false;
                    labelN.Enabled = true;
                    labelN.Visible = true;
                    break;
                case "O":
                    ignoredO.Enabled = false;
                    ignoredO.Visible = false;
                    labelO.Enabled = true;
                    labelO.Visible = true;
                    break;
                case "P":
                    ignoredP.Enabled = false;
                    ignoredP.Visible = false;
                    labelP.Enabled = true;
                    labelP.Visible = true;
                    break;
                case "Q":
                    ignoredQ.Enabled = false;
                    ignoredQ.Visible = false;
                    labelQ.Enabled = true;
                    labelQ.Visible = true;
                    break;
                case "R":
                    ignoredR.Enabled = false;
                    ignoredR.Visible = false;
                    labelR.Enabled = true;
                    labelR.Visible = true;
                    break;
                case "S":
                    ignoredS.Enabled = false;
                    ignoredS.Visible = false;
                    labelS.Enabled = true;
                    labelS.Visible = true;
                    break;
                case "T":
                    ignoredT.Enabled = false;
                    ignoredT.Visible = false;
                    labelT.Enabled = true;
                    labelT.Visible = true;
                    break;
                case "U":
                    ignoredU.Enabled = false;
                    ignoredU.Visible = false;
                    labelU.Enabled = true;
                    labelU.Visible = true;
                    break;
                case "V":
                    ignoredV.Enabled = false;
                    ignoredV.Visible = false;
                    labelV.Enabled = true;
                    labelV.Visible = true;
                    break;
                case "W":
                    ignoredW.Enabled = false;
                    ignoredW.Visible = false;
                    labelW.Enabled = true;
                    labelW.Visible = true;
                    break;
                case "X":
                    ignoredX.Enabled = false;
                    ignoredX.Visible = false;
                    labelX.Enabled = true;
                    labelX.Visible = true;
                    break;
                case "Y":
                    ignoredY.Enabled = false;
                    ignoredY.Visible = false;
                    labelY.Enabled = true;
                    labelY.Visible = true;
                    break;
                case "Z":
                    ignoredZ.Enabled = false;
                    ignoredZ.Visible = false;
                    labelZ.Enabled = true;
                    labelZ.Visible = true;
                    break;
            }
        }

        private void click_GenerateWords(object sender, EventArgs e)
        {
            greenLetters();
            yellowLetters();
            redLetters();

            listBox1.DataSource = bs;
            bs.ResetBindings(false);
        }


        private void click_updateList(object sender, EventArgs e)
        {
            // this should only be run when you need to update the list of five letter words.
            //TODO update this to use a file located in project instead of shipping this program with my file path?
            string file5LetterList = "C:\\Users\\SChmielowski\\Google Drive\\Programming\\C#\\WordleHelper\\5LetterWordList.txt";
            StreamWriter sw5LetterList = new StreamWriter(file5LetterList);

            string fileFullList = "C:\\Users\\SChmielowski\\Google Drive\\Programming\\C#\\WordleHelper\\FullWordList.txt";
            StreamReader srFullList = new StreamReader(fileFullList);
            String line = srFullList.ReadLine();
            while (line != null)
            {
                line = line.Replace("\"", "");
                if (line.Length == 5)
                    sw5LetterList.WriteLine(line);

                line = srFullList.ReadLine();
            }
            //close the file
            srFullList.Close();
            sw5LetterList.Close();

            Button button = (Button)sender;
            button.Text = "Done Updating!";
        }

        //makes sure input is only alphabet and backspace/delete
        private void keypress_checkInput(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void textchanged_Green(object sender, EventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            int pos = (textbox.Name[5] - '0') - 1;
            if (textbox.Text.Length > 0)
            {
                green[pos] = Char.ToLower(textbox.Text[0]);
            }
            else
            {
                green[pos] = ' ';
            }
        }

        private void textchanged_Yellow(object sender, EventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            int pos = (textbox.Name[5] - '0') - 1;
            if (textbox.Text.Length > 0)
            {
               yellow[pos] = textbox.Text;
            }
            else
            {
                yellow[pos] = "";
            }
        }

        private void click_Reset(object sender, EventArgs e)
        {
            //TODO if you can fix the dynamic updating, use this button as a quick clear for green yellow and red
            this.Hide();
            MainForm sistema = new MainForm();
            sistema.ShowDialog();
            this.Close();
        }
    }
}
