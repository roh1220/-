#define   _CRT_SECURE_NO_WARNINGS
#define PI 3.1415926535897932
#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <Windows.h> // 픽셀을 출력해주는 기능 포함.
#include <math.h>

//////////////////////////////////////
// 함수 선언
//////////////////////////////////////
// 공통함수
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
// 영상처리함수(1) - 화소 점처리
void equlImage();
void sumsubImage();
void revImage();
void bwImage();
void orImage();
// 영상처리함수(2) - 기하학 처리
void rl_mirrImage();
void tb_mirrImage();
void sizeupImage();
void sizedownImage();
void moveImage();
void rotateImage();
void rotateImage__();
// 영상처리함수(3) - 화소영역 처리
void embossingImage();


//////////////////////////////////////
// 전역변수 선언
//////////////////////////////////////
unsigned char** inImage = NULL, ** outImage = NULL;
unsigned char** orimage = NULL, ** embossImage = NULL, ** rotateimage = NULL;
int inH = 0, inW = 0, outH = 0, outW = 0;
int orH = 0, orW = 0, embH = 0, embW = 0, rotH = 0, rotW = 0;
char fName[200];
// 윈도 화면용
HWND hwnd;	HDC hdc;


//////////////////////////////////////
// 메인부
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
			default: "키를 잘못 입력하였습니다.\n";
		}
	}
	freeInputImage();
	freeOutputImage();
}


//////////////////////////////////////
// 공통함수 정의
//////////////////////////////////////
void printMenu() {	// 메뉴 출력함수
	puts("\t ## 디지털 영상처리 (Ver0.3) ##");
	puts("0. 열기  1.저장  2.종료");
	puts("A. 동일영상  B. 밝게/어둡게  C. 반전  D. 흑백  J.이미지 합치기  ");
	puts("E. 좌우미러링  F. 상하미러링  G. n배 확대  H. n배 축소  I. 회전  K. 이미지 이동");
	puts("L. 엠보싱");
}

void openImage() {	// 파일 open함수
	// 파일 이름 
	strcpy(fName, "C:\\images\\raw\\");
	char tmpName[100];
	printf("\n오픈할 파일명 : ");
	scanf("%s", tmpName);
	strcat(fName, tmpName);
	strcat(fName, ".raw");

	// 파일 오픈 
	FILE* rfp;
	rfp = fopen(fName, "rb");
	if (rfp == NULL) {
		MessageBox(hwnd, L"파일명이 없어요", L"출력창", NULL);
		return;
	}

	// 파일 크기 알아내기
	fseek(rfp, 0L, SEEK_END);
	long fsize = ftell(rfp);	// fsize = 파일 전체 크기
	fclose(rfp);
	rfp = fopen(fName, "rb");

	// 기존 메모리 해제
	freeInputImage();

	// inH,inW 알아내기 : .raw 파일은 가로=세로
	inH = inW = (int)sqrt(fsize);

	// inImage 메모리 할당
	inImage = malloc2D(inH, inW);

	// 파일 읽기
	for (int i = 0; i < inH; i++) {
		fread(inImage[i], sizeof(unsigned char), inW, rfp);
	}

	fclose(rfp);

	equlImage();
}

unsigned char** malloc2D(int h, int w) { // 2차원 배열 할당
	unsigned char** image;
	image = (unsigned char**)malloc(h * sizeof(unsigned char*));
	for (int i = 0; i < h; i++) {
		image[i] = (unsigned char*)malloc(w * sizeof(unsigned char));
	}
	return image;
}

void freeInputImage() {	// inImage 메모리 해제
	if (inImage == NULL)	// 없으면 아무것도 실행X
		return;
	for (int i = 0; i < inH; i++) {		// 메모리 해제
		free(inImage[i]);
	}
	free(inImage);
	inImage = NULL;
}

void freeOutputImage() {	// outImage 메모리 해제
	if (outImage == NULL)	// 없으면 아무것도 실행X
		return;
	for (int i = 0; i < outH; i++) {	// 메모리 해제
		free(outImage[i]);
	}
	free(outImage);
	outImage = NULL;
}

