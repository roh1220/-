#define   _CRT_SECURE_NO_WARNINGS
#define PI 3.1415926535897932
#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <Windows.h> // �ȼ��� ������ִ� ��� ����.
#include <math.h>

//////////////////////////////////////
// �Լ� ����
//////////////////////////////////////
// �����Լ�
void printMenu();
void openImage();
unsigned char** malloc2D(int, int);
void freeInputImage();
void freeOutputImage();
void freeOrImage();
void freeembossImage();
void freerotateImage();
void display();
void saveImage();
// ����ó���Լ�(1) - ȭ�� ��ó��
void equlImage();
void sumsubImage();
void revImage();
void bwImage();
void orImage();
// ����ó���Լ�(2) - ������ ó��
void rl_mirrImage();
void tb_mirrImage();
void sizeupImage();
void sizedownImage();
void moveImage();
void rotateImage();
void rotateImage__();
// ����ó���Լ�(3) - ȭ�ҿ��� ó��
void embossingImage();


//////////////////////////////////////
// �������� ����
//////////////////////////////////////
unsigned char** inImage = NULL, ** outImage = NULL;
unsigned char** orimage = NULL, ** embossImage = NULL, ** rotateimage = NULL;
int inH = 0, inW = 0, outH = 0, outW = 0;
int orH = 0, orW = 0, embH = 0, embW = 0, rotH = 0, rotW = 0;
char fName[200];
// ���� ȭ���
HWND hwnd;	HDC hdc;


//////////////////////////////////////
// ���κ�
//////////////////////////////////////
void main() {
	char select = 0;
	hwnd = GetForegroundWindow();
	hdc = GetWindowDC(hwnd);

	while (select != '2') {
		printMenu();
		select = getche();
		switch (select) {
			case '0':	openImage();	 break;
			case '1':	saveImage();
			case 'a':
			case 'A':	equlImage();	 break;
			case 'b':
			case 'B':	sumsubImage();	 break;
			case 'c':
			case 'C':	revImage();		 break;
			case 'd':
			case 'D':	bwImage();		 break;
			case 'e':
			case 'E':	rl_mirrImage();	 break;
			case 'f':
			case 'F':	tb_mirrImage();	 break;
			case 'g':
			case 'G':	sizeupImage();	 break;
			case 'h':
			case 'H':	sizedownImage(); break;
			case 'i':
			case 'I':	rotateImage();	 break;
			case 'j':
			case 'J':	orImage();		 break;
			case 'k':
			case 'K':	moveImage();	 break;
			case 'l':
			case 'L':	embossingImage();	 break;
			case 'q':
			case 'Q':	rotateImage__();	break;
			default: "Ű�� �߸� �Է��Ͽ����ϴ�.\n";
		}
	}
	freeInputImage();
	freeOutputImage();
}


//////////////////////////////////////
// �����Լ� ����
//////////////////////////////////////
void printMenu() {	// �޴� ����Լ�
	puts("\t ## ������ ����ó�� (Ver0.3) ##");
	puts("0. ����  1.����  2.����");
	puts("A. ���Ͽ���  B. ���/��Ӱ�  C. ����  D. ���  J.�̹��� ��ġ��  ");
	puts("E. �¿�̷���  F. ���Ϲ̷���  G. n�� Ȯ��  H. n�� ���  I. ȸ��  K. �̹��� �̵�");
	puts("L. ������");
}

