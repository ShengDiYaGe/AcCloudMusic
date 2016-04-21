// *****************************************************
// Morse
// MainWindow.cs
// 
// Author: Steve Palmer (spalmer@cix)
// 
// Created: 14/07/2014 13:49
//  
// Copyright (C) 2014 Steve Palmer. All Rights Reserved.
// *****************************************************

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Morse.Properties;
using System.IO;

namespace Morse
{
    public sealed partial class MainWindow : Form
    {
        private readonly List<List<string>> _games = new List<List<string>>();
        private readonly Timer _turnTimer = new Timer();
        private Random _randomGenerator;

        private string _currentWord;
        private int _currentIndex;
        private int[] _indexes = new int[0];

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Current game level
        /// </summary>
        public int CurrentLevel { get; set; }

        /// <summary>
        /// Number of correct answers at the current level
        /// </summary>
        public int CorrectCount { get; set; }

        private void MainWindow_Load(object sender, EventArgs e) {
 
            using (StreamReader tr = new StreamReader("morse.txt")) 
            {
                string line = tr.ReadLine();
                while (line != null)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        string [] words = line.Trim().Split(new [] { ','});
                        if (words.Length > 0)
                        {
                            _games.Add(new List<string>(words));
                        }
                    }
                    line = tr.ReadLine();
                }
            }

            _randomGenerator = new Random((int) DateTime.Now.Ticks & 0x0000FFFF);

            _turnTimer.Interval = 1000;
            _turnTimer.Tick += TurnTimerOnTick;

            CurrentLevel = 0;
            CorrectCount = 0;

            NextTurn();
        }

        private void TurnTimerOnTick(object sender, EventArgs eventArgs)
        {
            NextTurn();
        }

        private void NextTurn()
        {
            _turnTimer.Stop();

            if (_currentIndex == _indexes.Length)
            {
                NextIndex();
            }

            _currentWord = _games[CurrentLevel][_indexes[_currentIndex++]];

            displayWord.Text = MorseCode.ToMorse(_currentWord);
            inputField.Text = string.Empty;
            resultIcon.Image = null;

            currentLevel.Text = string.Format("Level {0}", CurrentLevel + 1);

            ActiveControl = inputField;
        }

        private void NextIndex()
        {
            int count = _games[CurrentLevel].Count;
            _indexes = new int[count];

            for (int c = 0; c < count; ++c)
            {
                _indexes[c] = c;
            }

            // Shuffle
            for (int c = 0; c < count; ++c)
            {
                int d = _randomGenerator.Next(0, count - 1);
                int temp = _indexes[d];
                _indexes[d] = _indexes[c];
                _indexes[c] = temp;
            }

            _currentIndex = 0;
        }

        private void HandleAnswer()
        {
            string inputText = inputField.Text.Trim().ToUpper();

            if (inputText == _currentWord)
            {
                displayWord.Text = inputText;
                _turnTimer.Start();

                ++CorrectCount;
                if (CorrectCount == _games[CurrentLevel].Count && CurrentLevel < _games.Count - 1)
                {
                    ++CurrentLevel;
                    CorrectCount = 0;

                    NextIndex();
                }

                resultIcon.Image = Resources.Right;
            }
            else
            {
                inputField.Text = string.Empty;

                resultIcon.Image = Resources.Wrong;
            }
            ActiveControl = inputField;
        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            HandleAnswer();
        }

        private void inputField_TextChanged(object sender, EventArgs e)
        {
            resultIcon.Image = null;
        }

        private void inputField_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                HandleAnswer();
                e.Handled = true;
            }
        }
    }
}