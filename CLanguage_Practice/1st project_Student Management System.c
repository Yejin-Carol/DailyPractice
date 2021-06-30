#include <stdio.h>
#include <Windows.h>

int arr1[6][8] =
{ {97,78,56,67,96  },
{86,67,89,75,78  },
{89,98,87,59,90  },
{56,78,81,89,85  },
{98,79,90,89,95  }
};//1학기 점수 데이타
int arr2[6][8];
int i, j;
int sum1, sum2, sum3, sum4, avr1, avr2, avr3, avr4;
char grade;

void Array1(void)
{
	printf("<<1학기 성적>>\n");
	//학생별 점수 합계, 평균
	
	for (i = 0; i < 4; i++)
	{
		sum1 = 0;

		for (j = 0; j < 5; j++)
		{
			sum1 += arr1[i][j];
		}
		arr1[i][5] = sum1;
		avr1 = sum1 / 5;
		arr1[i][6] = avr1;

		if (avr1 >= 90)
			grade = 'A';
		else if (avr1 >= 80 && avr1 < 90)
			grade = 'B';
		else if (avr1 >= 70 && avr1 < 80)
			grade = 'C';
		else if (avr1 >= 60 && avr1 < 70)
			grade = 'D';
		else
			grade = 'F';

		arr1[i][7] = grade;
	}
	//과목별 점수 입력, 합계, 평균
	for (i = 0; i < 5; i++)
	{
		sum2 = 0;
		for (j = 0; j < 4; j++)
		{
			sum2 += arr1[j][i];
		}
		arr1[4][i] = sum2;
		avr2 = sum2 / 4;
		arr1[5][i] = avr2;
	}
	//ShowAll
	printf("\n\n이름\t" "국어\t" "영어\t" "수학\t" "사회\t" "과학\t" "합계\t" "평균\t" "등급\n\n");
	for (i = 0; i < 6; i++)
	{
		if (i == 0)
			printf("전지현\t");
		else if (i == 1)
			printf("송중기\t");
		else if (i == 2)
			printf("한지민\t");
		else if (i == 3)
			printf("장동건\t");
		else if (i == 4)
			printf(" 합계\t");
		else
			printf(" 평균\t");

		for (j = 0; j < 7; j++)
		{
			printf("%3d\t", arr1[i][j]);
		}
		printf("%c", arr1[i][7]);
		printf("\n");
	}
	printf("\n\n");
}
//1학기 성적 합계 & 평균, 등급 구하기

void Array2(void)
{
	printf("2학기 성적을 넣어주세요.\n");
	//학생별 점수 합계, 평균
	for (i = 0; i < 4; i++)
	{
		sum3 = 0;
		for (j = 0; j < 5; j++)
		{
			scanf_s("%d", &arr2[i][j]);
			sum3 += arr2[i][j];
		}
		arr2[i][5] = sum3;
		avr3 = sum3 / 5;
		arr2[i][6] = avr3;

		if (avr3 >= 90)
			grade = 'A';
		else if (avr3 >= 80 && avr3 < 90)
			grade = 'B';
		else if (avr3 >= 70 && avr3 < 80)
			grade = 'C';
		else if (avr3 >= 60 && avr3 < 70)
			grade = 'D';
		else
			grade = 'F';

		arr2[i][7] = grade;
	}

	//과목별 점수 입력, 합계, 평균
	for (i = 0; i < 5; i++)
	{
		sum4 = 0;
		for (j = 0; j < 4; j++)
		{
			sum4 += arr2[j][i];
		}
		arr2[4][i] = sum4;
		avr4 = sum4 / 4;
		arr2[5][i] = avr4;
	}

	//ShowAll
	printf("\n\n<<2학기 성적>>\n");
	printf("\n이름\t" "국어\t" "영어\t" "수학\t" "사회\t" "과학\t" "합계\t" "평균\t""등급\n\n");
	for (i = 0; i < 6; i++)
	{
		if (i == 0)
			printf("전지현\t");
		else if (i == 1)
			printf("송중기\t");
		else if (i == 2)
			printf("한지민\t");
		else if (i == 3)
			printf("장동건\t");
		else if (i == 4)
			printf(" 합계\t");
		else
			printf(" 평균\t");

		for (j = 0; j < 7; j++)
		{
			printf("%3d\t", arr2[i][j]);
		}
		printf("%c", arr2[i][7]);
		printf("\n");
	}
	printf("\n\n");
}
//2학기 성적 입력, 합계 & 평균, 등급 구하기