void openImage() {	// ���� open�Լ�
	// ���� �̸� 
	strcpy(fName, "C:\\images\\raw\\");
	char tmpName[100];
	printf("\n������ ���ϸ� : ");
	scanf("%s", tmpName);
	strcat(fName, tmpName);
	strcat(fName, ".raw");

	// ���� ���� 
	FILE* rfp;
	rfp = fopen(fName, "rb");
	if (rfp == NULL) {
		MessageBox(hwnd, L"���ϸ��� �����", L"���â", NULL);
		return;
	}

	// ���� ũ�� �˾Ƴ���
	fseek(rfp, 0L, SEEK_END);
	long fsize = ftell(rfp);	// fsize = ���� ��ü ũ��
	fclose(rfp);
	rfp = fopen(fName, "rb");

	// ���� �޸� ����
	freeInputImage();

	// inH,inW �˾Ƴ��� : .raw ������ ����=����
	inH = inW = (int)sqrt(fsize);

	// inImage �޸� �Ҵ�
	inImage = malloc2D(inH, inW);

	// ���� �б�
	for (int i = 0; i < inH; i++) {
		fread(inImage[i], sizeof(unsigned char), inW, rfp);
	}

	fclose(rfp);

	equlImage();
}

unsigned char** malloc2D(int h, int w) { // 2���� �迭 �Ҵ�
	unsigned char** image;
	image = (unsigned char**)malloc(h * sizeof(unsigned char*));
	for (int i = 0; i < h; i++) {
		image[i] = (unsigned char*)malloc(w * sizeof(unsigned char));
	}
	return image;
}

void freeInputImage() {	// inImage �޸� ����
	if (inImage == NULL)	// ������ �ƹ��͵� ����X
		return;
	for (int i = 0; i < inH; i++) {		// �޸� ����
		free(inImage[i]);
	}
	free(inImage);
	inImage = NULL;
}

void freeOutputImage() {	// outImage �޸� ����
	if (outImage == NULL)	// ������ �ƹ��͵� ����X
		return;
	for (int i = 0; i < outH; i++) {	// �޸� ����
		free(outImage[i]);
	}
	free(outImage);
	outImage = NULL;
}

void freeOrImage() {	// orimage �޸� ����
	if (orimage == NULL)	// ������ �ƹ��͵� ����X
		return;
	for (int i = 0; i < orH; i++) {	// �޸� ����
		free(orimage[i]);
	}
	free(orimage);
	orimage = NULL;
}

void freeembossImage() {	// orimage �޸� ����
	if (embossImage == NULL)	// ������ �ƹ��͵� ����X
		return;
	for (int i = 0; i < embH; i++) {	// �޸� ����
		free(embossImage[i]);
	}
	free(embossImage);
	embossImage = NULL;
}

void freerotateImage() {	// orimage �޸� ����
	if (rotateimage == NULL)	// ������ �ƹ��͵� ����X
		return;
	for (int i = 0; i < rotH; i++) {	// �޸� ����
		free(rotateimage[i]);
	}
	free(rotateimage);
	rotateimage = NULL;
}

void display() {	// ���� ��� (���� + ����ó���� ����)
	system("cls");
	unsigned char px;
	for (int i = 0; i < inH; i++) {		// ����
		for (int k = 0; k < inW; k++) {
			px = inImage[i][k];
			SetPixel(hdc, k + 50, i + 200, RGB(px, px, px));
		}
	}
	for (int i = 0; i < outH; i++) {	// ����ó���� ����
		for (int k = 0; k < outW; k++) {
			px = outImage[i][k];
			SetPixel(hdc, k + 700, i + 200, RGB(px, px, px));
		}
	}
}

void saveImage() {	// ���� ����
	char sfname[200] = "C:\\images\\raw\\";
	char tmpFname[40];
	printf("������ ���� �̸� : ");
	scanf("%s", tmpFname);
	strcat(sfname, tmpFname);
	strcat(sfname, ".raw");
	
	FILE* wfp = fopen(sfname, "wb");
	for (int i = 0; i < outH; i++) {
		fwrite(outImage[i], sizeof(unsigned char), outW, wfp);
	}
	fclose(wfp);
	//printf("%s �� ����", sfname);
}