void freeOrImage() {	// orimage 메모리 해제
	if (orimage == NULL)	// 없으면 아무것도 실행X
		return;
	for (int i = 0; i < orH; i++) {	// 메모리 해제
		free(orimage[i]);
	}
	free(orimage);
	orimage = NULL;
}

void freeembossImage() {	// orimage 메모리 해제
	if (embossImage == NULL)	// 없으면 아무것도 실행X
		return;
	for (int i = 0; i < embH; i++) {	// 메모리 해제
		free(embossImage[i]);
	}
	free(embossImage);
	embossImage = NULL;
}

void freerotateImage() {	// orimage 메모리 해제
	if (rotateimage == NULL)	// 없으면 아무것도 실행X
		return;
	for (int i = 0; i < rotH; i++) {	// 메모리 해제
		free(rotateimage[i]);
	}
	free(rotateimage);
	rotateimage = NULL;
}

void display() {	// 사진 출력 (원본 + 영상처리한 사진)
	system("cls");
	unsigned char px;
	for (int i = 0; i < inH; i++) {		// 원본
		for (int k = 0; k < inW; k++) {
			px = inImage[i][k];
			SetPixel(hdc, k + 50, i + 200, RGB(px, px, px));
		}
	}
	for (int i = 0; i < outH; i++) {	// 영상처리된 사진
		for (int k = 0; k < outW; k++) {
			px = outImage[i][k];
			SetPixel(hdc, k + 700, i + 200, RGB(px, px, px));
		}
	}
}

void saveImage() {	// 파일 저장
	char sfname[200] = "C:\\images\\raw\\";
	char tmpFname[40];
	printf("저장할 파일 이름 : ");
	scanf("%s", tmpFname);
	strcat(sfname, tmpFname);
	strcat(sfname, ".raw");
	
	FILE* wfp = fopen(sfname, "wb");
	for (int i = 0; i < outH; i++) {
		fwrite(outImage[i], sizeof(unsigned char), outW, wfp);
	}
	fclose(wfp);
	//printf("%s 로 저장", sfname);
}


//////////////////////////////////////
// 영상처리 알고리즘 함수 정의(1) - 화소 점처리
//////////////////////////////////////
void equlImage() {	// outImage에 복사
	// 열린 이미지가 없을 경우, 작업하지 않음
	if (inImage == NULL)
		return;
	// 기존에 작업한 것이 있으면 해제
	freeOutputImage();

	// outImage에 복사
	outH = inH;	outW = inW;
	outImage = malloc2D(outH, outW);
	for (int i = 0; i < outH; i++) {
		for (int k = 0; k < outW; k++) {
			outImage[i][k] = inImage[i][k];
		}
	}
	display();
}