void CompareArrays(void)
{
	printf("<<1학기와 2학기 성적 비교>> \n\n");
	printf("\t국어  \t영어  \t수학  \t사회  \t과학  \t총점  \t평균\n\n");

	int result[6][8];

	for (i = 0; i < 6; i++)
	{
		for (int j = 0; j < 7; j++)
		{
			result[i][j] = arr2[i][j]-arr1[i][j];
		}
	}

	for (i = 0; i < 6; i++)
	{
		if (i == 0)
			printf("전지현\t");
		else if (i == 1)
			printf("송중기\t");
		else if (i == 2)
			printf("한지민\t");
		else if (i == 3)
			printf("장동건\t");
		else if (i == 4)
			printf(" 합계\t");
		else
			printf(" 평균\t");

		for (j = 0; j < 7; j++)
		{
			printf("%d", result[i][j]);
			if (result[i][j] < 0)
			{
				SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), FOREGROUND_RED | FOREGROUND_INTENSITY);
				printf("(↓)\t");
				SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 15);
			}
			else if (result[i][j] == 0)
				printf("(==)\t");
			else
			{
				SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), FOREGROUND_GREEN | FOREGROUND_INTENSITY);
				printf("(↑)\t");
				SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 15);
			}
		}
		SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 15);
		printf("\n");
	}

	printf("\n\n");
	for (int i = 0; i < 4; i++)
	{
		if (i == 0)
			printf("☆1학기 대비 전지현 성적☆\n\n");
		else if (i == 1)
			printf("☆1학기 대비 송중기 성적☆\n\n");
		else if (i == 2)
			printf("☆1학기 대비 한지민 성적☆\n\n");
		else if (i == 3)
			printf("☆1학기 대비 장동건 성적☆\n\n");

		for (int j = 0; j < 7; j++)
		{
			if (j == 0)
				printf("국어성적 ");
			else if (j == 1)
				printf("영어성적 ");
			else if (j == 2)
				printf("수학성적 ");
			else if (j == 3)
				printf("사회성적 ");
			else if (j == 4)
				printf("과학성적 ");
			else if (j == 5)
				printf("총점 ");
			else
				printf("평균 ");

			result[i][j] = arr2[i][j] - arr1[i][j];
			if (result[i][j] < 0)
				printf("1학기 대비 %d점 떨어졌습니다.\n", result[i][j]);
				else if (result[i][j] == 0)
				printf("1학기와 동일합니다.\n");
			else
				printf("1학기 대비 %d점 올랐습니다.\n", result[i][j]);
		}

		if (result[i][6] > 0)
		{
			SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), FOREGROUND_GREEN | FOREGROUND_BLUE | FOREGROUND_INTENSITY);
			puts("***축하합니다. 총점이 향상되었습니다.***\n\n");
			SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 15);
		}
		else if (result[i][6] == 0)
			printf("***총점의 변화가 없네요.***\n\n");
			
		else
		{
			SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), FOREGROUND_RED | FOREGROUND_BLUE | FOREGROUND_INTENSITY);
			printf("***총점이 떨어졌습니다. 열심히 하세요.***\n\n");
			SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 15);
		}
	}						
	SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 15);
	printf("\n");
}
//1학기 2학기 비교 및 COMMENTS

main()
{
	SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), FOREGROUND_RED | FOREGROUND_GREEN | FOREGROUND_INTENSITY);
	puts("KB Students' Score Management System\n");
	SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 15);
	Array1();
	Array2();
	CompareArrays();

	return 0;
}