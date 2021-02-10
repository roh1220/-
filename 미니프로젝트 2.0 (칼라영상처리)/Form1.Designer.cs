
namespace 미니프로젝트_2._0__칼라영상처리_
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.파일ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.열기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.저장ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.종료ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.화소점처리ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.동일이미지ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.밝게어둡게ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.그레이스케일ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.흑백이미지RGB계수ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.흑백이미지ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.흑백이미지평균ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.반전이미지ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.반전마우스ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.감마변환ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.파라볼라ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.솔라라이징ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.이미지합성ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.기하학처리ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.좌우미러링ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.상하미러링ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.확대ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.축소ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.회전ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.이동ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.화소영역처리ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.엠보싱ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.블러링3X3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.블러링5X5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.블러링입력ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.경계선ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.노이즈제거중간값정리ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.노이즈생성ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.히스토그램ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.히스토그램스트레칭ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.엔드인탐색ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.평활화ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(427, 263);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 338);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(524, 26);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(152, 20);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.파일ToolStripMenuItem,
            this.화소점처리ToolStripMenuItem,
            this.기하학처리ToolStripMenuItem,
            this.화소영역처리ToolStripMenuItem,
            this.히스토그램ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(524, 30);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 파일ToolStripMenuItem
            // 
            this.파일ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.열기ToolStripMenuItem,
            this.저장ToolStripMenuItem,
            this.종료ToolStripMenuItem});
            this.파일ToolStripMenuItem.Name = "파일ToolStripMenuItem";
            this.파일ToolStripMenuItem.Size = new System.Drawing.Size(53, 26);
            this.파일ToolStripMenuItem.Text = "파일";
            // 
            // 열기ToolStripMenuItem
            // 
            this.열기ToolStripMenuItem.Name = "열기ToolStripMenuItem";
            this.열기ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.열기ToolStripMenuItem.Text = "열기 (Ctrl+O)";
            this.열기ToolStripMenuItem.Click += new System.EventHandler(this.열기ToolStripMenuItem_Click);
            // 
            // 저장ToolStripMenuItem
            // 
            this.저장ToolStripMenuItem.Name = "저장ToolStripMenuItem";
            this.저장ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.저장ToolStripMenuItem.Text = "저장 (Ctrl+S)";
            this.저장ToolStripMenuItem.Click += new System.EventHandler(this.저장ToolStripMenuItem_Click);
            // 
            // 종료ToolStripMenuItem
            // 
            this.종료ToolStripMenuItem.Name = "종료ToolStripMenuItem";
            this.종료ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.종료ToolStripMenuItem.Text = "종료 (Ctrl+W)";
            this.종료ToolStripMenuItem.Click += new System.EventHandler(this.종료ToolStripMenuItem_Click);
            // 
            // 화소점처리ToolStripMenuItem
            // 
            this.화소점처리ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.동일이미지ToolStripMenuItem,
            this.밝게어둡게ToolStripMenuItem,
            this.그레이스케일ToolStripMenuItem,
            this.흑백이미지RGB계수ToolStripMenuItem,
            this.흑백이미지ToolStripMenuItem,
            this.흑백이미지평균ToolStripMenuItem,
            this.반전이미지ToolStripMenuItem,
            this.반전마우스ToolStripMenuItem,
            this.감마변환ToolStripMenuItem,
            this.파라볼라ToolStripMenuItem,
            this.솔라라이징ToolStripMenuItem,
            this.이미지합성ToolStripMenuItem});
            this.화소점처리ToolStripMenuItem.Name = "화소점처리ToolStripMenuItem";
            this.화소점처리ToolStripMenuItem.Size = new System.Drawing.Size(103, 26);
            this.화소점처리ToolStripMenuItem.Text = "화소점 처리";
            // 
            // 동일이미지ToolStripMenuItem
            // 
            this.동일이미지ToolStripMenuItem.Name = "동일이미지ToolStripMenuItem";
            this.동일이미지ToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
            this.동일이미지ToolStripMenuItem.Text = "원본";
            this.동일이미지ToolStripMenuItem.Click += new System.EventHandler(this.동일이미지ToolStripMenuItem_Click);
            // 
            // 밝게어둡게ToolStripMenuItem
            // 
            this.밝게어둡게ToolStripMenuItem.Name = "밝게어둡게ToolStripMenuItem";
            this.밝게어둡게ToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
            this.밝게어둡게ToolStripMenuItem.Text = "밝기조절";
            this.밝게어둡게ToolStripMenuItem.Click += new System.EventHandler(this.밝게어둡게ToolStripMenuItem_Click);
            // 
            // 그레이스케일ToolStripMenuItem
            // 
            this.그레이스케일ToolStripMenuItem.Name = "그레이스케일ToolStripMenuItem";
            this.그레이스케일ToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
            this.그레이스케일ToolStripMenuItem.Text = "그레이스케일";
            this.그레이스케일ToolStripMenuItem.Click += new System.EventHandler(this.그레이스케일ToolStripMenuItem_Click);
            // 
            // 흑백이미지RGB계수ToolStripMenuItem
            // 
            this.흑백이미지RGB계수ToolStripMenuItem.Name = "흑백이미지RGB계수ToolStripMenuItem";
            this.흑백이미지RGB계수ToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
            this.흑백이미지RGB계수ToolStripMenuItem.Text = "그레이스케일(RGB계수)";
            this.흑백이미지RGB계수ToolStripMenuItem.Click += new System.EventHandler(this.흑백이미지RGB계수ToolStripMenuItem_Click);
            // 
            // 흑백이미지ToolStripMenuItem
            // 
            this.흑백이미지ToolStripMenuItem.Name = "흑백이미지ToolStripMenuItem";
            this.흑백이미지ToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
            this.흑백이미지ToolStripMenuItem.Text = "흑백이미지";
            this.흑백이미지ToolStripMenuItem.Click += new System.EventHandler(this.흑백이미지ToolStripMenuItem_Click);
            // 
            // 흑백이미지평균ToolStripMenuItem
            // 
            this.흑백이미지평균ToolStripMenuItem.Name = "흑백이미지평균ToolStripMenuItem";
            this.흑백이미지평균ToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
            this.흑백이미지평균ToolStripMenuItem.Text = "흑백이미지 (Image평균)";
            this.흑백이미지평균ToolStripMenuItem.Click += new System.EventHandler(this.흑백이미지평균ToolStripMenuItem_Click);
            // 
            // 반전이미지ToolStripMenuItem
            // 
            this.반전이미지ToolStripMenuItem.Name = "반전이미지ToolStripMenuItem";
            this.반전이미지ToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
            this.반전이미지ToolStripMenuItem.Text = "반전이미지";
            this.반전이미지ToolStripMenuItem.Click += new System.EventHandler(this.반전이미지ToolStripMenuItem_Click);
            // 
            // 반전마우스ToolStripMenuItem
            // 
            this.반전마우스ToolStripMenuItem.Name = "반전마우스ToolStripMenuItem";
            this.반전마우스ToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
            this.반전마우스ToolStripMenuItem.Text = "반전마우스입력";
            this.반전마우스ToolStripMenuItem.Click += new System.EventHandler(this.반전마우스ToolStripMenuItem_Click);
            // 
            // 감마변환ToolStripMenuItem
            // 
            this.감마변환ToolStripMenuItem.Name = "감마변환ToolStripMenuItem";
            this.감마변환ToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
            this.감마변환ToolStripMenuItem.Text = "감마변환";
            this.감마변환ToolStripMenuItem.Click += new System.EventHandler(this.감마변환ToolStripMenuItem_Click);
            // 
            // 파라볼라ToolStripMenuItem
            // 
            this.파라볼라ToolStripMenuItem.Name = "파라볼라ToolStripMenuItem";
            this.파라볼라ToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
            this.파라볼라ToolStripMenuItem.Text = "파라볼라";
            this.파라볼라ToolStripMenuItem.Click += new System.EventHandler(this.파라볼라ToolStripMenuItem_Click);
            // 
            // 솔라라이징ToolStripMenuItem
            // 
            this.솔라라이징ToolStripMenuItem.Name = "솔라라이징ToolStripMenuItem";
            this.솔라라이징ToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
            this.솔라라이징ToolStripMenuItem.Text = "솔라라이징";
            this.솔라라이징ToolStripMenuItem.Click += new System.EventHandler(this.솔라라이징ToolStripMenuItem_Click);
            // 
            // 이미지합성ToolStripMenuItem
            // 
            this.이미지합성ToolStripMenuItem.Name = "이미지합성ToolStripMenuItem";
            this.이미지합성ToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
            this.이미지합성ToolStripMenuItem.Text = "이미지 합성";
            this.이미지합성ToolStripMenuItem.Click += new System.EventHandler(this.이미지합성ToolStripMenuItem_Click);
            // 
            // 기하학처리ToolStripMenuItem
            // 
            this.기하학처리ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.좌우미러링ToolStripMenuItem,
            this.상하미러링ToolStripMenuItem,
            this.확대ToolStripMenuItem,
            this.축소ToolStripMenuItem,
            this.회전ToolStripMenuItem,
            this.이동ToolStripMenuItem});
            this.기하학처리ToolStripMenuItem.Name = "기하학처리ToolStripMenuItem";
            this.기하학처리ToolStripMenuItem.Size = new System.Drawing.Size(103, 26);
            this.기하학처리ToolStripMenuItem.Text = "기하학 처리";
            // 
            // 좌우미러링ToolStripMenuItem
            // 
            this.좌우미러링ToolStripMenuItem.Name = "좌우미러링ToolStripMenuItem";
            this.좌우미러링ToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.좌우미러링ToolStripMenuItem.Text = "좌우미러링";
            this.좌우미러링ToolStripMenuItem.Click += new System.EventHandler(this.좌우미러링ToolStripMenuItem_Click);
            // 
            // 상하미러링ToolStripMenuItem
            // 
            this.상하미러링ToolStripMenuItem.Name = "상하미러링ToolStripMenuItem";
            this.상하미러링ToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.상하미러링ToolStripMenuItem.Text = "상하미러링";
            this.상하미러링ToolStripMenuItem.Click += new System.EventHandler(this.상하미러링ToolStripMenuItem_Click);
            // 
            // 확대ToolStripMenuItem
            // 
            this.확대ToolStripMenuItem.Name = "확대ToolStripMenuItem";
            this.확대ToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.확대ToolStripMenuItem.Text = "확대";
            this.확대ToolStripMenuItem.Click += new System.EventHandler(this.확대ToolStripMenuItem_Click);
            // 
            // 축소ToolStripMenuItem
            // 
            this.축소ToolStripMenuItem.Name = "축소ToolStripMenuItem";
            this.축소ToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.축소ToolStripMenuItem.Text = "축소";
            this.축소ToolStripMenuItem.Click += new System.EventHandler(this.축소ToolStripMenuItem_Click);
            // 
            // 회전ToolStripMenuItem
            // 
            this.회전ToolStripMenuItem.Name = "회전ToolStripMenuItem";
            this.회전ToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.회전ToolStripMenuItem.Text = "회전";
            this.회전ToolStripMenuItem.Click += new System.EventHandler(this.회전ToolStripMenuItem_Click);
            // 
            // 이동ToolStripMenuItem
            // 
            this.이동ToolStripMenuItem.Name = "이동ToolStripMenuItem";
            this.이동ToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.이동ToolStripMenuItem.Text = "이동";
            this.이동ToolStripMenuItem.Click += new System.EventHandler(this.이동ToolStripMenuItem_Click);
            // 
            // 화소영역처리ToolStripMenuItem
            // 
            this.화소영역처리ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.엠보싱ToolStripMenuItem,
            this.블러링3X3ToolStripMenuItem,
            this.블러링5X5ToolStripMenuItem,
            this.블러링입력ToolStripMenuItem,
            this.경계선ToolStripMenuItem,
            this.노이즈제거중간값정리ToolStripMenuItem,
            this.노이즈생성ToolStripMenuItem});
            this.화소영역처리ToolStripMenuItem.Name = "화소영역처리ToolStripMenuItem";
            this.화소영역처리ToolStripMenuItem.Size = new System.Drawing.Size(118, 26);
            this.화소영역처리ToolStripMenuItem.Text = "화소영역 처리";
            // 
            // 엠보싱ToolStripMenuItem
            // 
            this.엠보싱ToolStripMenuItem.Name = "엠보싱ToolStripMenuItem";
            this.엠보싱ToolStripMenuItem.Size = new System.Drawing.Size(248, 26);
            this.엠보싱ToolStripMenuItem.Text = "엠보싱";
            this.엠보싱ToolStripMenuItem.Click += new System.EventHandler(this.엠보싱ToolStripMenuItem_Click);
            // 
            // 블러링3X3ToolStripMenuItem
            // 
            this.블러링3X3ToolStripMenuItem.Name = "블러링3X3ToolStripMenuItem";
            this.블러링3X3ToolStripMenuItem.Size = new System.Drawing.Size(248, 26);
            this.블러링3X3ToolStripMenuItem.Text = "블러링 3X3";
            this.블러링3X3ToolStripMenuItem.Click += new System.EventHandler(this.블러링3X3ToolStripMenuItem_Click);
            // 
            // 블러링5X5ToolStripMenuItem
            // 
            this.블러링5X5ToolStripMenuItem.Name = "블러링5X5ToolStripMenuItem";
            this.블러링5X5ToolStripMenuItem.Size = new System.Drawing.Size(248, 26);
            this.블러링5X5ToolStripMenuItem.Text = "블러링 5X5";
            this.블러링5X5ToolStripMenuItem.Click += new System.EventHandler(this.블러링5X5ToolStripMenuItem_Click);
            // 
            // 블러링입력ToolStripMenuItem
            // 
            this.블러링입력ToolStripMenuItem.Name = "블러링입력ToolStripMenuItem";
            this.블러링입력ToolStripMenuItem.Size = new System.Drawing.Size(248, 26);
            this.블러링입력ToolStripMenuItem.Text = "블러링 입력";
            this.블러링입력ToolStripMenuItem.Click += new System.EventHandler(this.블러링입력ToolStripMenuItem_Click);
            // 
            // 경계선ToolStripMenuItem
            // 
            this.경계선ToolStripMenuItem.Name = "경계선ToolStripMenuItem";
            this.경계선ToolStripMenuItem.Size = new System.Drawing.Size(248, 26);
            this.경계선ToolStripMenuItem.Text = "경계선";
            this.경계선ToolStripMenuItem.Click += new System.EventHandler(this.경계선ToolStripMenuItem_Click);
            // 
            // 노이즈제거중간값정리ToolStripMenuItem
            // 
            this.노이즈제거중간값정리ToolStripMenuItem.Name = "노이즈제거중간값정리ToolStripMenuItem";
            this.노이즈제거중간값정리ToolStripMenuItem.Size = new System.Drawing.Size(248, 26);
            this.노이즈제거중간값정리ToolStripMenuItem.Text = "노이즈제거_중간값필터";
            this.노이즈제거중간값정리ToolStripMenuItem.Click += new System.EventHandler(this.노이즈제거중간값정리ToolStripMenuItem_Click);
            // 
            // 노이즈생성ToolStripMenuItem
            // 
            this.노이즈생성ToolStripMenuItem.Name = "노이즈생성ToolStripMenuItem";
            this.노이즈생성ToolStripMenuItem.Size = new System.Drawing.Size(248, 26);
            this.노이즈생성ToolStripMenuItem.Text = "노이즈생성_임펄스잡음";
            this.노이즈생성ToolStripMenuItem.Click += new System.EventHandler(this.노이즈생성ToolStripMenuItem_Click);
            // 
            // 히스토그램ToolStripMenuItem
            // 
            this.히스토그램ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.히스토그램스트레칭ToolStripMenuItem,
            this.엔드인탐색ToolStripMenuItem,
            this.평활화ToolStripMenuItem});
            this.히스토그램ToolStripMenuItem.Name = "히스토그램ToolStripMenuItem";
            this.히스토그램ToolStripMenuItem.Size = new System.Drawing.Size(98, 26);
            this.히스토그램ToolStripMenuItem.Text = "히스토그램";
            // 
            // 히스토그램스트레칭ToolStripMenuItem
            // 
            this.히스토그램스트레칭ToolStripMenuItem.Name = "히스토그램스트레칭ToolStripMenuItem";
            this.히스토그램스트레칭ToolStripMenuItem.Size = new System.Drawing.Size(232, 26);
            this.히스토그램스트레칭ToolStripMenuItem.Text = "히스토그램 스트레칭";
            this.히스토그램스트레칭ToolStripMenuItem.Click += new System.EventHandler(this.히스토그램스트레칭ToolStripMenuItem_Click);
            // 
            // 엔드인탐색ToolStripMenuItem
            // 
            this.엔드인탐색ToolStripMenuItem.Name = "엔드인탐색ToolStripMenuItem";
            this.엔드인탐색ToolStripMenuItem.Size = new System.Drawing.Size(232, 26);
            this.엔드인탐색ToolStripMenuItem.Text = "엔드-인 탐색";
            this.엔드인탐색ToolStripMenuItem.Click += new System.EventHandler(this.엔드인탐색ToolStripMenuItem_Click);
            // 
            // 평활화ToolStripMenuItem
            // 
            this.평활화ToolStripMenuItem.Name = "평활화ToolStripMenuItem";
            this.평활화ToolStripMenuItem.Size = new System.Drawing.Size(232, 26);
            this.평활화ToolStripMenuItem.Text = "평활화";
            this.평활화ToolStripMenuItem.Click += new System.EventHandler(this.평활화ToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 364);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "영상처리 프로그램 (Ver2.0)";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 파일ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 열기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 저장ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 종료ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 화소점처리ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 기하학처리ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 화소영역처리ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 히스토그램ToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem 동일이미지ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 밝게어둡게ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 그레이스케일ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 흑백이미지ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 흑백이미지평균ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 반전이미지ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 반전마우스ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 감마변환ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 파라볼라ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 솔라라이징ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 이미지합성ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 좌우미러링ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 상하미러링ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 확대ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 축소ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 회전ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 이동ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 엠보싱ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 블러링3X3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 블러링5X5ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 블러링입력ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 경계선ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 노이즈제거중간값정리ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 히스토그램스트레칭ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 엔드인탐색ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 평활화ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 노이즈생성ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 흑백이미지RGB계수ToolStripMenuItem;
    }
}