//////////////////////////////////////
// ����ó�� �˰��� �Լ� ����(1) - ȭ�� ��ó��
//////////////////////////////////////
void equlImage() {	// outImage�� ����
	// ���� �̹����� ���� ���, �۾����� ����
	if (inImage == NULL)
		return;
	// ������ �۾��� ���� ������ ����
	freeOutputImage();

	// outImage�� ����
	outH = inH;	outW = inW;
	outImage = malloc2D(outH, outW);
	for (int i = 0; i < outH; i++) {
		for (int k = 0; k < outW; k++) {
			outImage[i][k] = inImage[i][k];
		}
	}
	display();
}

void sumsubImage() {	// ��� ����
	// ���� �̹����� ���� ���, �۾����� ����
	if (inImage == NULL)
		return;
	// ������ �۾��� ���� ������ ����
	freeOutputImage();

	// ��� ����
	outH = inH;	outW = inW;
	outImage = malloc2D(outH, outW);
	int bright;
	printf("��� �Ϸ��� ���, ��Ӱ� �Ϸ��� ������ �Է��ϼ���. : ");
	scanf("%d", &bright);
	//printf("%d", bright);
	for (int i = 0; i < outH; i++) {
		for (int k = 0; k < outW; k++) {
			if ((inImage[i][k] + bright) > 255)
				outImage[i][k] = 255;
			else if ((inImage[i][k] + bright) < 0)
				outImage[i][k] = 0;
			else
				outImage[i][k] = inImage[i][k] + bright;
		}
	}
	display();
}

void revImage() {	// �������
	// ���� �̹����� ���� ���, �۾����� ����
	if (inImage == NULL)
		return;
	// ������ �۾��� ���� ������ ����
	freeOutputImage();

	// ���� ����
	printf("���� ����\n");
	outH = inH;	outW = inW;
	outImage = malloc2D(outH, outW);
	printf("output�޸� �Ҵ�\n");
	for (int i = 0; i < outH; i++) {
		for (int k = 0; k < outW; k++) {
			outImage[i][k] = 255 - inImage[i][k];
		}
	}
	printf("���� ���� ���\n");
	display();
}

void bwImage() {	// ���
	// ���� �̹����� ���� ���, �۾����� ����
	if (inImage == NULL)
		return;
	// ������ �۾��� ���� ������ ����
	freeOutputImage();

	// ���
	outH = inH;	outW = inW;
	outImage = malloc2D(outH, outW);
	for (int i = 0; i < outH; i++) {
		for (int k = 0; k < outW; k++) {
			if (inImage[i][k] > 128)
				outImage[i][k] = 255;
			else
				outImage[i][k] = 0;
		}
	}
	display();
}

void orImage() {	// �̹��� + �̹���(���) = ������->������, �������� �ƴ� �κ�->�״�� ���
	// ���� �̹����� ���� ���, �۾����� ����
	if (inImage == NULL)
		return;
	// ������ �۾��� ���� ������ ����
	freeOutputImage();

	// ��ĥ ��� �̹��� ���� (��, ũ��� ����)
	char orfname[200] = "C:\\images\\raw\\";
	char tempFname[50];
	printf("��ĥ ���� �����̸� : ");
	scanf("%s", tempFname);
	strcat(orfname, tempFname);
	strcat(orfname, ".raw");
	//printf("%s\n", orfname);

	// ��ĥ �̹��� ũ�� Ȯ���ϱ� (�������� Ȯ���ϱ� ����)
	FILE* or_rfp = fopen(orfname, "rb");
	if (or_rfp == NULL) {
		MessageBox(hwnd, L"���ϸ��� �����", L"���â", NULL);
		return;
	}
	fseek(or_rfp, 0L, SEEK_END);
	long or_fsize = ftell(or_rfp);
	fclose(or_rfp); 
	or_rfp = fopen(orfname, "rb");
	//printf("�̹��� ũ�� Ȯ��\n");

	// ������ �۾��� ���� ������ ����
	freeOrImage();

	// �̹��� ũ�� �����ϸ� ���� �б�
	orH = orW = (int)sqrt(or_fsize);
	printf("�̹��� ����,���� ���� : %d\n", orH);
	if (orH == inH) {
		// printf("if�� ��");
		orimage = malloc2D(orH, orW);
		for (int i = 0; i < orH; i++) {
			fread(orimage[i], sizeof(unsigned char), orW, or_rfp);
		}
		fclose(or_rfp);

		// or���� ����
		//printf("or���� ����\n");
		outH = inH;	outW = inW;
		outImage = malloc2D(outH, outW);
		//printf("outImage �޸� �Ҵ�");
		for (int i = 0; i < outH; i++) {
			for (int k = 0; k < outW; k++) {
				if (orimage[i][k] == 0)	// ������ -> ������ ���
					outImage[i][k] = orimage[i][k] * inImage[i][k];
				else	// �Ͼ�� -> ���� �̹��� ���
					outImage[i][k] = inImage[i][k];
			}
		}
		display();
	}
	else
		printf("ũ�Ⱑ ���� �ʽ��ϴ�.\n");
}


