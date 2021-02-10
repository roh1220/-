using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace 미니프로젝트_2._0__칼라영상처리_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.MouseWheel += new MouseEventHandler(Mouse_Wheel);
            toolStripStatusLabel1.Text = "  ";
        }

        /// //////////////////////////////////////////////
        // 전역변수부
        /// //////////////////////////////////////////////
        byte[,,] inImage = null, outImage = null;
        int inH, inW, outH, outW;
        string fileName;
        Bitmap paper, bitmap;

        const double PI = 3.1415926535897932;
        const int RGB = 3, RR = 0, GG = 1, BB = 2;
        bool mouseYN = false;
        int sx, sy, ex, ey;

        string[] tmpFiles = new string[500]; // 최대 500개
        int tmpIndex = 0;


        /// //////////////////////////////////////////////
        // 메뉴 이벤트 처리부
        /// //////////////////////////////////////////////
        private void Mouse_Wheel(object sender, MouseEventArgs e)
        {
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.O: openImage();   break;
                    case Keys.S: saveImage();   break;
                    case Keys.Z: restoreTempFile();   break;    // 실행 취소
                    //case Keys.Y: redoImage();   break;    // 다시 실행
                    case Keys.W: this.Close();  break;
                }
            }
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (!mouseYN)
                return;
            sx = e.X; sy = e.Y;
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (!mouseYN)
                return;
            ex = e.X; ey = e.Y;
            if (sx > ex)
            {
                int tmp = sx; sx = ex; ex = tmp;
            }
            if (sy > ey)
            {
                int tmp = sy; sy = ey; ey = tmp;
            }

            revImage();
            mouseYN = false;
        }
        // 파일
        private void 열기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openImage();
        }
        private void 저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveImage();
        }

        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // (1) 화소점 처리
        private void 동일이미지ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            in_image();
            saveTempFile();
        }
        private void 밝게어둡게ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            add_image();
            saveTempFile();
        }
        private void 그레이스케일ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gray_scale();
            saveTempFile();
        }
        private void 흑백이미지RGB계수ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grayscale_rgb();
            display();
            saveTempFile();
        }
        private void 흑백이미지ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bwImage();
            saveTempFile();
        }      
        private void 흑백이미지평균ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bwImage_avg();
            saveTempFile();
        }
        private void 반전이미지ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            revImage();
            saveTempFile();
        }
        private void 반전마우스ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mouseYN = true;
            saveTempFile();
        }
        private void 감마변환ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gammaImage();
            saveTempFile();
        }
        private void 파라볼라ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            parabolaImage();
            saveTempFile();
        }
        private void 솔라라이징ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            solarizingImage();
            saveTempFile();
        }
        private void 이미지합성ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hapImage();
            saveTempFile();
        }
        // (2) 기하학 처리
        private void 좌우미러링ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rl_mirrImage();
            saveTempFile();
        }
        private void 상하미러링ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tb_mirrImage();
            saveTempFile();
        }
        private void 확대ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sizeupImage();
            saveTempFile();
        }
        private void 축소ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sizedownImage();
            saveTempFile();
        }
        private void 회전ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rotateImage();
            saveTempFile();
        }
        private void 이동ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            moveImage();
            saveTempFile();
        }
        // (3) 화소영역 처리
        private void 엠보싱ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            embossImage();
            saveTempFile();
        }
        private void 블러링3X3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            burrImage3();
            saveTempFile();
        }
        private void 블러링5X5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            burrImage5();
            saveTempFile();
        }
        private void 블러링입력ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            burrImage();
            saveTempFile();
        }
        private void 경계선ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            edgeImage();
            saveTempFile();
        }
        private void 노이즈제거중간값정리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            noiseeraseImage();
            saveTempFile();
        }
        private void 노이즈생성ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            noisecreateImage();
            saveTempFile();
        }
        // (4) 히스토그램
        private void 히스토그램스트레칭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            histo_stretch();
            saveTempFile();
        }
        private void 엔드인탐색ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            end_in_search();
            saveTempFile();
        }
        private void 평활화ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            histo_equal();
            saveTempFile();
        }


        /// //////////////////////////////////////////////
        // 공통 함수부
        /// //////////////////////////////////////////////
        (int w, int h, byte[,,] image) open(int W, int H, byte[,,] Image)
        {
            OpenFileDialog ofd = new OpenFileDialog();  // 객체 생성
            ofd.DefaultExt = "";
            ofd.Filter = "칼라 필터 | *.png; *.jpg; *.bmp; *.tif";
            if (ofd.ShowDialog() != DialogResult.OK)
                return (0, 0, null);
            fileName = ofd.FileName;
            // 파일 --> 비트맵(bitmap)
            bitmap = new Bitmap(fileName);
            // 중요! 입력이미지의 높이, 폭 알아내기
            W = bitmap.Height;
            H = bitmap.Width;
            Image = new byte[RGB, H, W]; // 메모리 할당
            // 비트맨(bitmapp) --> 메모리 (로딩)
            for (int i = 0; i < H; i++)
                for (int k = 0; k < W; k++)
                {
                    Color c = bitmap.GetPixel(i, k);
                    Image[RR, i, k] = c.R;
                    Image[GG, i, k] = c.G;
                    Image[BB, i, k] = c.B;
                }
            return (W, H, Image);
        }
        void openImage()
        {
            var r = open(inW, inH, inImage);
            inW = r.w;  inH = r.h;  inImage = r.image;
            equal_image();
        }
        void saveImage() { 
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = "";
            sfd.Filter = "PNG File(*.png) | *.png";
            if (sfd.ShowDialog() != DialogResult.OK)
                return;
            string saveFname = sfd.FileName;
            Bitmap image = new Bitmap(outH, outW); // 빈 비트맵(종이) 준비
            for (int i = 0; i < outH; i++)
                for (int k = 0; k < outW; k++)
                {
                    Color c;
                    int r, g, b;
                    r = outImage[0, i, k];
                    g = outImage[1, i, k];
                    b = outImage[2, i, k];
                    c = Color.FromArgb(r, g, b);
                    image.SetPixel(i, k, c);  // 종이에 콕콕 찍기
                }
            image.Save(saveFname, ImageFormat.Png); // 종이를 PNG로 저장
            toolStripStatusLabel1.Text = saveFname;
            MessageBox.Show(saveFname + "파일이 저장되었습니다.", "저장", MessageBoxButtons.OK);
        }
        void display()
        {
            // 벽, 게시판, 종이 크기 조절
            paper = new Bitmap(outH, outW); // 종이
            pictureBox1.Size = new Size(outH, outW); // 캔버스
            this.Size = new Size(outH + 20, outW + 80); // 벽

            Color pen; // 펜(콕콕 찍을 용도)
            for (int i = 0; i < outH; i++)
                for (int k = 0; k < outW; k++)
                {
                    byte r = outImage[RR, i, k]; // 잉크(색상값)
                    byte g = outImage[GG, i, k];
                    byte b = outImage[BB, i, k];
                    pen = Color.FromArgb(r, g, b); // 펜에 잉크 묻히기
                    paper.SetPixel(i, k, pen); // 종이에 콕 찍기
                }
            pictureBox1.Image = paper; // 게시판에 종이를 붙이기.
            toolStripStatusLabel1.Text =
                outH.ToString() + "x" + outW.ToString() + "  " + fileName;
        }
        void saveTempFile() // 영상처리 효과가 계속 누적
        {
            /// (1) 입력영상을 디스크에 저장 
            string saveFname = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".tmp";
            Bitmap image = new Bitmap(inH, inW); // 빈 비트맵(종이) 준비
            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                {
                    Color c;
                    int r, g, b;
                    r = inImage[0, i, k];
                    g = inImage[1, i, k];
                    b = inImage[2, i, k];
                    c = Color.FromArgb(r, g, b);
                    image.SetPixel(i, k, c); // 종이에 콕콕 찍기
                }
            image.Save(saveFname, System.Drawing.Imaging.ImageFormat.Png);
            tmpFiles[tmpIndex++] = saveFname;

            /// (2) 출력영상 --> 입력영상
            inH = outH; inW = outW;
            inImage = new byte[RGB, inH, inW];
            for (int rgb = 0; rgb < RGB; rgb++)
                for (int i = 0; i < outH; i++)
                    for (int k = 0; k < outW; k++)
                        inImage[rgb, i, k] = outImage[rgb, i, k];
        }
        void restoreTempFile()
        {
            if (tmpIndex <= 0)
                return;
            fileName = tmpFiles[--tmpIndex];

            // 파일 --> 비트맵(bitmap)
            bitmap = new Bitmap(fileName);

            // 중요! 입력이미지의 높이, 폭 알아내기
            inW = bitmap.Height;
            inH = bitmap.Width;
            inImage = new byte[RGB, inH, inW]; // 메모리 할당

            // 비트맵(bitmap) --> 메모리 (로딩)
            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                {
                    Color c = bitmap.GetPixel(i, k);
                    inImage[RR, i, k] = c.R;
                    inImage[GG, i, k] = c.G;
                    inImage[BB, i, k] = c.B;
                }
            equal_image();

            // System.IO.File.Delete(fileName); // 임시파일 삭제 
        }
        double getValue1(string txt)   // subForm1에서 입력받기 (값 1개)
        {
            subForm1 sub = new subForm1(txt);  // 객체 생성
            if (sub.ShowDialog() == DialogResult.Cancel)
                return 1;   // 0으로 할 경우 확대, 축소 오류발생

            double value = (double)sub.numUp_value.Value;
            return value;
        }
        (double n1, double n2) getValue2(string txt1, string txt2)
        {
            subForm2 sub = new subForm2(txt1, txt2);
            if (sub.ShowDialog() == DialogResult.Cancel)
                return (0, 0);
            double num1 = (double)sub.num_UD1.Value;
            double num2 = (double)sub.num_UD2.Value;
            return (num1, num2);
        }


        /// //////////////////////////////////////////////
        // 영상처리 함수부
        /// //////////////////////////////////////////////
        // (1) 화소점 처리
        void in_image()
        {
            if (tmpIndex <= 0)
                return;
            fileName = tmpFiles[0];

            // 파일 --> 비트맵(bitmap)
            bitmap = new Bitmap(fileName);

            // 중요! 입력이미지의 높이, 폭 알아내기
            inW = bitmap.Height;
            inH = bitmap.Width;
            inImage = new byte[RGB, inH, inW]; // 메모리 할당

            // 비트맵(bitmap) --> 메모리 (로딩)
            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                {
                    Color c = bitmap.GetPixel(i, k);
                    inImage[RR, i, k] = c.R;
                    inImage[GG, i, k] = c.G;
                    inImage[BB, i, k] = c.B;
                }
            equal_image();
            display();
        }
        void equal_image()
        {
            if (inImage == null)
                return;
            // 중요! 출력이미지의 높이, 폭을 결정  --> 알고리즘에 영향
            outH = inH; outW = inW;
            outImage = new byte[RGB, outH, outW];
            // *** 진짜 영상처리 알고리즘을 구현 ***
            for (int rgb = 0; rgb < RGB; rgb++)
                for (int i = 0; i < inH; i++)
                    for (int k = 0; k < inW; k++)
                    {
                        outImage[rgb, i, k] = inImage[rgb, i, k];
                    }

            display();
        }
        void add_image()
        {
            if (inImage == null)
                return;
            // 중요! 출력이미지의 높이, 폭을 결정  --> 알고리즘에 영향
            outH = inH; outW = inW;
            outImage = new byte[RGB, outH, outW];
            string txtlabel = "밝기조절 : ";
            int bright = (int)getValue1(txtlabel);


            // *** 진짜 영상처리 알고리즘을 구현 ***
            for (int rgb = 0; rgb < RGB; rgb++)
                for (int i = 0; i < inH; i++)
                    for (int k = 0; k < inW; k++)
                    {
                        if (inImage[rgb, i, k] + bright > 255)
                            outImage[rgb, i, k] = 255;
                        else if (inImage[rgb, i, k] + bright < 0)
                            outImage[rgb, i, k] = 0;
                        else
                            outImage[rgb, i, k] = (byte)(inImage[rgb, i, k] + bright);
                    }
            display();
        }
        void gray_scale()
        {
            if (inImage == null)
                return;
            // 중요! 출력이미지의 높이, 폭을 결정  --> 알고리즘에 영향
            outH = inH; outW = inW;
            outImage = new byte[RGB, outH, outW];
            // *** 진짜 영상처리 알고리즘을 구현 ***
            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                {
                    int hap = inImage[RR, i, k] + inImage[GG, i, k] + inImage[BB, i, k];
                    byte rgb = (byte)(hap / 3.0);
                    outImage[RR, i, k] = rgb;
                    outImage[GG, i, k] = rgb;
                    outImage[BB, i, k] = rgb;
                }
            display();
        }
        void grayscale_rgb()
        {
            if (inImage == null)
                return;
            // 중요! 출력이미지의 높이, 폭을 결정  --> 알고리즘에 영향
            outH = inH; outW = inW;
            outImage = new byte[RGB, outH, outW];
            // *** 진짜 영상처리 알고리즘을 구현 ***
            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                {
                    byte rgb = (byte)(inImage[RR, i, k]*0.299 + inImage[GG, i, k]*0.587 + inImage[BB, i, k]*0.114);
                    outImage[RR, i, k] = rgb;
                    outImage[GG, i, k] = rgb;
                    outImage[BB, i, k] = rgb;
                }
        }
        void bwImage()  // 흑백 이미지
        {
            grayscale_rgb();
            for (int i = 0; i < outH; i++)
            {
                for (int k = 0; k < outW; k++)
                {
                    if (inImage[RR, i, k] > 128)
                    {
                        outImage[RR, i, k] = 255;
                        outImage[GG, i, k] = 255;
                        outImage[BB, i, k] = 255;
                    }
                    else
                    {
                        outImage[RR, i, k] = 0;
                        outImage[GG, i, k] = 0;
                        outImage[BB, i, k] = 0;
                    }
                }
            }
            display();
        }
        void bwImage_avg()  // 흑백이미지 (평균값 기준으로)
        {
            grayscale_rgb();
            int sum = 0;
            for (int i = 0; i < outH; i++)
                for (int k = 0; k < outW; k++)
                    sum += inImage[RR, i, k];

            int avg = sum / (outH * outW);
            for (int i = 0; i < outH; i++)
                for (int k = 0; k < outW; k++)
                    for(int rgb = 0; rgb< RGB; rgb++) { 
                        if (inImage[RR, i, k] > avg)
                            outImage[rgb, i, k] = 255;
                        else
                            outImage[rgb, i, k] = 0;
                    }
            display();
        }
        void revImage()
        {
            // 열린 이미지가 없을 경우, 작업하지 않음
            if (inImage == null)
                return;
            // 영상 반전
            outH = inH; outW = inW;
            outImage = new byte[RGB, outH, outW];
            if (!mouseYN)
            {
                sx = 0; sy = 0;
                ex = inH; ey = inW;
            }
            // *** 진짜 영상처리 알고리즘을 구현 ***
            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                {
                    for (int rgb = 0; rgb < RGB; rgb++)
                    {
                        if ((sx <= k && k <= ex) && (sy <= i && i <= ey))
                            outImage[rgb, k, i] = (byte)(255 - inImage[rgb, k, i]);
                        else
                            outImage[rgb, k, i] = inImage[rgb, k, i];
                    }
                }
            display();
        }
        void gammaImage()   // 감마 변환                            
        {
            // 열린 이미지가 없을 경우, 작업하지 않음
            if (inImage == null)
                return;
            // (0 < gamma < 1 : 영상 어둡고 흐리게)
            // gamma > 1     : 영상 밝게
            string txtlabel = "감마 : ";
            double gamma = getValue1(txtlabel);
            outH = inH; outW = inW;
            outImage = new byte[RGB, outH, outW];
            for (int i = 0; i < outH; i++)
                for (int k = 0; k < outW; k++)
                    for (int rgb = 0; rgb < RGB; rgb++)
                        outImage[rgb, i, k] = (byte)(Math.Pow(inImage[rgb, i, k] / 255.0, 1 / gamma) * 255.0 + 0.5);
            display();
        }
        void parabolaImage()    // 파라볼라 변환
        {
            // 열린 이미지가 없을 경우, 작업하지 않음
            if (inImage == null)
                return;

            outH = inH; outW = inW;
            outImage = new byte[RGB, outH, outW];
            for (int i = 0; i < outH; i++)
                for (int k = 0; k < outW; k++)
                    for (int rgb = 0; rgb < RGB; rgb++)
                        outImage[rgb, i, k] = (byte)(255 * Math.Pow((double)inImage[rgb, i, k] / 128 - 1, 2));
            display();
        }
        void solarizingImage()  // 솔라라이징 변환
        {
            // 열린 이미지가 없을 경우, 작업하지 않음
            if (inImage == null)
                return;

            outH = inH; outW = inW;
            outImage = new byte[RGB, outH, outW];
            for (int i = 0; i < outH; i++)
                for (int k = 0; k < outW; k++)
                    for (int rgb = 0; rgb < RGB; rgb++)
                        outImage[rgb, i, k] = (byte)(255 - 255 * Math.Pow((double)inImage[rgb, i, k] / 128 - 1, 2));
            display();
        }
        void hapImage() // 이미지 합성
        {
            // 열린 이미지가 없을 경우, 작업하지 않음
            if (inImage == null)
                return;
            outH = inH; outW = inW;
            outImage = new byte[RGB, outH, outW];

            // 합성할 이미지 열기
            int hapW = 0, hapH = 0;
            byte[,,] hapImage = null;
            var r = open(hapW, hapH, hapImage);
            hapW = r.w; hapH = r.h; hapImage = r.image;

            // inImage와 크기 동일한지 확인
            if (inH != hapH && inW != hapW)
            {
                MessageBox.Show("이미지 크기가 맞지 않습니다.", "입력오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //// 몇퍼센트 합성할지
            string txtlabel = "합성비율 : ";
            double hap_percent = getValue1(txtlabel) / 100.0; // 0(연하게)-100(진하게)
            for (int i = 0; i < outH; i++)
                for (int k = 0; k < outW; k++)
                    for (int rgb = 0; rgb < RGB; rgb++)
                        outImage[rgb, i, k] = (byte)(inImage[rgb, i, k] * (1 - hap_percent) + hapImage[rgb, i, k] * hap_percent);
            display();
        }

        
        // (2) 기하학 처리
        void rl_mirrImage() // 좌우미러링
        {
            // 열린 이미지가 없을 경우, 작업하지 않음
            if (inImage == null)
                return;
            // 좌우미러링
            outH = inH; outW = inW;
            outImage = new byte[RGB, outH, outW];
            for (int i = 0; i <= outH / 2; i++)
                for (int k = 0; k < outW; k++)
                    for (int rgb = 0; rgb < RGB; rgb++)
                    {
                        outImage[rgb, i, k] = inImage[rgb, outH - i - 1, k];
                        outImage[rgb, outH - i - 1, k] = inImage[rgb, i, k];
                    }
            display();
        }
        void tb_mirrImage() // 상하미러링
        {
            // 열린 이미지가 없을 경우, 작업하지 않음
            if (inImage == null)
                return;
            // 상하미러링
            outH = inH; outW = inW;
            outImage = new byte[RGB, outH, outW];
            for (int i = 0; i < outH; i++)
                for (int k = 0; k <= outW / 2; k++)
                    for(int rgb=0; rgb<RGB; rgb++) 
                    {
                        outImage[rgb, i, k] = inImage[rgb, i, outW - k - 1];
                        outImage[rgb, i, outW - k - 1] = inImage[rgb, i, k];
                    }
            display();
        }
        void sizeupImage()  // 확대 (정수배)
        {
            // 열린 이미지가 없을 경우, 작업하지 않음
            if (inImage == null)
                return;
            // 확대 배율 입력
            string txtlabel = "확대비율 : ";
            int scale = (int)getValue1(txtlabel);
            // n배 확대
            outH = scale * inH; outW = scale * inW;
            outImage = new byte[RGB, outH, outW];
            for (int i = 0; i < outH; i++)
                for (int k = 0; k < outW; k++)
                    for (int rgb = 0; rgb < RGB; rgb++)
                        outImage[rgb, i, k] = inImage[rgb, i / scale, k / scale];
            display();
        }
        void sizedownImage()    // 축소 (정수배)
        {
            // 열린 이미지가 없을 경우, 작업하지 않음
            if (inImage == null)
                return;
            // 축소 배율 입력
            string txtlabel = "축소비율 : ";
            int scale = (int)getValue1(txtlabel);
            // n배 축소
            outH = inH / scale; outW = inW / scale;
            outImage = new byte[RGB, outH, outW];
            for (int i = 0; i < outH; i++)
                for (int k = 0; k < outW; k++)
                    for (int rgb = 0; rgb < RGB; rgb++)
                        outImage[rgb, i, k] = inImage[rgb, i * scale, k * scale];
            display();
        }
        void rotateImage()  // 회전
        {
            // 열린 이미지가 없을 경우, 작업하지 않음
            if (inImage == null)
                return;

            // 회전하고 싶은 각도 입력
            double theta;
            int rotate_h, rotate_w;
            string txtlabel = "각도 : ";
            theta = getValue1(txtlabel);
            double rad = (double)theta * PI / 180;

            // 회전했을 때 크기 구하기
            int rotH = (int)(Math.Abs(inW * Math.Sin(rad)) + Math.Abs(inH * Math.Cos(rad)));
            int rotW = (int)(Math.Abs(inH * Math.Sin(rad)) + Math.Abs(inW * Math.Cos(rad)));
            if (rotH < inH)     rotH = inH;
            if (rotW < inW)     rotW = inW;

            // 이미지 중심 구하기 (영상 중심으로 회전시키기 위해)
            int centerH = rotH / 2, centerW = rotW / 2;

            // 회전했을 때의 크기로 rotateimage 메모리 할당받아 중앙에 inputImage를 넣음
            byte[,,] rotateimage = new byte[RGB, rotH, rotW];
            for (int rgb = 0; rgb < RGB; rgb++)
                for (int i = centerH - (inH / 2), n = 0; i < centerH + (inH / 2); i++, n++)
                    for (int k = centerW - (inW / 2), m = 0; k < centerW + (inW / 2); k++, m++)
                        rotateimage[rgb, i, k] = inImage[rgb, n, m];

            // outImage메모리 할당
            outH = rotH; outW = rotW;
            outImage = new byte[RGB, outH, outW];

            // 이미지 회전
            for (int rgb = 0; rgb < RGB; rgb++)
                for (int i = 0; i < outH; i++)
                {
                    for (int k = 0; k < outW; k++)
                    {
                        rotate_h = (int)((i - centerH) * Math.Cos(rad) - (k - centerW) * Math.Sin(rad) + centerH);
                        rotate_w = (int)((i - centerH) * Math.Sin(rad) + (k - centerW) * Math.Cos(rad) + centerW);
                        {
                            if ((rotate_w >= 0 && rotate_w < outW) && (rotate_h >= 0 && rotate_h < outH))
                                outImage[rgb, i, k] = rotateimage[rgb, rotate_h, rotate_w];
                            else
                                outImage[rgb, i, k] = 0;
                        }
                    }
                }
            display();
        }
        void moveImage()
        {
            // 열린 이미지가 없을 경우, 작업하지 않음
            if (inImage == null)
                return;

            // 입력 받기 --> 수정
            string txtlabel1 = "가로이동 : ";
            string txtlabel2 = "세로이동 : ";
            var v = getValue2(txtlabel1, txtlabel2);
            int move_w = (int)v.n1; // 가로
            int move_h = (int)v.n2; // 세로

            // 출력이미지 폭,높이
            outH = inH; outW = inW;
            outImage = new byte[RGB, outH, outW];

            // 이미지 이동
            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                    for (int rgb = 0; rgb < RGB; rgb++)
                        if ((i + move_w >= 0 && i + move_w < outH) && (k + move_h >= 0 && k + move_h < outW))
                            outImage[rgb, i + move_w, k + move_h] = inImage[rgb, i, k];
            display();
        }


        // (3) 화소영역 처리
        void embossImage()
        {
            int MSIZE = 3;
            double[,] mask = { { -1.0, 0.0, 0.0 }, { 0.0, 0.0, 0.0 }, { 0.0, 0.0, 1.0 } };
            pixelArea(MSIZE, mask);
        }
        void burrImage3()
        {
            int MSIZE = 3;
            double[,] mask = { { 1 / 9.0, 1 / 9.0, 1 / 9.0 }, { 1 / 9.0, 1 / 9.0, 1 / 9.0 }, { 1 / 9.0, 1 / 9.0, 1 / 9.0 } };
            pixelArea(MSIZE, mask);
        }
        void burrImage5()
        {
            int MSIZE = 5;
            double[,] mask = { { 1 / 25.0, 1 / 25.0, 1 / 25.0, 1 / 25.0, 1 / 25.0 },
                { 1 / 25.0, 1 / 25.0, 1 / 25.0, 1 / 25.0, 1 / 25.0 }, { 1 / 25.0, 1 / 25.0, 1 / 25.0, 1 / 25.0, 1 / 25.0 },
                { 1 / 25.0, 1 / 25.0, 1 / 25.0, 1 / 25.0, 1 / 25.0 }, { 1 / 25.0, 1 / 25.0, 1 / 25.0, 1 / 25.0, 1 / 25.0 }};
            pixelArea(MSIZE, mask);
        }
        void burrImage()
        {
            string txtlabel = "마스크크기 : ";
            int MSIZE = (int)getValue1(txtlabel);
            if (MSIZE % 2 == 0)
            {
                MessageBox.Show("홀수를 입력하세요.", "입력오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            double[,] mask = new double[MSIZE, MSIZE];
            for (int i = 0; i < MSIZE; i++)
                for (int k = 0; k < MSIZE; k++)
                    mask[i, k] = (double)1 / (MSIZE * MSIZE);
            pixelArea(MSIZE, mask);
        }
        void edgeImage()
        {
            int MSIZE = 3;
            double[,] mask = { { 0.0, -1.0, 0.0 }, { -1.0, 2.0, 0.0 }, { 0.0, 0.0, 0.0 } };
            pixelArea(MSIZE, mask);
        }
        void noiseeraseImage()
        {
            // 열린 이미지가 없을 경우, 작업하지 않음
            if (inImage == null)
                return;

            outH = inH; outW = inW;
            outImage = new byte[RGB, outH, outW];

            // 중간값 필터 메모리 할당
            const int MSIZE = 3;
            byte[,] erase_mask = new byte[MSIZE, MSIZE];

            // 임시 입력, 출력 메모리 할당
            double[,,] tmpInput = new double[RGB, inH + 2, inW + 2];

            tmpInputFunc(tmpInput, MSIZE);

            // 중간값 필터_노이즈 제거
            for (int rgb=0;rgb<RGB;rgb++)
                for (int i = 0; i < outH; i++)
                    for (int k = 0; k < outW; k++)
                    {
                        for (int m = 0; m < MSIZE; m++)
                            for (int n = 0; n < MSIZE; n++)
                            {
                                erase_mask[m, n] = (byte)tmpInput[rgb, i + m, k + n];
                            }
                        outImage[rgb, i, k] = median_filter(erase_mask, MSIZE);
                    }
            display();
        }
        void noisecreateImage()
        {
            // 열린 이미지가 없을 경우, 작업하지 않음
            if (inImage == null)
                return;

            outH = inH; outW = inW;
            outImage = new byte[RGB, outH, outW];
            Random rand = new Random();

            string txtlabel = "잡음비율 : ";
            double noiseRate = getValue1(txtlabel); // 0-100
            int numOfNoise = (int)((double)(inH * inW * RGB) * noiseRate / 100);

            for (int rgb = 0; rgb < RGB; rgb++)
                for (int i = 0; i < inH; i++)
                    for (int k = 0; k < inW; k++)
                    {
                        outImage[rgb, i, k] = inImage[rgb, i, k];
                    }

            for (int i = 0; i < numOfNoise; i++)
            {
                int randW = rand.Next(0, inW - 1);
                int randH = rand.Next(0, inH - 1);
                int randRGB = rand.Next(0, RGB - 1);

                if (rand.Next(0, 1) == 1)
                    outImage[randRGB, randH, randW] = 255;
                else
                    outImage[randRGB, randH, randW] = 0;
            }
            display();
        }
        void pixelArea(int Size, double[,] Mask)
        {
            // 열린 이미지가 없을 경우, 작업하지 않음
            if (inImage == null)
                return;

            // 출력이미지 폭,높이
            outH = inH; outW = inW;
            outImage = new byte[RGB, outH, outW];

            // 임시 입력, 출력 메모리 할당
            double[,,] tmpInput = new double[RGB, inH + (Size - 1), inW + (Size - 1)];
            double[,,] tmpOutput = new double[RGB, outH, outW];

            // tmpInput에 input 넣기
            tmpInputFunc(tmpInput, Size);

            // 화소 영역 처리
            double S = 0.0;
            for (int rgb = 0; rgb < RGB; rgb++)
                for (int i = 0; i < outH; i++)
                    for (int k = 0; k < outW; k++)
                    {
                        for (int m = 0; m < Size; m++)
                            for (int n = 0; n < Size; n++)
                            {
                                S += tmpInput[rgb, i + m, k + m] * Mask[m, n];
                            }
                        tmpOutput[rgb, i, k] = S;
                        S = 0.0;
                    }

            // 후처리 : Mask의 합이 0이면 평균값 더하기
            // Mask의 합 구하기
            int maskL = (int)Math.Sqrt(Mask.Length);
            double maskS = 0;
            for (int i = 0; i < maskL; i++)
                for (int k = 0; k < maskL; k++)
                    maskS += Mask[i, k];
            // 합이 0이면 후처리
            if (maskS == 0)
            {
                for (int rgb = 0; rgb < RGB; rgb++)
                    for (int i = 0; i < outH; i++)
                        for (int k = 0; k < outW; k++)
                            tmpOutput[rgb, i, k] += 127;
            }

            // 임시 출력 --> 원래 출력
            for (int rgb = 0; rgb < RGB; rgb++)
                for (int i = 0; i < outH; i++)
                    for (int k = 0; k < outW; k++)
                    {
                        double d = tmpOutput[rgb, i, k];
                        if (d > 255.0)
                            d = 255.0;
                        else if (d < 0.0)
                            d = 0.0;
                        outImage[rgb, i, k] = (byte)d;
                    }
            display();
        }
        void tmpInputFunc(double[,,] tmpinput, int size)
        {
            // 평균값으로 초기화
            int[] sum = new int[RGB];
            double[] avg = new double[RGB];
            for (int rgb = 0; rgb < RGB; rgb++)
                for (int i = 0; i < inH; i++)
                    for (int k = 0; k < inW; k++)
                        sum[rgb] += inImage[rgb, i, k];
            for (int rgb = 0; rgb < RGB; rgb++)
                avg[rgb] = sum[rgb] / (inH * inW);
            for (int rgb = 0; rgb < RGB; rgb++)
                for (int i = 0; i < inH + (size - 1); i++)
                    for (int k = 0; k < inW + (size - 1); k++)
                        tmpinput[rgb, i, k] = avg[rgb];

            // 입력 --> 임시(중앙에 위치)
            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                    for (int rgb = 0; rgb < RGB; rgb++)
                        tmpinput[rgb, i + 1, k + 1] = inImage[rgb, i, k];
        }
        byte median_filter(byte[,] mask, int size)
        {
            int n = 0;
            byte[] mask_arr = new byte[size * size];
            for (int i = 0; i < size; i++)
                for (int k = 0; k < size; k++)
                {
                    mask_arr[n] = mask[i, k];
                    n++;
                }
            // 오름차순 정렬
            Array.Sort(mask_arr);
            return mask_arr[(size * size) / 2];
        }
        
        // (4) 히스토그램
        void histo_stretch()    // 히스토그램 스트레칭
        {
            // 열린 이미지가 없을 경우, 작업하지 않음
            if (inImage == null)
                return;

            outH = inH; outW = inW;
            outImage = new byte[RGB, outH, outW];

            histo_stre(0, 0);
        }
        void end_in_search()    // 엔드-인 탐색
        {
            // 열린 이미지가 없을 경우, 작업하지 않음
            if (inImage == null)
                return;

            outH = inH; outW = inW;
            outImage = new byte[RGB, outH, outW];

            // max, min 변경할 값 입력받음
            string txtlabel1 = "MAX : ";
            string txtlabel2 = "MIN : ";
            var v = getValue2(txtlabel1, txtlabel2);
            byte max_val = (byte)v.n1;
            byte min_val = (byte)v.n2;

            histo_stre(max_val, min_val);
        }
        void histo_equal()  // 히스토그램 평활화
        {
            if (inImage == null)
                return;
            // 중요! 출력이미지의 높이, 폭을 결정  --> 알고리즘에 영향
            outH = inH; outW = inW;
            outImage = new byte[RGB, outH, outW];

            // 1단계 : 히스토그램 생성
            ulong[,] histo = new ulong[RGB, 256];   // 히스토그램 배열
            
            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                    for (int rgb = 0; rgb < RGB; rgb++) {
                        histo[rgb,inImage[rgb, i, k]]++;
                    }

            // 2단계 : 누적 히스토그램 생성
            ulong[,] histo_sum = new ulong[RGB, 256];
            ulong[] sum_value = { 0, 0, 0};
            for(int rgb=0;rgb<RGB;rgb++)
                for (int i = 0; i < 256; i++)
                {
                    sum_value[rgb] += histo[rgb, i];
                    histo_sum[rgb, i] = sum_value[rgb];
                }

            // 3단계 : 정규화된 누적히스토그램 생성
            // n = ( 누적합 / (행*열) ) * 255.0
            double[,] histo_normal = new double[RGB, 256];
            for (int rgb = 0; rgb < RGB; rgb++)
                for (int i = 0; i < 256; i++)
                    histo_normal[rgb, i] = ((double)histo_sum[rgb, i] / (inH * inW)) * 255.0;

            // *** 진짜 영상처리 알고리즘을 구현 ***
            for (int rgb = 0; rgb < RGB; rgb++)
                for (int i = 0; i < inH; i++)
                    for (int k = 0; k < inW; k++)
                        outImage[rgb, i, k] = (byte)histo_normal[rgb, inImage[rgb, i, k]];

            display();
            drawgraphic();
        }
        void histo_stre(byte max_v, byte min_v)
        {
            // 최대, 최소 구하기
            byte[] max_value = new byte[RGB];
            byte[] min_value = new byte[RGB];
            for (int rgb = 0; rgb < RGB; rgb++)
            {
                max_value[rgb] = inImage[rgb, 0, 0];
                min_value[rgb] = inImage[rgb, 0, 0];
                for (int i = 0; i < outH; i++)
                    for (int k = 0; k < outW; k++)
                    {
                        if (min_value[rgb] > inImage[rgb, i, k]) min_value[rgb] = inImage[rgb, i, k];
                        if (max_value[rgb] < inImage[rgb, i, k]) max_value[rgb] = inImage[rgb, i, k];
                    }
            }

            // max, min 변경
            for (int i = 0; i < RGB; i++)
            {
                max_value[i] -= max_v;
                min_value[i] += min_v;
            }

            // 히스토그램 스트레칭
            for (int rgb = 0; rgb < RGB; rgb++)
                for (int i = 0; i < inH; i++)
                    for (int k = 0; k < inW; k++)
                    {
                        // Out = (In-min)/(max-min) * 255.0
                        double value = (double)(inImage[rgb, i, k] - min_value[rgb]) / (max_value[rgb] - min_value[rgb]) * 255.0;
                        if (value > 255)
                            value = 255;
                        else if (value < 0)
                            value = 0;
                        outImage[rgb, i, k] = (byte)value;
                    }

            display();
            drawgraphic();
        }
        void drawgraphic()  // 히스토그램 그리기
        {
            // inImage 히스토그램
            long[,] inhisto = new long[RGB, 256];
            for (int rgb = 0; rgb < RGB; rgb++)
                for (int i = 0; i < outH; i++)
                    for (int k = 0; k < outW; k++)
                        inhisto[rgb, inImage[rgb, i, k]]++;
            // outImage 히스토그램
            long[,] outhisto = new long[RGB, 256];
            for (int rgb = 0; rgb < RGB; rgb++)
                for (int i = 0; i < outH; i++)
                    for (int k = 0; k < outW; k++)
                        outhisto[rgb, outImage[rgb, i, k]]++;

            GraphicForm gform = new GraphicForm(inhisto, outhisto);
            gform.ShowDialog();
        }
    }
}
