using System;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Threading;
using System.Windows.Forms;

namespace WFA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.ColumnCount = 10;
            dataGridView1.RowCount = 10;
            try
            {
                using (MemoryMappedFile mmf = MemoryMappedFile.OpenExisting("testmap"))
                {

                    Mutex mutex = Mutex.OpenExisting("testmapmutex");
                    while (true)
                    {
                        mutex.WaitOne();
                        byte[] life = new byte[100];
                        byte[] buff = new byte[100];
                        using (MemoryMappedViewStream stream = mmf.CreateViewStream())
                        {
                            BinaryReader reader = new BinaryReader(stream);
                            for (int i = 0; i < 100; i++)
                            {
                                life[i] = buff[i] = reader.ReadByte();
                            }
                        }
                        
                        for (int i = 0; i < 10; i++)
                        {
                            for (int j = 0; j < 10; j++)
                            {
                                int sum = 0;
                                if (i == 0)
                                {
                                    if (j == 0)
                                    {
                                        if (buff[i * 10 + j + 1] == 1)
                                            sum++;
                                        if (buff[(i + 1) * 10 + j + 1] == 1)
                                            sum++;
                                        if (buff[(i + 1) * 10 + j] == 1)
                                            sum++;
                                        if (buff[(i + 1) * 10 + 9] == 1)
                                            sum++;
                                        if (buff[i * 10 + 9] == 1)
                                            sum++;
                                        if (buff[9 * 10 + 9] == 1)
                                            sum++;
                                        if (buff[9 * 10 + j] == 1)
                                            sum++;
                                        if (buff[9 * 10 + j + 1] == 1)
                                            sum++;
                                    }
                                    else if (j == 9)
                                    {
                                        if (buff[i * 10 + 9 - 1] == 1)
                                            sum++;
                                        if (buff[(i + 1) * 10 + 9 - 1] == 1)
                                            sum++;
                                        if (buff[(i + 1) * 10 + 9] == 1)
                                            sum++;
                                        if (buff[(i + 1) * 10 + 0] == 1)
                                            sum++;
                                        if (buff[i * 10 + 0] == 1)
                                            sum++;
                                        if (buff[9 * 10 + 0] == 1)
                                            sum++;
                                        if (buff[9 * 10 + 9] == 1)
                                            sum++;
                                        if (buff[9 * 10 + 9 - 1] == 1)
                                            sum++;
                                    }
                                    else
                                    {
                                        if (buff[i * 10 + j - 1] == 1)
                                            sum++;
                                        if (buff[(i + 1) * 10 + j - 1] == 1)
                                            sum++;
                                        if (buff[(i + 1) * 10 + j] == 1)
                                            sum++;
                                        if (buff[(i + 1) * 10 + j + 1] == 1)
                                            sum++;
                                        if (buff[i * 10 + j + 1] == 1)
                                            sum++;
                                        if (buff[9 * 10 + j - 1] == 1)
                                            sum++;
                                        if (buff[9 * 10 + j] == 1)
                                            sum++;
                                        if (buff[9 * 10 + j + 1] == 1)
                                            sum++;
                                    }
                                }
                                else if (i == 9)
                                {
                                    if (j == 0)
                                    {
                                        if (buff[i * 10 + j + 1] == 1)
                                            sum++;
                                        if (buff[0 * 10 + j + 1] == 1)
                                            sum++;
                                        if (buff[0 * 10 + j] == 1)
                                            sum++;
                                        if (buff[0 * 10 + 9] == 1)
                                            sum++;
                                        if (buff[9 * 10 + 9] == 1)
                                            sum++;
                                        if (buff[(9 - 1) * 10 + 9] == 1)
                                            sum++;
                                        if (buff[(9 - 1) * 10 + j] == 1)
                                            sum++;
                                        if (buff[(9 - 1) * 10 + j + 1] == 1)
                                            sum++;
                                    }
                                    else if (j == 9)
                                    {
                                        if (buff[i * 10 + 9 - 1] == 1)
                                            sum++;
                                        if (buff[(i - 1) * 10 + 9 - 1] == 1)
                                            sum++;
                                        if (buff[i * 10 + 9] == 1)
                                            sum++;
                                        if (buff[(i - 1) * 10 + 0] == 1)
                                            sum++;
                                        if (buff[0 * 10 + 0] == 1)
                                            sum++;
                                        if (buff[9 * 10 + 0] == 1)
                                            sum++;
                                        if (buff[0 * 10 + 9] == 1)
                                            sum++;
                                        if (buff[0 * 10 + 9 - 1] == 1)
                                            sum++;
                                    }
                                    else
                                    {
                                        if (buff[i * 10 + j - 1] == 1)
                                            sum++;
                                        if (buff[(i - 1) * 10 + j - 1] == 1)
                                            sum++;
                                        if (buff[(i - 1) * 10 + j] == 1)
                                            sum++;
                                        if (buff[(i - 1) * 10 + j + 1] == 1)
                                            sum++;
                                        if (buff[i * 10 + j + 1] == 1)
                                            sum++;
                                        if (buff[0 * 10 + j + 1] == 1)
                                            sum++;
                                        if (buff[0 * 10 + j] == 1)
                                            sum++;
                                        if (buff[0 * 10 + j - 1] == 1)
                                            sum++;
                                    }
                                }
                                else
                                {
                                    if (j == 0)
                                    {
                                        if (buff[(i - 1) * 10 + j] == 1)
                                            sum++;
                                        if (buff[(i - 1) * 10 + j + 1] == 1)
                                            sum++;
                                        if (buff[i * 10 + j + 1] == 1)
                                            sum++;
                                        if (buff[(i + 1) * 10 + j + 1] == 1)
                                            sum++;
                                        if (buff[(i + 1) * 10 + j] == 1)
                                            sum++;
                                        if (buff[(i - 1) * 10 + 9] == 1)
                                            sum++;
                                        if (buff[i * 10 + 9] == 1)
                                            sum++;
                                        if (buff[(i + 1) * 10 + 9] == 1)
                                            sum++;
                                    }
                                    else if (j == 9)
                                    {
                                        if (buff[(i - 1) * 10 + 9] == 1)
                                            sum++;
                                        if (buff[(i - 1) * 10 + j - 1] == 1)
                                            sum++;
                                        if (buff[i * 10 + j - 1] == 1)
                                            sum++;
                                        if (buff[(i + 1) * 10 + j - 1] == 1)
                                            sum++;
                                        if (buff[(i + 1) * 10 + j] == 1)
                                            sum++;
                                        if (buff[(i - 1) * 10 + 0] == 1)
                                            sum++;
                                        if (buff[i * 10 + 0] == 1)
                                            sum++;
                                        if (buff[(i + 1) * 10 + 0] == 1)
                                            sum++;
                                    }
                                    else
                                    {
                                        if (buff[i * 10 + j - 1] == 1)
                                            sum++;
                                        if (buff[(i - 1) * 10 + j - 1] == 1)
                                            sum++;
                                        if (buff[(i - 1) * 10 + j] == 1)
                                            sum++;
                                        if (buff[(i - 1) * 10 + j + 1] == 1)
                                            sum++;
                                        if (buff[i * 10 + j + 1] == 1)
                                            sum++;
                                        if (buff[(i + 1) * 10 + j + 1] == 1)
                                            sum++;
                                        if (buff[(i + 1) * 10 + j] == 1)
                                            sum++;
                                        if (buff[(i + 1) * 10 + j - 1] == 1)
                                            sum++;
                                    }
                                }
                                if (buff[i * 10 + j] == 0 && sum == 3)
                                {
                                    life[i * 10 + j] = 1;
                                    dataGridView1[i, j].Style.BackColor = System.Drawing.Color.Black;
                                }

                                if (buff[i * 10 + j] == 1 && (sum > 3 || sum < 2))
                                {
                                    life[i * 10 + j] = 0;
                                    dataGridView1[i, j].Style.BackColor = System.Drawing.Color.White;
                                }
                            }
                        }
                        using (MemoryMappedViewStream stream = mmf.CreateViewStream())
                        {
                            BinaryWriter writer = new BinaryWriter(stream);
                            for (int i = 0; i < 100; i++)
                            {
                                writer.Write(life[i]);
                            }
                        }
                        Thread.Sleep(1000);
                        mutex.ReleaseMutex();
                    }
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Memory-mapped file does not exist. Run Process A first.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