//////////////////////////////////////
// ����ó�� �˰��� �Լ� ����(2) - ������ ó��
//////////////////////////////////////
void rl_mirrImage() {	// �¿�̷���
	// ���� �̹����� ���� ���, �۾����� ����
	if (inImage == NULL)
		return;
	// ������ �۾��� ���� ������ ����
	freeOutputImage();

	// �¿�̷���
	outH = inH;	outW = inW;
	outImage = malloc2D(outH, outW);
	for (int i = 0; i < outH; i++) {
		for (int k = 0; k < outW / 2; k++) {
			outImage[i][k] = inImage[i][outW - k - 1];
			outImage[i][outW - k - 1] = inImage[i][k];
		}
	}
	display();
}

void tb_mirrImage() {	// ���Ϲ̷���
	// ���� �̹����� ���� ���, �۾����� ����
	if (inImage == NULL)
		return;
	// ������ �۾��� ���� ������ ����
	freeOutputImage();

	// ���Ϲ̷���
	outH = inH;	outW = inW;
	outImage = malloc2D(outH, outW);
	for (int i = 0; i < outH / 2; i++) {
		for (int k = 0; k < outW; k++) {
			outImage[i][k] = inImage[outH - i - 1][k];
			outImage[outH - i - 1][k] = inImage[i][k];
		}
	}
	display();
}

void sizeupImage() {	// n�� Ȯ�� (������)
	// ���� �̹����� ���� ���, �۾����� ����
	if (inImage == NULL)
		return;
	// ������ �۾��� ���� ������ ����
	freeOutputImage();

	// Ȯ�� ���� �Է�
	printf("Ȯ�� ���� : ");
	int scale;
	scanf("%d", &scale);

	// n�� Ȯ��
	outH = scale * inH;	outW = scale * inW;
	outImage = malloc2D(outH, outW);
	for (int i = 0; i < outH; i++) {
		for (int k = 0; k < outW; k++) {
			outImage[i][k] = inImage[i / scale][k / scale];
		}
	}
	display();
}

void sizedownImage() {	// n�� ��� (������)
	// ���� �̹����� ���� ���, �۾����� ����
	if (inImage == NULL)
		return;
	// ������ �۾��� ���� ������ ����
	freeOutputImage();

	// ��� ���� �Է�
	printf("��� ���� : ");
	int scale;
	scanf("%d", &scale);

	// n�� ���
	outH = inH / scale;	outW = inW / scale;
	outImage = malloc2D(outH, outW);
	for (int i = 0; i < outH; i++) {
		for (int k = 0; k < outW; k++) {
			outImage[i][k] = inImage[i * scale][k * scale];
		}
	}
	display();
}

