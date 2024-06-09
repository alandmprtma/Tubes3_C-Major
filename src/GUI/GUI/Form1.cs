using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;


using LogicData = GUI.Logic.Data;
using LogicManip = GUI.Logic.Manipulation;
using LogicKMP = GUI.Logic.KMP;
using RegexAlay = GUI.Logic.AlayConverter;
using HammingDistance = GUI.Logic.HammingDistance;
using Database = GUI.Database;
using System.Text.RegularExpressions;
using GUI.Database;

namespace GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.imageUploader = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.toggleButton1 = new GUI.ToggleButton();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.NIK = new System.Windows.Forms.Label();
            this.Nama = new System.Windows.Forms.Label();
            this.TempatLahir = new System.Windows.Forms.Label();
            this.TanggalLahir = new System.Windows.Forms.Label();
            this.GolonganDarah = new System.Windows.Forms.Label();
            this.Alamat = new System.Windows.Forms.Label();
            this.Agama = new System.Windows.Forms.Label();
            this.StatusPerkawinan = new System.Windows.Forms.Label();
            this.Pekerjaan = new System.Windows.Forms.Label();
            this.Kewarganegaraan = new System.Windows.Forms.Label();
            this.JenisKelamin = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imageUploader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // imageUploader
            // 
            this.imageUploader.BackColor = System.Drawing.Color.Transparent;
            this.imageUploader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imageUploader.Location = new System.Drawing.Point(39, 149);
            this.imageUploader.Name = "imageUploader";
            this.imageUploader.Size = new System.Drawing.Size(310, 332);
            this.imageUploader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageUploader.TabIndex = 0;
            this.imageUploader.TabStop = false;
            this.imageUploader.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // button1
            // 
            this.button1.AutoEllipsis = true;
            this.button1.BackColor = System.Drawing.Color.Khaki;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(39, 576);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 46);
            this.button1.TabIndex = 1;
            this.button1.Text = "Pilih Citra";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(399, 149);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(307, 332);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox2.Location = new System.Drawing.Point(751, 149);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(291, 332);
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(265, 588);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "KMP";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(428, 588);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "BM";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Khaki;
            this.button2.Location = new System.Drawing.Point(526, 580);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(141, 43);
            this.button2.TabIndex = 7;
            this.button2.Text = "Search";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(316, 596);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(135, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Sidik Jari Masukan";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(511, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Sidik Jari Cocok";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(860, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "List Biodata";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(177, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(725, 31);
            this.label7.TabIndex = 12;
            this.label7.Text = "Analisis Citra Sidik Jari dengan Algoritma KM dan BMP";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(245, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(589, 31);
            this.label8.TabIndex = 13;
            this.label8.Text = "Tugas Besar 3 Strategi Algoritma 2023/2024";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // toggleButton1
            // 
            this.toggleButton1.AutoSize = true;
            this.toggleButton1.BackColor = System.Drawing.Color.Transparent;
            this.toggleButton1.Location = new System.Drawing.Point(319, 588);
            this.toggleButton1.MinimumSize = new System.Drawing.Size(45, 22);
            this.toggleButton1.Name = "toggleButton1";
            this.toggleButton1.Size = new System.Drawing.Size(92, 22);
            this.toggleButton1.TabIndex = 4;
            this.toggleButton1.Text = "toggleButton1";
            this.toggleButton1.UseVisualStyleBackColor = false;
            this.toggleButton1.CheckedChanged += new System.EventHandler(this.toggleButton1_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Khaki;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(684, 576);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(284, 20);
            this.label9.TabIndex = 14;
            this.label9.Text = "Waktu Pencarian                        :  xxx ms";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Khaki;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(684, 611);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(273, 20);
            this.label10.TabIndex = 15;
            this.label10.Text = "Persentase Kecocokkan           :   xx %";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(858, 581);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(0, 13);
            this.label11.TabIndex = 16;
            // 
            // NIK
            // 
            this.NIK.AutoSize = true;
            this.NIK.BackColor = System.Drawing.Color.White;
            this.NIK.Location = new System.Drawing.Point(758, 160);
            this.NIK.Name = "NIK";
            this.NIK.Size = new System.Drawing.Size(0, 13);
            this.NIK.TabIndex = 17;
            // 
            // Nama
            // 
            this.Nama.AutoSize = true;
            this.Nama.BackColor = System.Drawing.Color.White;
            this.Nama.Location = new System.Drawing.Point(758, 184);
            this.Nama.Name = "Nama";
            this.Nama.Size = new System.Drawing.Size(0, 13);
            this.Nama.TabIndex = 18;
            // 
            // TempatLahir
            // 
            this.TempatLahir.AutoSize = true;
            this.TempatLahir.BackColor = System.Drawing.Color.White;
            this.TempatLahir.Location = new System.Drawing.Point(758, 209);
            this.TempatLahir.Name = "TempatLahir";
            this.TempatLahir.Size = new System.Drawing.Size(0, 13);
            this.TempatLahir.TabIndex = 19;
            // 
            // TanggalLahir
            // 
            this.TanggalLahir.AutoSize = true;
            this.TanggalLahir.BackColor = System.Drawing.Color.White;
            this.TanggalLahir.Location = new System.Drawing.Point(758, 234);
            this.TanggalLahir.Name = "TanggalLahir";
            this.TanggalLahir.Size = new System.Drawing.Size(0, 13);
            this.TanggalLahir.TabIndex = 20;
            // 
            // GolonganDarah
            // 
            this.GolonganDarah.AutoSize = true;
            this.GolonganDarah.BackColor = System.Drawing.Color.White;
            this.GolonganDarah.Location = new System.Drawing.Point(758, 285);
            this.GolonganDarah.Name = "GolonganDarah";
            this.GolonganDarah.Size = new System.Drawing.Size(0, 13);
            this.GolonganDarah.TabIndex = 21;
            // 
            // Alamat
            // 
            this.Alamat.AutoSize = true;
            this.Alamat.BackColor = System.Drawing.Color.White;
            this.Alamat.Location = new System.Drawing.Point(758, 309);
            this.Alamat.Name = "Alamat";
            this.Alamat.Size = new System.Drawing.Size(0, 13);
            this.Alamat.TabIndex = 22;
            // 
            // Agama
            // 
            this.Agama.AutoSize = true;
            this.Agama.BackColor = System.Drawing.Color.White;
            this.Agama.Location = new System.Drawing.Point(758, 334);
            this.Agama.Name = "Agama";
            this.Agama.Size = new System.Drawing.Size(0, 13);
            this.Agama.TabIndex = 23;
            this.Agama.Click += new System.EventHandler(this.label12_Click);
            // 
            // StatusPerkawinan
            // 
            this.StatusPerkawinan.AutoSize = true;
            this.StatusPerkawinan.BackColor = System.Drawing.Color.White;
            this.StatusPerkawinan.Location = new System.Drawing.Point(758, 359);
            this.StatusPerkawinan.Name = "StatusPerkawinan";
            this.StatusPerkawinan.Size = new System.Drawing.Size(0, 13);
            this.StatusPerkawinan.TabIndex = 24;
            // 
            // Pekerjaan
            // 
            this.Pekerjaan.AutoSize = true;
            this.Pekerjaan.BackColor = System.Drawing.Color.White;
            this.Pekerjaan.Location = new System.Drawing.Point(758, 385);
            this.Pekerjaan.Name = "Pekerjaan";
            this.Pekerjaan.Size = new System.Drawing.Size(0, 13);
            this.Pekerjaan.TabIndex = 25;
            // 
            // Kewarganegaraan
            // 
            this.Kewarganegaraan.AutoSize = true;
            this.Kewarganegaraan.BackColor = System.Drawing.Color.White;
            this.Kewarganegaraan.Location = new System.Drawing.Point(758, 411);
            this.Kewarganegaraan.Name = "Kewarganegaraan";
            this.Kewarganegaraan.Size = new System.Drawing.Size(0, 13);
            this.Kewarganegaraan.TabIndex = 26;
            // 
            // JenisKelamin
            // 
            this.JenisKelamin.AutoSize = true;
            this.JenisKelamin.BackColor = System.Drawing.Color.White;
            this.JenisKelamin.Location = new System.Drawing.Point(758, 259);
            this.JenisKelamin.Name = "JenisKelamin";
            this.JenisKelamin.Size = new System.Drawing.Size(0, 13);
            this.JenisKelamin.TabIndex = 27;
            // 
            // Form1
            // 
            this.AccessibleDescription = "C-Major";
            this.AccessibleName = "C-Major";
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1076, 706);
            this.Controls.Add(this.JenisKelamin);
            this.Controls.Add(this.Kewarganegaraan);
            this.Controls.Add(this.Pekerjaan);
            this.Controls.Add(this.StatusPerkawinan);
            this.Controls.Add(this.Agama);
            this.Controls.Add(this.Alamat);
            this.Controls.Add(this.GolonganDarah);
            this.Controls.Add(this.TanggalLahir);
            this.Controls.Add(this.TempatLahir);
            this.Controls.Add(this.Nama);
            this.Controls.Add(this.NIK);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toggleButton1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.imageUploader);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageUploader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                String imageLocation = ""; 
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "BMP files (*.bmp)|*.bmp|JPG files (*.jpg)|*.jpg|PNG files (*.png)|*.png|All Files (*.*)|*.*";

                if(dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // MessageBox.Show(imageLocation, "Image Location", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Change picture box to image
                    imageLocation = dialog.FileName;
                    imageUploader.ImageLocation = imageLocation;

                    // Set chosen image binary
                    Bitmap img = new Bitmap(imageLocation);
                    Bitmap img_cropped = LogicManip.CropImageContiguous(img);

                    string stringBinary = LogicManip.ImageToBinary(img);
                    string stringASCII = LogicManip.BinaryToAscii(stringBinary);

                    // Write similarity
                    if (LogicData.isImageChosen) {
                        Console.WriteLine("ASCII similarity: " + HammingDistance.GetSimilarity(LogicData.chosenImageASCII, stringASCII) + "%");
                        Console.WriteLine("Binary similarity: " + HammingDistance.GetSimilarity(LogicData.chosenImageBinary, stringBinary) + "%\n");
                    }
                    
                    LogicData.chosenImageASCII = stringASCII;
                    LogicData.chosenImageBinary = stringBinary;
                    LogicData.isImageChosen = true;                }
            }
            catch (Exception) {
                MessageBox.Show("An Error Occured","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toggleButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.toggleButton1.isBM = !this.toggleButton1.isBM;
            this.toggleButton1.isKMP = !this.toggleButton1.isKMP;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Console.WriteLine("Halo, dunia!");
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            // Reset biodata board
            this.pictureBox1.Image = null;

            this.NIK.Text = "";
            this.Nama.Text = "";
            this.TempatLahir.Text = "";
            this.TanggalLahir.Text = "";
            this.JenisKelamin.Text = "";
            this.GolonganDarah.Text = "";
            this.Alamat.Text = "";
            this.Agama.Text = "";
            this.StatusPerkawinan.Text = "";
            this.Pekerjaan.Text = "";
            this.Kewarganegaraan.Text = "";

            this.label10.Text = "Persentase Kecocokkan           :   ";

            await Task.Run(() => {
                // Start search
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                
                // Get fingerprint list
                List<Database.SidikJari> sidikJariList = LogicData.sidikJariList;

                // Iterate through fingerprint list
                foreach (Database.SidikJari sidikJari in sidikJariList) {
                    // Get fingerprint image
                    Bitmap bitmap = LogicManip.loadImage(sidikJari.BerkasCitra);

                    // Convert to ASCII
                    string stringBinary = LogicManip.ImageToBinary(bitmap);
                    string stringASCII = LogicManip.BinaryToAscii(stringBinary);

                    // Check if exact match using KMP
                    int match = LogicKMP.KMPMatch(LogicData.chosenImageASCII, stringASCII);

                    // Print data
                    // Console.WriteLine("Nama: " + sidikJari.Nama);
                    Console.WriteLine("Path gambar: " + sidikJari.BerkasCitra);

                    // Print hamming distance
                    float similarityASCII = HammingDistance.GetSimilarity(LogicData.chosenImageASCII, stringASCII);
                    float similarityBinary = HammingDistance.GetSimilarity(LogicData.chosenImageBinary, stringBinary);

                    Console.WriteLine("ASCII similarity: " + similarityASCII + "%\n");
                    // Console.WriteLine("Binary similarity: " + similarityBinary + "%\n");

    
                    if (match != -1 || similarityASCII > 80) {
                        // Set pictureBox2 to matched fingerprint
                        
                        Invoke((Action)(() => {
                            pictureBox1.Image = bitmap;
                        }));

                        List<Database.Biodata> biodataList = LogicData.biodataList;
                        string alayRegex = RegexAlay.NameToRegex(sidikJari.Nama.ToLower());
                        Console.WriteLine(alayRegex);

                        foreach (var biodata in biodataList)
                        {
                            if (Regex.IsMatch(biodata.Nama, alayRegex, RegexOptions.IgnoreCase))
                            {
                                Console.WriteLine("Match found in biodata:");
                                Console.WriteLine("Nama: " + biodata.Nama);
                                Console.WriteLine("NIK: " + biodata.NIK);

                                Invoke((Action)(() => {
                                    NIK.Text = "NIK : " + biodata.NIK;
                                    Nama.Text = "Nama : " + sidikJari.Nama;
                                    TempatLahir.Text = "Tempat Lahir : " + biodata.Tempat_Lahir;
                                    TanggalLahir.Text = "Tanggal Lahir : " + biodata.Tanggal_Lahir;
                                    JenisKelamin.Text = "Jenis Kelamin : " + biodata.Jenis_Kelamin;
                                    GolonganDarah.Text = "Golongan Darah : " + biodata.Golongan_Darah;
                                    Alamat.Text = "Alamat : " + biodata.Alamat;
                                    Agama.Text = "Agama : " + biodata.Agama;
                                    StatusPerkawinan.Text = "Status Perkawinan : " + biodata.Status_Perkawinan;
                                    Pekerjaan.Text = "Pekerjaan : " + biodata.Pekerjaan;
                                    Kewarganegaraan.Text = "Kewarganegaraan : " + biodata.Kewarganegaraan;

                                    this.label10.Text = "Persentase Kecocokkan           :   " + similarityASCII + " %";
                                }));
                                
                                break;
                            }
                        }
                        break;
                    }
                }
                
                // Set time taken
                stopwatch.Stop();

                Invoke((Action)(() => {
                    this.label9.Text = "Waktu Pencarian                        :  " + stopwatch.ElapsedMilliseconds + " ms";
                }));
            });

            // if(this.toggleButton1.isKMP){
            // }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            //List<Database.SidikJari> sidikJariList = new Database.SidikJariLoader().GetSidikJariList();

            //foreach (Database.SidikJari sidikJari in sidikJariList) {
            //  Console.WriteLine(sidikJari.Nama + " " + sidikJari.BerkasCitra);
            //}

            //string input = "Bintang Dwi Marthen";
            //string lowerCaseInput = input.ToLower();
            //string corrupted = "B1nt4n6 Dw1 M4rthen";
            //string regex = RegexAlay.NameToRegex(lowerCaseInput);
            //if (Regex.IsMatch(corrupted, regex, RegexOptions.IgnoreCase))
            //{
                //Console.WriteLine("Match found in biodata:");
            //}
            //else
            //{
              //  Console.WriteLine(" kaga Match found in biodata:");
            //}
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