void sumsubImage() {	// 밝기 조절
	// 열린 이미지가 없을 경우, 작업하지 않음
	if (inImage == NULL)
		return;
	// 기존에 작업한 것이 있으면 해제
	freeOutputImage();

	// 밝기 조절
	outH = inH;	outW = inW;
	outImage = malloc2D(outH, outW);
	int bright;
	printf("밝게 하려면 양수, 어둡게 하려면 음수를 입력하세요. : ");
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

void revImage() {	// 영상반전
	// 열린 이미지가 없을 경우, 작업하지 않음
	if (inImage == NULL)
		return;
	// 기존에 작업한 것이 있으면 해제
	freeOutputImage();

	// 영상 반전
	printf("영상 반전\n");
	outH = inH;	outW = inW;
	outImage = malloc2D(outH, outW);
	printf("output메모리 할당\n");
	for (int i = 0; i < outH; i++) {
		for (int k = 0; k < outW; k++) {
			outImage[i][k] = 255 - inImage[i][k];
		}
	}
	printf("영상 반전 기능\n");
	display();
}

void bwImage() {	// 흑백
	// 열린 이미지가 없을 경우, 작업하지 않음
	if (inImage == NULL)
		return;
	// 기존에 작업한 것이 있으면 해제
	freeOutputImage();

	// 흑백
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

void orImage() {	// 이미지 + 이미지(흑백) = 검은색->검은색, 검은색이 아닌 부분->그대로 출력
	// 열린 이미지가 없을 경우, 작업하지 않음
	if (inImage == NULL)
		return;
	// 기존에 작업한 것이 있으면 해제
	freeOutputImage();

	// 합칠 흑백 이미지 열기 (단, 크기는 동일)
	char orfname[200] = "C:\\images\\raw\\";
	char tempFname[50];
	printf("합칠 영상 파일이름 : ");
	scanf("%s", tempFname);
	strcat(orfname, tempFname);
	strcat(orfname, ".raw");
	//printf("%s\n", orfname);

	// 합칠 이미지 크기 확인하기 (동일한지 확인하기 위해)
	FILE* or_rfp = fopen(orfname, "rb");
	if (or_rfp == NULL) {
		MessageBox(hwnd, L"파일명이 없어요", L"출력창", NULL);
		return;
	}
	fseek(or_rfp, 0L, SEEK_END);
	long or_fsize = ftell(or_rfp);
	fclose(or_rfp); 
	or_rfp = fopen(orfname, "rb");
	//printf("이미지 크기 확인\n");

	// 기존에 작업한 것이 있으면 해제
	freeOrImage();

	// 이미지 크기 동일하면 파일 읽기
	orH = orW = (int)sqrt(or_fsize);
	printf("이미지 가로,세로 길이 : %d\n", orH);
	if (orH == inH) {
		// printf("if문 안");
		orimage = malloc2D(orH, orW);
		for (int i = 0; i < orH; i++) {
			fread(orimage[i], sizeof(unsigned char), orW, or_rfp);
		}
		fclose(or_rfp);

		// or연산 실행
		//printf("or연산 실행\n");
		outH = inH;	outW = inW;
		outImage = malloc2D(outH, outW);
		//printf("outImage 메모리 할당");
		for (int i = 0; i < outH; i++) {
			for (int k = 0; k < outW; k++) {
				if (orimage[i][k] == 0)	// 검은색 -> 검은색 출력
					outImage[i][k] = orimage[i][k] * inImage[i][k];
				else	// 하얀색 -> 원래 이미지 출력
					outImage[i][k] = inImage[i][k];
			}
		}
		display();
	}
	else
		printf("크기가 맞지 않습니다.\n");
}


//////////////////////////////////////
// 영상처리 알고리즘 함수 정의(2) - 기하학 처리
//////////////////////////////////////
void rl_mirrImage() {	// 좌우미러링
	// 열린 이미지가 없을 경우, 작업하지 않음
	if (inImage == NULL)
		return;
	// 기존에 작업한 것이 있으면 해제
	freeOutputImage();

	// 좌우미러링
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

void tb_mirrImage() {	// 상하미러링
	// 열린 이미지가 없을 경우, 작업하지 않음
	if (inImage == NULL)
		return;
	// 기존에 작업한 것이 있으면 해제
	freeOutputImage();

	// 상하미러링
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

void sizeupImage() {	// n배 확대 (정수배)
	// 열린 이미지가 없을 경우, 작업하지 않음
	if (inImage == NULL)
		return;
	// 기존에 작업한 것이 있으면 해제
	freeOutputImage();

	// 확대 배율 입력
	printf("확대 배율 : ");
	int scale;
	scanf("%d", &scale);

	// n배 확대
	outH = scale * inH;	outW = scale * inW;
	outImage = malloc2D(outH, outW);
	for (int i = 0; i < outH; i++) {
		for (int k = 0; k < outW; k++) {
			outImage[i][k] = inImage[i / scale][k / scale];
		}
	}
	display();
}

void sizedownImage() {	// n배 축소 (정수배)
	// 열린 이미지가 없을 경우, 작업하지 않음
	if (inImage == NULL)
		return;
	// 기존에 작업한 것이 있으면 해제
	freeOutputImage();

	// 축소 배율 입력
	printf("축소 배율 : ");
	int scale;
	scanf("%d", &scale);

	// n배 축소
	outH = inH / scale;	outW = inW / scale;
	outImage = malloc2D(outH, outW);
	for (int i = 0; i < outH; i++) {
		for (int k = 0; k < outW; k++) {
			outImage[i][k] = inImage[i * scale][k * scale];
		}
	}
	display();
}

void rotateImage() {	// 회전 (회전한 이미지 전부 출력)
	// 열린 이미지가 없을 경우, 작업하지 않음
	if (inImage == NULL)
		return;
	// 기존에 작업한 것이 있으면 해제
	freeOutputImage(); 
	freerotateImage();

	// 회전하고 싶은 각도 입력
	int theta;
	int rotate_h, rotate_w;
	printf("회전 각도 : ");
	scanf("%d", &theta);
	double rad = (double)theta * PI / 180.;

	// 회전했을 때 크기 구하기
	rotH = abs(inW * sin(rad)) + abs(inH * cos(rad));
	rotW = abs(inH * sin(rad)) + abs(inW * cos(rad));
	printf("회전했을 때의 크기 : %d %d\n", rotH, rotW);

	// 이미지 중심 구하기 (영상 중심으로 회전시키기 위해)
	int centerH = rotH / 2, centerW = rotW / 2;

	// 회전했을 때의 크기로 rotateimage 메모리 할당받아 중앙에 inputImage를 넣음
	rotateimage = malloc2D(rotH, rotW);
	for (int i = 0; i < rotH; i++)	// 검은색으로 초기화
		for (int k = 0; k < rotW; k++)
			rotateimage[i][k] = 0;
	for (int i = centerH - (inH / 2), n = 0; i < centerH + (inH / 2); i++, n++)	// 중앙에 inputImage 넣음
		for (int k = centerW - (inW / 2), m = 0; k < centerW + (inW / 2); k++, m++)
			rotateimage[i][k] = inImage[n][m];

	// outImage메모리 할당
	outH = rotH;	outW = rotW;
	outImage = malloc2D(outH, outW);

	// 이미지 회전
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
void rotateImage__() {	// 회전 (회전하면 짤림)
	// 열린 이미지가 없을 경우, 작업하지 않음
	if (inImage == NULL)
		return;
	// 기존에 작업한 것이 있으면 해제
	freeOutputImage();
	freerotateImage();

	// 회전하고 싶은 각도 입력
	int theta;
	int rotate_h, rotate_w;
	printf("회전 각도 : ");
	scanf("%d", &theta);
	double rad = (double)theta * PI / 180.;

	// 이미지 중심 구하기 (영상 중심으로 회전시키기 위해)
	int centerH = inH / 2, centerW = inW / 2;

	// outImage메모리 할당
	outH = inH;	outW = inW;
	outImage = malloc2D(outH, outW);

	// 이미지 회전
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


void moveImage() {	// 이미지 이동
	// 열린 이미지가 없을 경우, 작업하지 않음
	if (inImage == NULL)
		return;
	// 기존에 작업한 것이 있으면 해제
	freeOutputImage();

	// 얼만큼 이동할지 입력
	int move_h, move_w;
	printf("가로 이동, 세로 이동 : ");
	scanf("%d %d", &move_h, &move_w);

	// 이미지 이동
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
// 영상처리 알고리즘 함수 정의(3) - 화소 영역 처리
//////////////////////////////////////
void embossingImage() {		// 엠보싱
	// 열린 이미지가 없을 경우, 작업하지 않음
	if (inImage == NULL)
		return;
	// 기존에 작업한 것이 있으면 해제
	freeOutputImage();
	freeembossImage();

	// 엠보싱에 필요한 마스크
	int emboMask[3][3] = { {-1,0,0},{0,0,0},{0,0,1} };

	// 경계부분 처리를 위해 inputImage 메모리 다시 잡기 - 영상크기 조정
	// 크기를 +2만큼으로 다시 잡은 후, NULL로 초기화
	embossImage = malloc2D(inH + 2, inW + 2);
	for (int i = 0; i < inH + 2; i++)
		for (int k = 0; k < inW + 2; k++)
			embossImage[i][k] = NULL;
	// 가장자리를 제외한 부분에 inputImage넣기
	for (int i = 1; i < inH + 1; i++)
		for (int k = 1; k < inW + 1; k++)
			embossImage[i][k] = inImage[i - 1][k - 1];
	// 채워지지 않은 가장자리 부분을 반대편에 있는 픽셀로 채움
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
	// printf("embossImage[][] 넣어주기\n");

	// emboMask 연산
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

	// 정규화 
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