using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROJECT
{
    
    public partial class Cipher : Form
    {
        //vigerene start

        private static int Mod(int a, int b)
        {
            return (a % b + b) % b;
        }

        private static string VCipher(string input, string key, bool encipher)
        {
            for (int i = 0; i < key.Length; ++i)
                if (!char.IsLetter(key[i]))
                    return null; // Error

            string output = string.Empty;
            int nonAlphaCharCount = 0;

            for (int i = 0; i < input.Length; ++i)
            {
                if (char.IsLetter(input[i]))
                {
                    bool cIsUpper = char.IsUpper(input[i]);
                    char offset = cIsUpper ? 'A' : 'a';
                    int keyIndex = (i - nonAlphaCharCount) % key.Length;
                    int k = (cIsUpper ? char.ToUpper(key[keyIndex]) : char.ToLower(key[keyIndex])) - offset;
                    k = encipher ? k : -k;
                    char ch = (char)((Mod(((input[i] + k) - offset), 26)) + offset);
                    output += ch;
                }
                else
                {
                    output += input[i];
                    ++nonAlphaCharCount;
                }
            }

            return output;
        }

        public static string VEncipher(string input, string key)
        {
            return VCipher(input, key, true);
        }

        public static string VDecipher(string input, string key)
        {
            return VCipher(input, key, false);
        }

        //vigenere end
        public static char cipher(char ch, int key)
        {
            if (!char.IsLetter(ch))
            {

                return ch;
            }

            char d = char.IsUpper(ch) ? 'A' : 'a';
            return (char)((((ch + key) - d) % 26) + d);

        }

        public static string Encipher(string input, int key)
        {
            string output = string.Empty;

            foreach (char ch in input)
                output += cipher(ch, key);

            return output;
        }

        public static string Decipher(string input, int key)
        {
            return Encipher(input, 26 - key);
        }

        public Cipher()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {   
            listBox1.Items.Add("Encrypted Text is:");
            string text;
            int key;
            key = (int)numericUpDown1.Value;
            text = textBox1.Text;
            string cipherText = Encipher(text, key);
            listBox1.Items.Add(cipherText);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("Decrypted Text is:");
            string text;
            int key;
            key = (int)numericUpDown1.Value;
            text = textBox1.Text;
            string cipherText = Decipher(text, key);
           // string cipherText2 = Encipher(cipherText, key);
           //listBox1.Items.Add(cipherText2);
            listBox1.Items.Add(cipherText);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            {
                listBox1.Items.Add("Encrypted Text is:");
                string text;
                string vkey;
                vkey = textBox2.Text;
                text = textBox1.Text;
                string cipherText = VEncipher(text, vkey);
                string plaintext = VDecipher(cipherText, vkey);
                listBox1.Items.Add(cipherText);
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("Decrypted Text is:");
            string text;
            string vkey;
            vkey = textBox2.Text;
            text = textBox1.Text;
            string cipherText = VEncipher(text, vkey);
            string plaintext = VDecipher(cipherText, vkey);
            listBox1.Items.Add(plaintext);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