void rotateImage() {	// ȸ�� (ȸ���� �̹��� ���� ���)
	// ���� �̹����� ���� ���, �۾����� ����
	if (inImage == NULL)
		return;
	// ������ �۾��� ���� ������ ����
	freeOutputImage(); 
	freerotateImage();

	// ȸ���ϰ� ���� ���� �Է�
	int theta;
	int rotate_h, rotate_w;
	printf("ȸ�� ���� : ");
	scanf("%d", &theta);
	double rad = (double)theta * PI / 180.;

	// ȸ������ �� ũ�� ���ϱ�
	rotH = abs(inW * sin(rad)) + abs(inH * cos(rad));
	rotW = abs(inH * sin(rad)) + abs(inW * cos(rad));
	printf("ȸ������ ���� ũ�� : %d %d\n", rotH, rotW);

	// �̹��� �߽� ���ϱ� (���� �߽����� ȸ����Ű�� ����)
	int centerH = rotH / 2, centerW = rotW / 2;

	// ȸ������ ���� ũ��� rotateimage �޸� �Ҵ�޾� �߾ӿ� inputImage�� ����
	rotateimage = malloc2D(rotH, rotW);
	for (int i = 0; i < rotH; i++)	// ���������� �ʱ�ȭ
		for (int k = 0; k < rotW; k++)
			rotateimage[i][k] = 0;
	for (int i = centerH - (inH / 2), n = 0; i < centerH + (inH / 2); i++, n++)	// �߾ӿ� inputImage ����
		for (int k = centerW - (inW / 2), m = 0; k < centerW + (inW / 2); k++, m++)
			rotateimage[i][k] = inImage[n][m];

	// outImage�޸� �Ҵ�
	outH = rotH;	outW = rotW;
	outImage = malloc2D(outH, outW);

	// �̹��� ȸ��
	for (int i = 0; i < outH; i++) {
		for (int k = 0; k < outW; k++) {
			rotate_h = (int)((i - centerH) * cos(rad) - (k - centerW) * sin(rad) + centerH);
			rotate_w = (int)((i - centerH) * sin(rad) + (k - centerW) * cos(rad) + centerW);
			if ((rotate_w >= 0 && rotate_w < outW) && (rotate_h >= 0 && rotate_h < outH))
				outImage[i][k] = rotateimage[rotate_h][rotate_w];
			else {
				outImage[i][k] = 0;
			}
		}
	}
	display();
}

/////////////////////////////////////////////////////////////////////////////
void rotateImage__() {	// ȸ�� (ȸ���ϸ� ©��)
	// ���� �̹����� ���� ���, �۾����� ����
	if (inImage == NULL)
		return;
	// ������ �۾��� ���� ������ ����
	freeOutputImage();
	freerotateImage();

	// ȸ���ϰ� ���� ���� �Է�
	int theta;
	int rotate_h, rotate_w;
	printf("ȸ�� ���� : ");
	scanf("%d", &theta);
	double rad = (double)theta * PI / 180.;

	// �̹��� �߽� ���ϱ� (���� �߽����� ȸ����Ű�� ����)
	int centerH = inH / 2, centerW = inW / 2;

	// outImage�޸� �Ҵ�
	outH = inH;	outW = inW;
	outImage = malloc2D(outH, outW);

	// �̹��� ȸ��
	for (int i = 0; i < outH; i++) {
		for (int k = 0; k < outW; k++) {
			rotate_h = (int)((i - centerH) * cos(rad) - (k - centerW) * sin(rad) + centerH);
			rotate_w = (int)((i - centerH) * sin(rad) + (k - centerW) * cos(rad) + centerW);
			if ((rotate_w >= 0 && rotate_w < outW) && (rotate_h >= 0 && rotate_h < outH))
				outImage[i][k] = inImage[rotate_h][rotate_w];
			else {
				outImage[i][k] = 0;
			}
		}
	}
	display();
}


void moveImage() {	// �̹��� �̵�
	// ���� �̹����� ���� ���, �۾����� ����
	if (inImage == NULL)
		return;
	// ������ �۾��� ���� ������ ����
	freeOutputImage();

	// ��ŭ �̵����� �Է�
	int move_h, move_w;
	printf("���� �̵�, ���� �̵� : ");
	scanf("%d %d", &move_h, &move_w);

	// �̹��� �̵�
	outH = inH;	outW = inW;
	outImage = malloc2D(outH, outW);
	for (int i = 0; i < outH; i++) {
		for (int k = 0; k < outW; k++) {
			if ((i + move_h >= 0 && i + move_h < outH) && (k + move_w >= 0 && k + move_w < outW))
				outImage[i + move_h][k + move_w] = inImage[i][k];
		}
	}
	display();
}

//////////////////////////////////////
// ����ó�� �˰��� �Լ� ����(3) - ȭ�� ���� ó��
//////////////////////////////////////
void embossingImage() {		// ������
	// ���� �̹����� ���� ���, �۾����� ����
	if (inImage == NULL)
		return;
	// ������ �۾��� ���� ������ ����
	freeOutputImage();
	freeembossImage();

	// �����̿� �ʿ��� ����ũ
	int emboMask[3][3] = { {-1,0,0},{0,0,0},{0,0,1} };

	// ���κ� ó���� ���� inputImage �޸� �ٽ� ��� - ����ũ�� ����
	// ũ�⸦ +2��ŭ���� �ٽ� ���� ��, NULL�� �ʱ�ȭ
	embossImage = malloc2D(inH + 2, inW + 2);
	for (int i = 0; i < inH + 2; i++)
		for (int k = 0; k < inW + 2; k++)
			embossImage[i][k] = NULL;
	// �����ڸ��� ������ �κп� inputImage�ֱ�
	for (int i = 1; i < inH + 1; i++)
		for (int k = 1; k < inW + 1; k++)
			embossImage[i][k] = inImage[i - 1][k - 1];
	// ä������ ���� �����ڸ� �κ��� �ݴ��� �ִ� �ȼ��� ä��
	int emboinH, emboinW;
	for (int i = 0; i < inH + 2; i++)
		for (int k = 0; k < inW + 2; k++) {
			if (embossImage[i][k] == NULL){
				if (i == 0)				emboinH = inH - 1;
				else if (i == inH + 1)	emboinH = 0;
				if (k == 0)				emboinW = inW - 1;
				else if (k == inW + 1)	emboinW = 0;
				embossImage[i][k] = inImage[emboinH][emboinW];
			}
		}
	// printf("embossImage[][] �־��ֱ�\n");

	// emboMask ����
	outH = inH, outW = inW;
	outImage = malloc2D(outH, outW);
	int embo_sum = 0;
	for (int i = 0; i < outH; i++) {
		for (int k = 0; k < outW; k++) {
			embo_sum = 0;
			for (int n = 0; n < 3; n++) {
				for (int m = 0; m < 3; m++) {
					embo_sum += emboMask[n][m] * embossImage[i + n][k + m];
				}
			}
			if (embo_sum < 0)
				embo_sum = 0;
			else if (embo_sum > 255)
				embo_sum = 255;
			outImage[i][k] = embo_sum;
		}
	}

	// ����ȭ 
	int min, max;
	int sum = 0;
	min = max = outImage[0][0];

	for (int i = 0; i < outH; i++)
		for (int k = 0; k < outW; k++)
			if (outImage[i][k] < min)
				min = outImage[i][k];
	for (int i = 0; i < outH; i++)
		for (int k = 0; k < outW; k++){
			sum += outImage[i][k];
			if (outImage[i][k] > max)
				max = outImage[i][k];
		}

	for (int i = 0; i < outH; i++) {
		for (int k = 0; k < outW; k++) {
			outImage[i][k] = (outImage[i][k] - min) * (255.0 / (max - min));
		}
	}
	
	display();
}